using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //при выборе занесения данных вручную открывается форма 2
            Close();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //задаем уже подготовленные значения из курсовой работы
            double []x = new double[20];
            double []y = new double[20];

            x[0] = 7.46667;
            x[1] = 8.5;
            x[2] = 8.98509;
            x[3] = 10;
            x[4] = 10.02797;
            x[5] = 11.83486;
            x[6] = 12.81704;
            x[7] = 12.9569;
            x[8] = 13.87342;
            x[9] = 16.678;
            x[10] = 16.87628;
            x[11] = 16.89704;
            x[12] = 17.7027;
            x[13] = 18.05098;
            x[14] = 19.2;
            x[15] = 19.4572;
            x[16] = 20.73226;
            x[17] = 21;
            x[18] = 21;
            x[19] = 34.56667;

            y[0] = 0.914285714285714;
            y[1] = 0.69;
            y[2] = 0.74;
            y[3] = 0.45;
            y[4] = 0.62;
            y[5] = 0.46;
            y[6] = 0.34676067733919;
            y[7] = 0.33;
            y[8] = 0.451970802919708;
            y[9] = 0.269836910900588;
            y[10] = 0.242350802787034;
            y[11] = 0.333889816360601;
            y[12] = 0.270992366412214;
            y[13] = 0.28;
            y[14] = 0.31;
            y[15] = 0.33998600139986;
            y[16] = 0.29;
            y[17] = 0.188648314683874;
            y[18] = 0.21;
            y[19] = 0.18;

            DataTable table = new DataTable();
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));

            for (int i = 0; i < 20; i++) 
            {
                table.Rows.Add(x[i], y[i]);
            }

            Form4 f4 = new Form4(table);
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
