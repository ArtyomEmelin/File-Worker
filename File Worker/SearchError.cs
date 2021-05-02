using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class SearchError : Form
    {
        public SearchError()
        {
            InitializeComponent();
            Reset();
            Circle();
            CircleLabel();
        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox1.BackgroundImage = FileWorker.Properties.Resources.dark_close_move;
            }
            else
            {
                pictureBox1.BackgroundImage = FileWorker.Properties.Resources.white_close_move;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox2.BackgroundImage = FileWorker.Properties.Resources.dark_min_move;
            }
            else
            {
                pictureBox2.BackgroundImage = FileWorker.Properties.Resources.white_min_move;
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox2.BackgroundImage = FileWorker.Properties.Resources.dark_min;
            }
            else
            {
                pictureBox2.BackgroundImage = FileWorker.Properties.Resources.white_min;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox1.BackgroundImage = FileWorker.Properties.Resources.dark_close;
            }
            else
            {
                pictureBox1.BackgroundImage = FileWorker.Properties.Resources.white_close;
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_web_move;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_web_move;
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_web;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_web;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://fileworker.net");
        }

        private void ManeForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = Location;
        }

        private void ManeForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Location = Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void ManeForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        public async void DarkThemeTrue()
        {
            BackColor = Color.FromArgb(34, 34, 35);
            progressBar1.BackColor = Color.FromArgb(34, 34, 35);
            panel5.BackColor = Color.FromArgb(26, 26, 26);

            panel5.ForeColor = Color.White;

            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox4.BackgroundImage = Properties.Resources.dark_web;

            choosePath_button.ForeColor = Color.White;

            label3.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label4.ForeColor = Color.White;
        }

        public async void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            BackColor = Color.White;
            progressBar1.BackColor = Color.White;
            panel5.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            pictureBox4.BackgroundImage = Properties.Resources.white_back;
            choosePath_button.ForeColor = Color.Black;

            BackColor = Color.White;
            panel5.BackColor = Color.FromArgb(143, 142, 147);

            panel5.ForeColor = Color.Black;

            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox4.BackgroundImage = Properties.Resources.white_web;

            choosePath_button.ForeColor = Color.Black;

            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }

        private async void Circle()
        {
            await Task.Run(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (Properties.Settings.Default.darkTheme == true && SetupForm.darkThemeDo == true)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                DarkThemeTrue();
                            }));
                        }
                    }
                    if (Properties.Settings.Default.darkTheme == false && SetupForm.darkThemeDo == true)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                DarkThemeFalse();
                            }));
                        }
                    }
                }
            });
        }

        private void Reset()
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                DarkThemeTrue();
            }

            if (Properties.Settings.Default.darkTheme == false)
            {
                DarkThemeFalse();
            }
        }

        public static string path;
        private void choosePath_button_Click(object sender, EventArgs e)
        {
            path = "";
            label1.Text = "Проверено файлов: ";
            label2.Text = "Ошибок выявлено: ";
            count = 0;
            ercount = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            erFiles.Clear();
            label4.Text = "Идёт сканирование...";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
                SearchEr();
            }
        }

        public async void SearchEr()
        {
            await Task.Run(() =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => label3.Text = "Путь: " + path));
                    GetCountFiles(path);
                    Invoke(new Action(() => progressBar1.Maximum = countL));
                    GetRecursFiles(path);
                    if (erFiles.Count > 0)
                    {
                        CreateFile();
                    }
                    else
                    {
                        MessageBox.Show("Ошибок не обнаружено.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Invoke(new Action(() => label4.Text = ""));
                }
            });
        }

        private void CreateFile()
        {
            DateTime dateTime = DateTime.Now;
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            string newFile = @"Logs\Log " + dateTime.Day.ToString() + "_" + dateTime.Month.ToString() + "_" + dateTime.Year.ToString() + " " + dateTime.Hour.ToString() + "HH " + dateTime.Minute + "M" + ".txt";
            FileInfo fileInfo = new FileInfo(newFile);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }

            Stream myStream = File.Open(newFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter myWriter = new StreamWriter(myStream);
            for (int i = 0; i <= erFiles.Count - 1; i++)
            {
                myWriter.WriteLine(erFiles[i]);
            }

            myWriter.Close();
            myStream.Close();
            string fulPath = Path.GetFullPath(newFile);

            DialogResult res = MessageBox.Show("Просмотреть отчёт об ошибках можно в файле: " + fulPath + "\n" + "Открыть файл?", "Успешно", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Process.Start(newFile);
            }
        }

        private async void CircleLabel()
        {
            await Task.Run(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            label1.Text = "Проверено файлов: " + count.ToString();
                            label2.Text = "Ошибок выявлено: " + ercount.ToString();
                        }));
                    }
                }
            });
        }

        private static int count = 0;
        private static int ercount = 0;
        private static readonly List<string> erFiles = new List<string>();
        private List<string> GetRecursFiles(string path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    ls.AddRange((GetRecursFiles(folder)).ToArray());
                }

                string[] files = Directory.GetFiles(path);

                foreach (string filename in files)
                {
                    ls.Add(filename);
                    count++;
                    if (filename.Length >= 255)
                    {
                        erFiles.Add(filename);
                        ercount++;
                    }
                    Invoke((MethodInvoker)(() =>
                    {
                        progressBar1.Value++;
                    }));
                }
            }
            catch { }
            return ls;
        }

        public static int countL = 0;
        private List<string> GetCountFiles(string path)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    ls.AddRange((GetCountFiles(folder)).ToArray());
                }

                string[] files = Directory.GetFiles(path);

                foreach (string filename in files)
                {
                    countL++;
                }
            }
            catch { }
            return ls;
        }

        private void SearchError_FormClosing(object sender, FormClosingEventArgs e)
        {
            count = 0;
            countL = 0;
            ercount = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            erFiles.Clear();
            path = "";
            label1.Text = "Проверено файлов: ";
            label2.Text = "Ошибок выявлено: ";
        }
    }
}
