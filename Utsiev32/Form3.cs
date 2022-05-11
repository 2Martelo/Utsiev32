using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Utsiev32
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //3.1. Нахождение наименьшего и наибольшего значения из трех чисел
        //
        // Метод для нахождения наибольшего значения из трех заданных чисел
        public static int FindMax3(int a, int b, int c)
        {
            int max;
            max = Math.Max(a, Math.Max(b, c));
            return max;
        }

        // Метод для нахождения наименьшего значения из трех заданных чисел
        public static int FindMin3(int a, int b, int c)
        {
            int min;
            min = Math.Min(a, Math.Min(b, c));
            return min;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            int z;


            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);
            z = Convert.ToInt32(textBox3.Text);

            listBox1.Items.Add("Наибольшее число из трех: " +
            FindMax3(x, y, z));
            listBox1.Items.Add("Наименьшее число из трех: " +
            FindMin3(x, y, z));
            
        }
        //3.3. Полный пример создания массива строк
        private void button2_Click(object sender, EventArgs e)
        {
            String[] s = Regex.Split("Январь Февраль Март Апрель Май Июнь Июль Август Сентябрь Октябрь Ноябрь Декабрь", " ");
            // Выводим 12 элемент массива
            listBox1.Items.Add(s[11]);

        }
        //3.4. Конвертируем градусы в радианы
       
        private void button3_Click(object sender, EventArgs e)
        {
            int degrees = Convert.ToInt32(textBox1.Text);
            double radians = (Math.PI / 180) * degrees;
            listBox1.Items.Add(radians);
        }
        //3.5. Конвертируем радианы в градусы
       private void button4_Click(object sender, EventArgs e)
        {
            int radians = Convert.ToInt32(textBox1.Text);
            double degrees = (180 / Math.PI) * radians;
            listBox1.Items.Add(degrees);

        }
        //3.9. Конвертируем градусы Фаренгейта в градусы Цельсия
       
        public static double FtoC(double Fahrenheit)
        {
            return ((5.0 / 9.0) * (Fahrenheit - 32));
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int far = Convert.ToInt32(textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add("Фаренгейт: " + textBox1.Text);
            listBox1.Items.Add("Цельсий: " + FtoC(far));
        }
        //3.10. Конвертируем градусы Цельсия в градусы Фаренгейта
        public static double CtoF(double Celsius)
        {
            return (((9.0 / 5.0) * Celsius) + 32);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int cel = Convert.ToInt32(textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add("Цельсий: " + textBox1.Text);
            listBox1.Items.Add("Фаренгейт: " + CtoF(cel));
        }
        //3.11. Генерация компонентов цветов случайным образом
        private Random m_Rnd = new Random(); 
        private Color RandomRGBColor()
        {
            return Color.FromArgb(255, m_Rnd.Next(0, 255), m_Rnd.Next(0, 255), m_Rnd.Next(0, 255));
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.BackColor = RandomRGBColor();
        }
        //3.12. Подсчет суммы всех целых чисел диапазона 
        public static int SumAll(byte Value)
        {
            int sum;
            sum = 0;
            for (int i = 1; i <= Value; i++)
                sum = sum + i;
            return sum;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            byte su = Convert.ToByte(textBox1.Text);
            listBox1.Items.Add(SumAll(su));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            Hide(); // скрываем текущую форму
            Form Form4 = new Form4(); // Создаем новую формy
            Form4.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            Form4.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно
        }
    }
}
