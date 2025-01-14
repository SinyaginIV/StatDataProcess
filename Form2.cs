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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Создаем таблицу данных и заполняем ее данными из DataGridView
            DataTable table = new DataTable();
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            for (int i = 0; i < dataGridView1.Rows.Count && dataGridView1[0, i].Value != null && dataGridView1[1, i].Value != null; ++i)
                {
                    double X = Convert.ToDouble(dataGridView1[0, i].Value);
                    double Y = Convert.ToDouble(dataGridView1[1, i].Value);

                    table.Rows.Add(X, Y);
                }

            // Открываем форму 4 и передаем ей таблицу данных
            Form4 f4 = new Form4(table);
                f4.Owner = this;
                f4.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

    }
}