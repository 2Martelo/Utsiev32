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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Очистим список
            listBox1.Items.Clear();
            // Получим список процессов, связанных с Internet Explorer
            foreach (Process p in Process.GetProcessesByName("iexplore"))
                listBox1.Items.Add(p.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // создаем новый процесс
            Process proc = new Process();
            // Запускаем Блокнот
            proc.StartInfo.FileName = @"Notepad.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = Application.ExecutablePath;
            // Выводим полный путь к файлу
            listBox1.Items.Add(appPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Application.StartupPath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Запускаем Блокнот с файлом test.txt
            Process.Start("notepad.exe", "test.txt");
            // Запускаем браузер с заданным адресом
            Process.Start("opera.exe", "https://img.ubu.ru/gal_toypudel0_182752753.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Устанавливаем информацию
            ProcessStartInfo start_info = new ProcessStartInfo
            (@"C:\windows\system32\notepad.exe");
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            // создаем новый процесс
            Process proc = new Process();

            proc.StartInfo = start_info;
            // Запускаем процесс
            proc.Start();
            // Ждем, пока Блокнот запущен
            proc.WaitForExit();
            MessageBox.Show("Кодик завершения: " + proc.ExitCode, "Завершение " +
            "Кодик", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        protected Process[] procs;
        private void button6_Click(object sender, EventArgs e)
        {
            procs = Process.GetProcessesByName("Notepad");
            int i = 0;
            while (i != procs.Length)
            {
                procs[i].Kill();
                i++;
                MessageBox.Show("Всего : " + i.ToString());
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int am = Process.GetCurrentProcess().ProcessorAffinity.ToInt32();
            int processorCount = 0;
            while (am != 0)
            {
                processorCount++;
                am &= (am - 1);
            }
            listBox1.Items.Add(processorCount.ToString());

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            String.Format(
            "Число процессоров: {0}",
            Environment.ProcessorCount.ToString()));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Делаем паузу на 3 секунды
            System.Threading.Thread.Sleep(3000);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
                listBox1.Items.Add(p.ToString());

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in
            Process.GetProcesses(System.Environment.MachineName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    // Оконные приложения
                    listBox1.Items.Add(p.ToString());
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;
            listBox1.Items.Add(os.Version);
            listBox1.Items.Add(os.Platform);
            listBox1.Items.Add(os.ServicePack);
            listBox1.Items.Add(os.VersionString);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;
            Version version = os.Version;
            if ((version.Major == 5) && (version.Minor == 1)
            || version.Major >= 6)

            {
                MessageBox.Show("Программа может запускаться" +
                " в вашей операционной системе");
            }
            else
            {
                MessageBox.Show
                ("Эта версия операционной системы не поддерживается." +
                "\r\n Используйте Windows XP или Windows Vista");
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Определяем имя пользователя системы
           listBox1.Items.Add(SystemInformation.UserName);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Hide(); // скрываем текущую форму
            Hide(); // скрываем текущую форму
            Form disk = new disk(); // Создаем новую формy
            disk.ShowDialog(); // Показываем созданную форму и ждем её закрытия
            disk.Dispose(); // Уничтожаем уже закрытую новую форму
            Show(); // Показываем текущую форму обратно

        }
    }
}
