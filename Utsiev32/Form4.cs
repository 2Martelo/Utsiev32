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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //10.13. Получение списка файлов в папке
        private void button1_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\");
            listBox1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listBox1.Items.Add(file);
        }

        //10.14. Получение списка папок и файлов
        private void button2_Click(object sender, EventArgs e)
        {
            string[] directoryEntries = System.IO.Directory.GetFileSystemEntries(@"c:\windows");
            foreach (string str in directoryEntries)
            {
                listBox1.Items.Add(str);
            }
        }
        //10.15. Получение списка файлов по маске
        private void button3_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\", "*.in?");
            listBox1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listBox1.Items.Add(file);
        }
        //10.16. Проверка существования файла
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (System.IO.File.Exists(Application.StartupPath + "\\test.txt"))
                listBox1.Items.Add("Файл test.txt существует");
            else
                listBox1.Items.Add("Файл test.txt не существует");
        }
        //10.17. Получение имени файла из полного пути
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // Полный путь к файлу
            string fileNamePath = @"c:\windows\system32\notepad.exe";
            // Имя файла с расширением
            listBox1.Items.Add(System.IO.Path.GetFileName(fileNamePath));
            // Имя файла без расширения
            listBox1.Items.Add(
            System.IO.Path.GetFileNameWithoutExtension(fileNamePath));
        }
        //10.18. Получение расширения файла
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // Полный путь к файлу
            string fileNamePath = @"c:\windows\system32\notepad.exe";
            // Получим расширение файла
            listBox1.Items.Add(System.IO.Path.GetExtension(fileNamePath));
        }
        //10.20. Получение свойств файла 
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); listBox1.Items.Clear();
            // Выводим информацию о файле.
            System.IO.FileInfo file = new
            System.IO.FileInfo(@"c:\wutemp\text.txt");
            listBox1.Items.Clear();
            listBox1.Items.Add("Свойства для файла: " + file.Name);
            listBox1.Items.Add("Наличие файла: " + file.Exists.ToString());
            if (file.Exists)
            {
                listBox1.Items.Add("Время создания файла: ");
                listBox1.Items.Add(file.CreationTime.ToString());
                listBox1.Items.Add("Последнее изменение файла: ");
                listBox1.Items.Add(file.LastWriteTime.ToString());
                listBox1.Items.Add("Файл был открыт в последний раз: ");
                listBox1.Items.Add(file.LastAccessTime.ToString());
                listBox1.Items.Add("Размер файла (в байтах): ");
                listBox1.Items.Add(file.Length.ToString());
                listBox1.Items.Add("Атрибуты файла: ");
                listBox1.Items.Add(file.Attributes.ToString());
            }
        }
    }
}
