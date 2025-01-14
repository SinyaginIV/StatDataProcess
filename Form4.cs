using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kurs
{
    public partial class Form4 : Form
    {
        public Form4(DataTable table)
        {
            InitializeComponent();
            this.table = table;
        }

        private DataTable table;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //проверяем таблицу на наличие данных
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Таблица пуста. Введите данные.");
            }
            //задаем внешний вид диаграммы
            chart1.Series.Clear();
            chart1.Series.Add("Data");
            chart1.Series["Data"].ChartType = SeriesChartType.Point;

            foreach (DataRow row in table.Rows)
            {
                double x = Convert.ToDouble(row["X"]);
                double y = Convert.ToDouble(row["Y"]);

                chart1.Series["Data"].Points.AddXY(x, y);
            }
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.Series["Data"].MarkerSize = 10;
            chart1.Series["Data"].BorderWidth = 10;
            chart1.Series["Data"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["Data"].Color = Color.Fuchsia;
            chart1.Update();

            double Xm = 0;
            double Ym = 0;
            double numerator = 0, determinator1 = 0, determinator2 = 0;
            
            //начинаем вычислять коэффициент корреляции
            foreach (DataRow row in table.Rows)
            {
                Xm += Convert.ToDouble(row[0]);
                Ym += Convert.ToDouble(row[1]);
            }

            Xm /= Convert.ToDouble(table.Rows.Count);
            Ym /= Convert.ToDouble(table.Rows.Count);

            List<double> resultValues = new List<double>();

            // проходим по всем строкам таблицы и вычитаем xm из значения в столбце x
            
            foreach (DataRow row in table.Rows)
            {
                numerator += (Convert.ToDouble(row[0]) - Xm) * (Convert.ToDouble(row[1]) - Ym);

                determinator1 += Math.Pow((Convert.ToDouble(row[0]) - Xm), 2);
                determinator2 += Math.Pow((Convert.ToDouble(row[1]) - Ym), 2);
            }

            // вычисляем сумму значений в списке
            double sum = numerator / Math.Sqrt((determinator1 * determinator2));

            label2.Text = Convert.ToString(Math.Round(sum, 5));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("   Значения коэффициента корреляции Пирсона " +
                "могут быть от -1 до 1.\r\n\r\n    Значение -1 означает совершенную " +
                "отрицательную корреляцию, то есть, когда одна переменная увеличивается, " +
                "другая уменьшается с той же самой степенью.\r\n\r\n    Значение 1 означает " +
                "совершенную положительную корреляцию, то есть, когда обе переменные увеличиваются " +
                "или уменьшаются с той же самой степенью.\r\n   Значение 0 означает отсутствие корреляции " +
                "между переменными.\r\n\r\n    Чем ближе значение коэффициента корреляции Пирсона к -1 или 1, " +
                "тем сильнее линейная связь между переменными. Если значение близко к 0, то это указывает на " +
                "отсутствие линейной связи между переменными.\r\n");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
