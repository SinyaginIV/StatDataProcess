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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] x = new double[14];
            double[] y = new double[14];
            //вводим подготовленные данные из курсовой работы
            x[0] = 17;
            x[1] = 18;
            x[2] = 19;
            x[3] = 20;
            x[4] = 21;
            x[5] = 22;
            x[6] = 23;
            x[7] = 24;
            x[8] = 25;
            x[9] = 27;
            x[10] = 28;
            x[11] = 29;
            x[12] = 30;
            x[13] = 31;
            
            y[0] = 1;
            y[1] = 1;
            y[2] = 1;
            y[3] = 1;
            y[4] = 2;
            y[5] = 3;
            y[6] = 3;
            y[7] = 4;
            y[8] = 4;
            y[9] = 2;
            y[10] = 4;
            y[11] = 2;
            y[12] = 2;
            y[13] = 1;
            

            DataTable table = new DataTable();
            table.Columns.Add("Варианта", typeof(double));
            table.Columns.Add("Кратность", typeof(double));

            for (int i = 0; i < 14; i++)
            {
                table.Rows.Add(x[i], y[i]);
            }

            Form8 f8 = new Form8(table);
            f8.Show();
        }
    }
}
