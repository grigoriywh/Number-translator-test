using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace GDV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //		Кнопки 

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Clear2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //	Форма - Выбор директории

        private void button1_Click(object sender, EventArgs e)
        {

                string num = textBox1.Text;
                int round = 5;
   
                string result = ""; //Результат
                int left = 0; //Целая часть
                int right = 0; //Дробная часть
                string[] temp1 = num.Split(new char[] { '.', ',' }); //Нужна для разделения целой и дробной частей
                left = Convert.ToInt32(temp1[0]);
                //Проверяем имеется ли у нас дробная часть
                if (temp1.Count() > 1)
                {
                    right = Convert.ToInt32(num.Split(new char[] { '.', ',' })[1]); //Дробная часть
                }
                //Алгоритм перевода целой части в двоичную систему
                while (true)
                {
                    result += left % 2; //В ответ помещаем остаток от деления. В конце программы мы перевернём строку, так как в обратном порядке записываются остатки
                    left = left / 2; //Так как Left целое число, то при делении например числа 2359 на 2, мы получим не 1179,5 а 1179
                    if (left == 0)
                        break;
                }
                result = new string(result.ToCharArray().Reverse().ToArray()); //Реверсирование строки
                /*Не углублялся в ситуацию, но вдруг при реверсе появятся первые символы нули, а ведь их мы не пишем!
                Не знаю есть ли необходимость в этом цикле */
                while (true)
                {
                    int i = 0;
                    if (result[i] == '0')
                        result = result.Remove(i, 1);
                    else break;
                }
                //Прокеряем есть ли у нас дробная часть, можно было бы проверить и так if(temp1.count()>1)
                if (right == 0)
                    textBox2.Text = result;

                //Добавляем разделить целой части от дробной
                result += '.';

                int count = right.ToString().Count(); // Нам нужно знать кол-во цифр, при превышении которого дописывается единичка

                for (int i = 0; i < round; i++)
                {
                    /*Умножаем число на 2 и проверяем, стало ли оно больше по количеству цифр, если да,
                    то в результат идёт "1" и первая цифра у right удаляется */
                    right = right * 2;
                    if (right.ToString().Count() > count)
                    {
                        string buf = right.ToString();
                        buf = buf.Remove(0, 1);
                        right = Convert.ToInt32(buf);

                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }
                textBox2.Text = result;

            }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //	Пустые функции 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
