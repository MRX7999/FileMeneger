using MetroFramework.Components; //Делаем всеми любимый графений
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // подключаем библиотеку для открытия файлов
using System.IO; //подключаем библиотеку для юзания в дисковом пространстве

namespace Может_быть_нормальный_файловый_менеджер
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MetroStyleManager metroStyleManager1 = null; //Оживляем графений, если вылезает ошибка удалить и вставить за ного эти две строки
            this.StyleManager = metroStyleManager1;
            notifyIcon1.BalloonTipTitle = "File Menedger Power by AnRub"; // отображение для уведоблений
            notifyIcon1.BalloonTipText = "File Menedger has been worked..."; // отображение для уведоблений
            notifyIcon1.Text = "Virus Detected"; // отображение для уведоблений
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // фикс бага с наслойкой директорий друг на друга
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text); // передаем путь в конструктор
            DirectoryInfo[] dirs = dir.GetDirectories(); // Масив для хранения катологов
            foreach (DirectoryInfo ssDir in dirs) // перебор элементов масива
            {
                listBox1.Items.Add(ssDir); // добовляем в список элемент
            }

            FileInfo[] files = dir.GetFiles(); // отображаем сами файлы
            foreach (FileInfo ssFile in files) // выводим все содержащиеся файлы на экран
            {
                listBox1.Items.Add(ssFile); // вывод
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) // пользовательский клик
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "") //открытие файла
            {
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()); //выебнулся
                listBox1.Items.Clear(); // фикс бага с наслойкой директорий друг на друга
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text); // передаем путь в конструктор
                DirectoryInfo[] dirs = dir.GetDirectories(); // Масив для хранения катологов
                foreach (DirectoryInfo ssDir in dirs) // перебор элементов масива
                {
                    listBox1.Items.Add(ssDir); // добовляем в список элемент
                }

                FileInfo[] files = dir.GetFiles(); // отображаем сами файлы
                foreach (FileInfo ssFile in files) // выводим все содержащиеся файлы на экран
                {
                    listBox1.Items.Add(ssFile); // вывод
                }
            }
    else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())); // Дефолтный вывод
            }
        }

        private void metroButton2_Click(object sender, EventArgs e) // описываем кнопку назад
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\') // стриаем сеши
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1); // удаляем один символ
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1 ] != '\\' )
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

                }
            }
            listBox1.Items.Clear(); // фикс бага с наслойкой директорий друг на друга
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text); // передаем путь в конструктор
            DirectoryInfo[] dirs = dir.GetDirectories(); // Масив для хранения катологов
            foreach (DirectoryInfo ssDir in dirs) // перебор элементов масива
            {
                listBox1.Items.Add(ssDir); // добовляем в список элемент
            }

            FileInfo[] files = dir.GetFiles(); // отображаем сами файлы
            foreach (FileInfo ssFile in files) // выводим все содержащиеся файлы на экран
            {
                listBox1.Items.Add(ssFile); // вывод
            }

        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) // Добавляем видимость отрицательную при открытом окне проги
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e) // добавляем положительную видимость на 1 сек. или ее отсутсвие в скрытом состоянии. 
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // зарывает окно
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();  // открывает окно
        }
    }
}
