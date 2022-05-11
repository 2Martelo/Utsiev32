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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            RichTextBoxEx rboxex = new RichTextBoxEx();
            rboxex.Parent = this;
            rboxex.Top = 400;
            richTextBox4.AllowDrop = true;
            this.richTextBox1.DragEnter +=
            new System.Windows.Forms.DragEventHandler(
            this.richTextBox4_DragEnter);
            this.richTextBox4.DragDrop +=
            new System.Windows.Forms.DragEventHandler(
            this.richTextBox4_DragEnter);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public class MyTextBox : TextBox
        {
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)13)
                    e.Handled = true;
                else
                    base.OnKeyPress(e);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            textBox2.SelectionStart = 0;
            textBox2.SelectionLength = textBox2.Text.Length;
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = richTextBox1.Rtf;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Устанавливаем фокус на richTextBox2
            richTextBox2.Focus();
            // Устанавливаем цвет для выделенного текста
            richTextBox2.SelectionColor = Color.Red;
            // Устанавливаем шрифт
            richTextBox2.SelectionFont = new Font("Courier", 10, FontStyle.Bold);
        }

        private void richTextBox3_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        class RichTextBoxEx : RichTextBox
        {
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                //Проверяем на нажатие Shift+Insert и Ctrl+V
                if ((keyData & (Keys.Shift | Keys.Insert)) ==
                (Keys.Shift | Keys.Insert)
                || ((keyData & (Keys.Control | Keys.V)) ==
                (Keys.Control | Keys.V)))

                    return true;
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }
        private void richTextBox4_DragEnter(object sender,
System.Windows.Forms.DragEventArgs e)
        {
            if (((DragEventArgs)e).Data.GetDataPresent(DataFormats.Text))
                ((DragEventArgs)e).Effect = DragDropEffects.Move;
            else
                ((DragEventArgs)e).Effect = DragDropEffects.None;
        }
        private void richTextBox4_DragDrop(object sender, DragEventArgs e)
        {
            richTextBox4.LoadFile((String)e.Data.GetData("Text"),
            System.Windows.Forms.RichTextBoxStreamType.RichText);
        }
        [DllImport("User32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        const int GWL_STYLE = -16;
        const int WS_HSCROLL = 0x00100000;
        const int WS_VSCROLL = 0x00200000;
        // Проверка на наличие вертикальной прокрутки
        bool IsVertScrollPresent(Control control)
        {
            int style = GetWindowLong(control.Handle, GWL_STYLE);
            return (style & WS_VSCROLL) > 0;
        }
        // Проверка на наличие горизонтальной прокрутки
        bool IsHorScrollPresent(Control control)

        {
            int style = GetWindowLong(control.Handle, GWL_STYLE);
            return (style & WS_HSCROLL) > 0;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Вертикальная прокрутка: " +
            IsVertScrollPresent(richTextBox5).ToString() +
            Environment.NewLine + "Горизонтальная прокрутка: " +
            IsHorScrollPresent(richTextBox5).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Hide(); // скрываем текущую форму
            Form Form8 = new Form8(); // Создаем новую формy
            Form8.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            Form8.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно
        }
    }

}
