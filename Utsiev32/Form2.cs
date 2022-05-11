using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Utsiev32
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            listBox1.Items.Add(today.Date.ToLongDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DateTime dt = DateTime.Now;
            
            listBox1.Items.Clear();
            listBox1.Items.Add("d: " + dt.ToString("d"));
            listBox1.Items.Add("D: " + dt.ToString("D"));
            listBox1.Items.Add("f: " + dt.ToString("f"));
            listBox1.Items.Add("F: " + dt.ToString("F"));
            listBox1.Items.Add("g: " + dt.ToString("g"));
            listBox1.Items.Add("G: " + dt.ToString("G"));
            listBox1.Items.Add("m: " + dt.ToString("m"));
            listBox1.Items.Add("r: " + dt.ToString("r"));
            listBox1.Items.Add("s: " + dt.ToString("s"));
            listBox1.Items.Add("u: " + dt.ToString("u"));
            listBox1.Items.Add("U: " + dt.ToString("U"));
            listBox1.Items.Add("y: " + dt.ToString("y"));
            listBox1.Items.Add("MMMM dd: " + dt.ToString("MMMM dd"));
            listBox1.Items.Add("MM/dd/yyyy: " + dt.ToString("MM/dd/yyyy"));
            listBox1.Items.Add("MM/dd/yyyy HH:mm: " +
            dt.ToString("MM/dd/yyyy HH:mm"));
            listBox1.Items.Add("MM/dd/yyyy hh:mm tt: " +
            dt.ToString("MM/dd/yyyy hh:mm tt"));
            listBox1.Items.Add("MM/dd/yyyy H:mm: " +
            dt.ToString("MM/dd/yyyy H:mm"));
            listBox1.Items.Add("MM/dd/yyyy h:mm tt: " +
            dt.ToString("MM/dd/yyyy h:mm tt"));
            listBox1.Items.Add("MM/dd/yyyy HH:mm:ss: " +
            dt.ToString("MM/dd/yyyy HH:mm:ss"));

            listBox1.Items.Add("dddd, dd MMMM yyyy: " +
            dt.ToString("dddd, dd MMMM yyyy"));
            listBox1.Items.Add("dddd, dd MMMM yyyy HH:mm:ss: " +
            dt.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            listBox1.Items.Add("ddd, dd MMM yyyy HH':'mm':'ss 'GMT': " +
            dt.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"));

            listBox1.Items.Add("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK: " +
            dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK"));
            listBox1.Items.Add("yyyy'-'MM'-'dd'T'HH':'mm':'ss: " +
            dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            listBox1.Items.Add("yyyy MMMM: " + dt.ToString("yyyy MMMM"));
            
            listBox1.Items.Add("H:mm: " + dt.ToString("H:mm"));
            listBox1.Items.Add("HH:mm: " + dt.ToString("HH:mm"));
            listBox1.Items.Add("HH:mm:ss: " + dt.ToString("HH:mm:ss"));
            listBox1.Items.Add("h:mm tt: " + dt.ToString("h:mm tt"));
            listBox1.Items.Add("hh:mm tt: " + dt.ToString("hh:mm tt"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Измеряем производительность для UtsNow
            DateTime dt = DateTime.UtcNow;
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                sw.Start();
                for (int j = 0; j < 100000; j++)
                {
                    if (DateTime.UtcNow == dt)
                    {
                        /* do action */
                    }
                }
                MessageBox.Show(sw.ElapsedTicks.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DateTime curdate = DateTime.Now;
            // Прибавляем семь дней к текущей дате
            DateTime mydate = curdate.AddDays(7);
            listBox1.Items.Add(mydate.ToShortDateString());

        }
        // Наш собственный метод вычисления разницы в датах
        public static int DaysDiff(DateTime date1, DateTime date2)
        {
            return date1.Subtract(date2.Date).Days;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            {
                int year = Convert.ToInt32(textBox1.Text);
                int month = Convert.ToInt32(textBox2.Text);
                int day = Convert.ToInt32(textBox3.Text);

                string howdays = DaysDiff(DateTime.Today, new DateTime(year, month, day)).ToString();
                listBox1.Items.Add("Со дня моего дня рождения прошло: " + howdays + "дней");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int year = Convert.ToInt32(textBox1.Text);
            int month = Convert.ToInt32(textBox2.Text);
            int day = Convert.ToInt32(textBox3.Text);
            string howdays = DaysDiff(DateTime.Today, new DateTime(year, month, day)).ToString();
            int dni = Convert.ToInt32(howdays);
            int goda = Convert.ToInt32(dni/365);
            listBox1.Items.Add("Со дня моего дня рождения прошло: " + goda + "лет");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool leapYear = DateTime.IsLeapYear(DateTime.Now.Year);
            MessageBox.Show(
            String.Format("{0} является високосным годом: {1}",
            DateTime.Now.Year, leapYear));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int parrots = 38;
            textBox1.Text = parrots.ToString("X8");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int myvalue = 4;
            textBox1.Text = Convert.ToString(myvalue, 2); // возвратит 100
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int myValue = 365;
            // Преобразуем в восьмеричное значение
            MessageBox.Show(Convert.ToString(myValue, 8));
            // Преобразуем в шестнадцатеричное значение
            MessageBox.Show(Convert.ToString(myValue, 16));
        }

        // Пишем собственную функцию IsNumeric на чистом C#
        static bool IsNumeric(object Expression)
        {
            // Возвращаемое значение
            bool isNum;
            // Переменная, используемая в качестве параметра
            // в методе TryParse
            double retNum;
            // Метод TryParse конвертирует строку в заданный стиль
            // и локальный формат.
            isNum = Double.TryParse(Convert.ToString(Expression),
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
             return isNum;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Является ли " + textBox1.Text + " числом: " + IsNumeric(textBox1.Text));
        }

        enum Cats { Рыжик = 3, Барсик = 5, Мурзик, Васька, Пушок };
        private void button10_Click(object sender, EventArgs e)
        {
            // Перечисляем все элементы перечисления
            string[] catNames = Enum.GetNames(typeof(Cats));
            foreach (string s in catNames)
            {
                listBox1.Items.Add(s);
            }
           
            // Перечисляем все значения перечисления
            int[] valCats = (int[])Enum.GetValues(typeof(Cats));
            foreach (int val in valCats)
            {
                listBox1.Items.Add(val.ToString());
            }
            MessageBox.Show(catNames[3].ToString());
            MessageBox.Show(valCats[3].ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Получаем массив строк, содержащих все цвета в системе
            string[] allcolors =
            Enum.GetNames(typeof(System.Drawing.KnownColor));
            listBox1.Items.Clear();
            // Выводим все имена в список
            listBox1.Items.AddRange(allcolors);
            // Другой вариант
            //foreach (string s in allcolors)
            //{
            // listBox1.Items.Add(s);
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Object ColorEnum;
            ColorEnum = System.Enum.Parse(typeof(KnownColor), textBox4.Text);
            KnownColor SelectedColor = (KnownColor)ColorEnum;
            this.BackColor = System.Drawing.Color.FromKnownColor(SelectedColor);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Hide(); // скрываем текущую форму
            Form Form3 = new Form3(); // Создаем новую формy
            Form3.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            Form3.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно

        }
    }
}
