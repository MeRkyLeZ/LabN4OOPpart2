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
        Model model;
        public Form1()
        {
            InitializeComponent();

            model = new Model();
            model.observer += new System.EventHandler(this.UpdateFormModel);
        }

        private void CheckNull()    // Проверка пустоты
        {
            if (textBox1.Text == "") textBox1.Text = (0).ToString();
            if (textBox2.Text == "") textBox2.Text = (0).ToString();
            if (textBox3.Text == "") textBox3.Text = (0).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   // Изменения текста
        {
            CheckNull();

            model.setValue1(Int32.Parse(textBox1.Text));

            /*if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
            {
                textBox2.Text = (Int32.Parse(textBox1.Text) - 1).ToString();
            }
            textBox3.Text = textBox1.Text;*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   // Изменения текста
        {
            CheckNull();

            model.setValue2(Int32.Parse(textBox2.Text));

            /* if (Int32.Parse(textBox1.Text) <= Int32.Parse(textBox2.Text))
             {
                 textBox1.Text = (Int32.Parse(textBox2.Text) + 1).ToString();
             }
             textBox3.Text = textBox2.Text;*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)   // Изменения текста
        {
            CheckNull();

            model.setValue2(Int32.Parse(textBox3.Text));

            /*if (Int32.Parse(textBox1.Text) == Int32.Parse(textBox3.Text))
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
            }*/
        }

        private void UpdateFormModel(object sender, EventArgs e)    // Обновление
        {
            textBox1.Text = model.getValue1().ToString();
            textBox2.Text = model.getValue2().ToString();
            textBox3.Text = model.getValue2().ToString();
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

    public class Model  // Модель
    {
        private int value1; // 1 значение
        private int value2; // 2 значение
        public System.EventHandler observer;    // событие

        public int getValue1()  // Получение 1-го значения
        {
            return value1;
        }
        public int getValue2()  // Получение 2-го значения
        {
            return value2;
        }
        public void setValue1(int value)    // Установка 1-го значения
        {
            value1 = value;
            if (value1 <= value2)
            {
                value2 = value1 - 1;
            }
            observer.Invoke(this, null);    // Вызов обновления
        }
        public void setValue2(int value)    // Установка 2-го значения
        {
            value2 = value;
            if (value1 <= value2)
            {
                value1 = value2 + 1;
            }
            observer.Invoke(this, null);    // Вызов обновления
        }
    }
}
