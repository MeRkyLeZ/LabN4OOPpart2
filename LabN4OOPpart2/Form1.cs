using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabN4OOPpart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckNull()    // Проверка пустоты
        {
            if (textBox1.Text == "") textBox1.Text = (0).ToString();
            if (textBox2.Text == "") textBox2.Text = (0).ToString();
            if (textBox3.Text == "") textBox3.Text = (0).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckNull();
            if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
            {
                textBox2.Text = (Int32.Parse(textBox1.Text) - 1).ToString();
            }
            textBox3.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckNull();
            if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
            {
                textBox1.Text = (Int32.Parse(textBox2.Text) + 1).ToString();
            }
            textBox3.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CheckNull();
            if (Int32.Parse(textBox1.Text) == Int32.Parse(textBox3.Text))
            {
                textBox1.Text = textBox3.Text;
                if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
                {
                    textBox2.Text = (Int32.Parse(textBox1.Text) - 1).ToString();
                }
            }
            else
            {
                textBox2.Text = textBox3.Text;
                if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
                {
                    textBox1.Text = (Int32.Parse(textBox2.Text) + 1).ToString();
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)   // Ввод только чисел
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
