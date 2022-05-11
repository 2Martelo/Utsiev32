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


namespace Utsiev32
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//6.1
        {
            // Шаг 1
            TextBox tb = new TextBox();
            // Шаг 2
            tb.Location = new Point(10, 10);
            tb.Size = new Size(100, 20);
            tb.Text = "Я был создан во время выполнения программы";
            // Шаг 3
            this.Controls.Add(tb);
        }

        private void button2_Click(object sender, EventArgs e)//6.2
        {
            foreach (Control ctrl in this.Controls)
            {
                // Работаем только с текстовыми полями
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = "Народные советы";
            }
        }

        private void IterateControls(Control ctrl) //6.3
        {
            // Работаем только с текстовыми полями
            if (ctrl.GetType() == typeof(TextBox))
            {
                ctrl.Text = "НеНародные советы";
            }
            // Проходим через элементы рекурсивно,
            // чтобы не пропустить элементы, которые находятся в контейнерах
            foreach (Control ctrlChild in ctrl.Controls)
            {
                IterateControls(ctrlChild);
            }
        }
       void button3_Click(object sender, EventArgs e)
        {
            IterateControls(this);
        }
        public class MyButton : Button //6.4
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                int borderWidth = 1;
                Color borderColor = Color.Green;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
                borderWidth, ButtonBorderStyle.Solid, borderColor,
                borderWidth, ButtonBorderStyle.Solid, borderColor,
                borderWidth, ButtonBorderStyle.Solid, borderColor,
                borderWidth, ButtonBorderStyle.Solid);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyButton btn = new MyButton();
            btn.Width = 90;
            btn.Height = 50;
            btn.Left = 100;
            btn.Top = 10;
            btn.Text = "Я новая кнопка";
            btn.Visible = true;
            this.Controls.Add(btn);
        }
        private void Form5_Paint(object sender, PaintEventArgs e) //6.5
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 3);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    g.DrawRectangle(p, new Rectangle(ctrl.Location, ctrl.Size));
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //6.6
        {
            const int MAX_LENGTH = 5;
            if (textBox1.Text.Length == MAX_LENGTH)
                // переводим фокус на следующий элемент управления
                SelectNextControl(textBox1, true, true, false, false);

        }

        private void button7_Click(object sender, EventArgs e) //6.7
        {
            // Выводим кнопку button7 на передний край
            this.Controls.SetChildIndex(button7, 0);
        }

        private void button9_Click(object sender, EventArgs e)//6.9
        {
            GraphicsPath gp = new GraphicsPath();
            Graphics g = CreateGraphics();
            // Создадим новый прямоугольник с размерами кнопки
            Rectangle smallRectangle = button1.ClientRectangle;

            // уменьшим размеры прямоугольника
            smallRectangle.Inflate(-3, -3);
            // создадим эллипс, используя полученные размеры
            gp.AddEllipse(smallRectangle);
            button1.Region = new Region(gp);
            // рисуем окантовоку для круглой кнопки
            g.DrawEllipse(new Pen(Color.Gray, 2),
            button1.Left + 1,
            button1.Top + 1,
            button1.Width - 3,
            button1.Height - 3);
            // освобождаем ресурсы
            g.Dispose();
        }

        private void button10_Click(object sender, EventArgs e) //6.10
        {
            listBox1.Items.Add(textBox1.Text);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void button11_Click(object sender, EventArgs e)//6.11
        {
            // Подгоняем ширину списка под самый длинный текст
            Graphics g = listBox1.CreateGraphics();
            float maxWidth = 0f;
            float height = 0f;
            for (int i = 0; i < listBox1.Items.Count; ++i)
            {
                float w = g.MeasureString(listBox1.Items[i].ToString(),
                listBox1.Font).Width;
                if (w > maxWidth)
                    maxWidth = w;
                height += listBox1.GetItemHeight(i);
            }
            g.Dispose();
            listBox1.Width = (int)(maxWidth + 8 + ((height > listBox1.Height - 4) ?
             16 : 0)); // 16 - ширина прокрутки
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        const string strTextForButton = "Тестовая строкаааааааааааааа"; //6.9
        private void button8_Click(object sender, EventArgs e)
        {
            button1.Text = strTextForButton;
            using (Graphics graphics = button1.CreateGraphics())
                
 {
                button1.Width = (int)graphics.MeasureString(strTextForButton,
                Font).Width;
                this.Text = button1.Width.ToString();
                listBox1.Items.Add(this.Text);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Hide(); // скрываем текущую форму
            Form Form6 = new Form6(); // Создаем новую формy
            Form6.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            Form6.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно

        }
    }
}
