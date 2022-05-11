using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Utsiev32
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void listBox2_DragDrop(object sender, DragEventArgs e) //6.12
        {
            //Извлекаем имя перетаскиваемого файла
            string[] astrings = (string[])e.Data.GetData(DataFormats.FileDrop,
            true);

            foreach (string strfile in astrings)
            {
                // только имя файла
                listBox2.Items.Add(strfile.Substring(1 +
                strfile.LastIndexOf(@"\")));
                // или полный путь к файлу
                listBox2.Items.Add(strfile);
            }
        }
            private void listBox2_DragEnter(object sender, DragEventArgs e) //6.12
            {
                // Разрешаем Drop только файлам
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ?
                DragDropEffects.All : DragDropEffects.None;
            }


    
        

        private void button2_Click(object sender, EventArgs e)//6.13
        {
            listBox1.Items.Add(Color.Red.Name);
            listBox1.Items.Add(Color.Yellow.Name);
            listBox1.Items.Add(Color.Green.Name);
            listBox1.Items.Add(Color.Blue.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = comboBox1.CreateGraphics();
            float maxWidth = 0f;
            foreach (object o in comboBox1.Items)
            {
                float w = g.MeasureString(o.ToString(), comboBox1.Font).Width;
                if (w > maxWidth)
                    maxWidth = w;
            }
            g.Dispose();
            // 28 - учитываем ширину кнопки в поле со списком
            comboBox1.Width = (int)maxWidth + 28;
        }

        private void button4_Click(object sender, EventArgs e)//
        {
            comboBox1.Font = new Font("Arial", 16);

        }
        const int CB_SETITEMHEIGHT = 0x0153;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd,
        UInt32 Msg, Int32 wParam, UInt32 lParam);
        private void button5_Click(object sender, EventArgs e)
        {
            // Устанавливаем желаемую высоту
            SendMessage(comboBox1.Handle, CB_SETITEMHEIGHT, -1, 40);
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
 UInt32 Msg, UInt32 wParam, UInt32 lParam);
        const int EM_GETLINECOUNT = 0x00BA;
        
        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Multiline = true;
            textBox8.WordWrap = true;
            textBox8.Height = 98;
            textBox8.Text += "У Лукоморья дуб зеленый; ";
            textBox8.Text += "Златая цепь на дубе том: ";
            textBox8.Text += "И днем и ночью кот ученый ";

            textBox8.Text += "Все ходит по цепи кругом";
            int LineCount;
            LineCount = (int)SendMessage(textBox8.Handle, EM_GETLINECOUNT, 0, 0);
            MessageBox.Show("Число строк: " + LineCount);
        }
        private void textBox1_KeyPress(object sender,//6.19
 System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == 'Б')
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender,
System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void textBox3_KeyPress(object sender,//6.20
System.Windows.Forms.KeyPressEventArgs e)
        {
            // по шаблону разрешаем вводить в поле цифры, знаки плюс, минус и запятую
            string pattern = "0123456789+-,";
            if (!Char.IsControl(e.KeyChar))
                if (pattern.IndexOf(e.KeyChar.ToString()) < 0)
                    e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string[] strWeekDay = { "Понедельник", "Вторник", "Среда" };
            textBox4.Multiline = true;
            textBox4.Lines = strWeekDay;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add(Color.Red.Name);
            listBox1.Items.Add(Color.Yellow.Name);
            listBox1.Items.Add(Color.Green.Name);
            listBox1.Items.Add(Color.Blue.Name);


        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) != 0)
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            string itemText = listBox1.Items[e.Index].ToString();
            Color color = Color.FromName(itemText);
            //Рисуем строку
            e.Graphics.DrawString(itemText, Font, new SolidBrush(color),
            e.Bounds);
            Pen pen = new Pen(color);

            //Рисуем линию под строкой
            e.Graphics.DrawLine(pen, e.Bounds.X, e.Bounds.Bottom - 1,
            e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Используем escape-последовательности для переноса текста
            // на новую строку
            textBox5.Text = "Раз\r\nДва\r\nТри";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Используем свойство NewLine для переноса строк
            textBox6.Text = "Месяцы года:" + Environment.NewLine + "Декабрь" +
             Environment.NewLine + "Январь...";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // Все вводимые символы переводятся в верхний регистр
            this.textBox7.CharacterCasing =
             System.Windows.Forms.CharacterCasing.Upper;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Hide(); // скрываем текущую форму
            Form Form7 = new Form7(); // Создаем новую формy
            Form7.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            Form7.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно
        }
    }
}
