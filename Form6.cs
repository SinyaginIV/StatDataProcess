using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public static void Bubble_Sort(DataTable table) // сортировка пузырьком для корректного вычисления значений
        {

            //Основной цикл 
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //Вложенный цикл 
                for (int j = 0; j < table.Rows.Count - 1 - i; j++)
                {
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (Convert.ToDouble(table.Rows[j] [0]) > Convert.ToDouble(table.Rows[j + 1] [0]))
                    {
                        double d1 = Convert.ToDouble(table.Rows[j][0]);
                        table.Rows[j][0] = table.Rows[j + 1][0];
                        table.Rows[j + 1][0] = d1;

                        double d2 = Convert.ToDouble(table.Rows[j][1]);
                        table.Rows[j][1] = table.Rows[j + 1][1];
                        table.Rows[j + 1][1] = d2;
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите варианты и кратность.\r\n \r\nВарианты – это то, какие цифры или числа встречаются в заданном ряде," +
                " кратность – сколько раз эта цифра или число встречается в ряде.\r\n \r\nНапример, в ряду 22391944, варианты – 2, 3, 1, 9, 4, " +
                "и их кратность 2, 1, 1, 2, 2 соответственно.\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable rt = new DataTable();
            rt.Columns.Add("Варианта", typeof(double));
            rt.Columns.Add("Кратность", typeof(double));

            for (int i = 0; i < dataGridView2.Rows.Count && dataGridView2[0, i].Value != null && dataGridView2[1, i].Value != null; ++i)
            {
                double Варианта = Convert.ToDouble(dataGridView2[0, i].Value);
                double Кратность = Convert.ToDouble(dataGridView2[1, i].Value);

                rt.Rows.Add(Варианта, Кратность);
                
            }

            Bubble_Sort(rt);

            this.dataGridView2.Sort(this.dataGridView2.Columns["Варианта"], ListSortDirection.Ascending);


            Form8 f8 = new Form8(rt);
            f8.Owner = this;
            f8.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
    }
}
