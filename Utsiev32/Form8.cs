using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utsiev32
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Устанавливаем фокус
            dateTimePicker1.Focus();
            // Посылаем команду
            SendKeys.Send("{F4}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(60, 255, 192, 192);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            linkLabel1.Text = "На нашем сайте вы найдете дополнительную информацию";
            linkLabel1.LinkArea = new LinkArea(3, 11);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://rusproject.narod.ru/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            linkLabel3.Text = "Yandex Google Rambler GoGo";
            linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel3.Links.Add(0, 6, "www.yandex.ru");
            linkLabel3.Links.Add(7, 6, "www.google.ru");
            linkLabel3.Links.Add(14, 7, "www.rambler.ru");
            linkLabel3.Links.Add(22, 4, "www.gogo.ru");
            linkLabel3.LinkClicked +=
            new LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnk = new LinkLabel();
            lnk = (LinkLabel)sender;
            lnk.Links[lnk.Links.IndexOf(e.Link)].Visited = true;
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
        private void Form8_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        
    }
}
