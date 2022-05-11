using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Utsiev32
{
    public partial class str : Form
    {
        public str()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string partBookTitle = textBox1.Text;
            string insertText = textBox2.Text;
            string bookTitle = partBookTitle.Insert(3, insertText);
            listBox1.Items.Add(bookTitle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookTitle = textBox1.Text;
            // Удаляем подстроку с третьей позиции
            bookTitle = bookTitle.Remove(2);
            listBox1.Items.Add(bookTitle);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bookTitle = textBox1.Text;
            // Извлекаем подстроку с шестой позиции с размером в три символа
            bookTitle = bookTitle.Substring(5, 3);
            listBox1.Items.Add(bookTitle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str1 = textBox2.Text;
            string str2 = textBox1.Text;
            int i = str2.IndexOf(str1);
            // Проверяем, входит ли строка  в слово 
            if (i >= 0) MessageBox.Show(str1 + " входит в строку " + str2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tankman = "4";
            string dog = "1";
            textBox1.Text = tankman + dog; // получим 41
            int all = int.Parse(tankman) + int.Parse(dog);
            textBox2.Text += Environment.NewLine + all.ToString(); // получим 5
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int charCode = 169;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text = specialChar.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Unicode-код для торговой марки
            int charCode = 0x00AE;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text += specialChar.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Создаем строку из 5 звездочек
            String FiveStars = new String('*', 5);
            listBox1.Items.Add (FiveStars);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string AutoName;
            AutoName = "BMW";
            listBox1.Items.Add(String.Format("Стоимость {0} равна {1:0.0;c}", AutoName, 12000));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Задаем цвет
            Color clr = Color.Green;
            // Получим имя выбранного цвета
            listBox1.Items.Add((TypeDescriptor.GetConverter(clr).ConvertToString(clr)));
            // Обратная задача. Конвертируем название цвета в объект Color
            clr = (Color)TypeDescriptor.GetConverter(
            typeof(Color)).ConvertFromString("Green");
            // Закрашиваем форму в выбранный цвет
            this.BackColor = clr;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = null;
            name = textBox1.Text;
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            listBox1.Items.Add(string.Concat("Hello, ", name));
        }
        public static string ReverseString(string str)
        {
            // Проверка на непустоту строки.
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
           
            // Создадим объект StringBuilder с нужной длиной.
            StringBuilder revStr = new StringBuilder(str.Length);
            // Перебираем в цикле все символы
            // и присоединяем каждый символ к StringBuilder
            for (int count = str.Length - 1; count > -1; count--)
            {
                revStr.Append(str[count]);
            }
            // Возвращаем перевернутую строку
            return revStr.ToString();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = ReverseString(textBox1.Text);

        }

       
        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Старт")
            {
                timer1.Enabled = true;
                button13.Text = "Стоп";
            }
            else
            {
                timer1.Enabled = false;
                button13.Text = "Старт";
            }

        }
        public static int counter = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string typingText = "C#.Народные советы";

            this.Text = typingText.Substring(0, counter);
            counter++;
            if (counter > typingText.Length)
                counter = 0;
        }
    }
}
