using Kurs;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.Owner = this;    
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    Программа написана на языке программирования C# с использованием Windows " +
                "Forms для курсовой работы в рамках комплексного экзамена готовности.\r\nДанная программа " +
                "позволяет:\r\n    1.Выполнить статистическую обработку ряда путём нахождения первичных методов статистической " +
                "обработки данных, таких как выборочное среднее (среднее арифметическое), дисперсия, мода и медиана, а также " +
                "построить таблицу распределения данных для лучшего представления данных. Для этого вам нужно ввести варианты " +
                "и кратность этих вариант в таблицу.\r\n    2.Вычислить коэффициент корреляции Пирсона, введя значения X и Y. Программа " +
                "вычислит коэффициент и построит диаграмму рассеяния (график корреляции). \r\n    Рациональные числа вводите, пожалуйста, " +
                "через запятую во избежание ошибок.\r\nРазработчик: Синягин Илья, ИСТ-21. \r\n");
        }


    }

}
