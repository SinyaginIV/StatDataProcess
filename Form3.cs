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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form9 f9 = new Form9();
            f9.Owner = this;
            f9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 f5 = new Form5();
            f5.Owner = this;
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }
    }
}
