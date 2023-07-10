using System;
using System.Windows.Forms;
using Ionic.Zip;
namespace winformzip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Предлагает пользоваталю выбрат папку
        FolderBrowserDialog bd = new FolderBrowserDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            //задает путь пользователя
            if (bd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = bd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Предлагает пользователя где сохранить файл
            SaveFileDialog sfd = new SaveFileDialog();
            //При сохранение определяет тип файла
            sfd.Filter = "Zip files (*.zip)|*.zip";
            if (textBox1.Text != "" && sfd.ShowDialog() == DialogResult.OK)
            {
                ZipFile zf = new ZipFile(sfd.FileName);
                zf.AddDirectory(bd.SelectedPath);
                zf.Save();
                MessageBox.Show("Архивация прошла успешно.", "Выполнено");
            }
        }
    }
}
