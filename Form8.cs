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
    public partial class Form8 : Form
    {
        public Form8(DataTable rt)
        {
            InitializeComponent();
            this.rt = rt;
        }

        private DataTable rt;

    private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load_1(object sender, EventArgs e)
        {
        //задаем внешний вид графика
        chart2.Series.Clear();
            chart2.Series.Add("Data1");
            chart2.Series["Data1"].ChartType = SeriesChartType.Line;

            //добавляем точки из таблицы в график
            foreach (DataRow row in rt.Rows)
            {
                double x = Convert.ToDouble(row["Варианта"]);
                double y = Convert.ToDouble(row["Кратность"]);

                chart2.Series["Data1"].Points.AddXY(x, y);
            }
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.Series["Data1"].MarkerSize = 3;
            chart2.Series["Data1"].BorderWidth = 3;
            chart2.Series["Data1"].MarkerStyle = MarkerStyle.Circle;
            chart2.Series["Data1"].Color = Color.Red;
            chart2.Update();

            double Ysum = 0;
            double Xcp = 0;
            double Medium = 0;
            double Dispersion = 0;
            double numerator1 = 0;

            foreach (DataRow row in rt.Rows)
            {
                Ysum += Convert.ToDouble(row[1]);
                Medium += (Convert.ToDouble(row[0]) * Convert.ToDouble(row[1]));
            }
            //нахождение x среднего
            Xcp = Medium / Ysum;

            foreach (DataRow row in rt.Rows)
            {
                numerator1 += Math.Pow((Convert.ToDouble(row[0]) - Xcp), 2) * (Convert.ToDouble(row[1]));
            }
            //нахождение дисперсии
            Dispersion = numerator1 / Ysum;

            //проверяем наличие данных в таблице
            if (rt.Rows.Count == 0)
            {
                MessageBox.Show("Таблица пуста. Введите данные.");
                return;
            }


            // Создаем объект DataView для сортировки и фильтрации данных
            DataView dataView = new DataView(rt);

            // Сортируем DataView по столбцу "Варианта"
            dataView.Sort = "Варианта ASC";

            // Находим максимальное значение в столбце "Кратность"
            double maxMultiplicity = (double)dataView.ToTable().Compute("MAX(Кратность)", "");

            // Находим строку в таблице с максимальным значением "Кратность"
            DataRow[] rows = rt.Select("Кратность = " + maxMultiplicity);

            // Получаем значение столбца "Варианта" из строки
            double maxVariant = (double)rows[0]["Варианта"];

            var sortedRows = rt.AsEnumerable().OrderByDescending(x => x.Field<double>("Кратность"));
            double maxKr = rows.First().Field<double>("Кратность");

            var maxVariants = rows.Where(x => Convert.ToDouble(x["Кратность"]) == maxKr)
                                  .Select(x => Convert.ToString(x["Варианта"]))
                                  .ToList();


            List<double> values = new List<double>();
            foreach (DataRow row in rt.Rows)
            {
                double value = Convert.ToDouble(row["Варианта"]);
                int count = Convert.ToInt32(row["Кратность"]);
                //создание списка
                for (int j = 0; j < count; j++)
                {
                    values.Add(value);
                }
                // Проверяем наличие данных в таблице
                if (rt.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица пуста. Пожалуйста, введите данные в таблицу.");
                    return;
                }

                // Проверяем, что все значения в столбце Варианта являются числами
                foreach (DataRow row1 in rt.Rows)
                {
                    double value1;
                    if (!double.TryParse(row["Варианта"].ToString(), out value1))
                    {
                        MessageBox.Show("Значения в столбце Варианта должны быть числами. Пожалуйста, проверьте правильность введенных данных.");
                        return;
                    }
                }

                // Проверяем, что все значения в столбце Кратность являются числами
                foreach (DataRow row1 in rt.Rows)
                {
                    double value1;
                    if (!double.TryParse(row["Кратность"].ToString(), out value1))
                    {
                        MessageBox.Show("Значения в столбце Кратность должны быть числами. Пожалуйста, проверьте правильность введенных данных.");
                        return;
                    }
                }
            }
            //создаем массив для создания упорядоченного массива для нахождения медианы
            double[] arr = values.ToArray();

            Array.Sort(arr);

            if (arr.Length == 0)
            {
                MessageBox.Show("Ряд пуст. Введите данные.");
                return ;
            }
            //находим медиану
            if (arr.Length % 2 == 0)
            {
                double average = (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2.0;
                label9.Text = average.ToString();
            }
            else
            {
                int middleIndex = arr.Length / 2;
                label9.Text = arr[middleIndex].ToString();
            }
                
            label6.Text = Math.Round(Xcp, 5).ToString();
            label7.Text = Math.Round(Dispersion, 5).ToString();
            string maxVariantsStr = string.Join("; ", maxVariants);
            label8.Text = maxVariantsStr;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}