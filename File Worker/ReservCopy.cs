using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class ReservCopy : Form
    {
        public ReservCopy()
        {
            InitializeComponent();
            Reset();
            Circle();
        }

        public string namePathWithFiles;                    //Имя папки с файлами
        public string namePathForCopy;                      //Имя папки для копирования
        public static string[] files;                       //Все файлы
        public static string[] filesCopy;                   //Файлы в папке для копирования
        public static string[] filesNameForCopy;                   //Название файлов без папки
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public List<string> filesArr;
        public bool pathCopy = false;
        public bool pathForCopy = false;
        public string FTPprofile = "";

        private void choosePath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (files == null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    pathCopy = true;
                    namePathWithFiles = fileDialog.SelectedPath + @"\";
                    files = Directory.GetFiles(fileDialog.SelectedPath);

                    if (files.Length == 0)
                    {
                        MessageBox.Show("Не найдено ни одного файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            string file = Path.GetFileName(files[i]);
                            FilesListBox.Items.Add(file);
                            FilesListBox.Sorted = true;
                        }
                        label2.Text = "Папка: " + namePathWithFiles;
                    }
                }
            }
            else if (files != null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    pathCopy = true;
                    FilesListBox.Items.Clear();
                    files = null;
                    namePathWithFiles = fileDialog.SelectedPath + @"\";
                    files = Directory.GetFiles(fileDialog.SelectedPath);

                    if (files.Length == 0)
                    {
                        MessageBox.Show("Не найдено ни одного файла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            string file = Path.GetFileName(files[i]);
                            FilesListBox.Items.Add(file);
                        }
                        label2.Text = "Папка: " + namePathWithFiles;
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали папку!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (filesCopy == null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    pathForCopy = true;
                    namePathForCopy = fileDialog.SelectedPath;
                    filesCopy = Directory.GetFiles(fileDialog.SelectedPath);

                    if (filesCopy.Length != 0)
                    {
                        DialogResult dialog = new DialogResult();
                        dialog = MessageBox.Show("В папке уже умеются файлы!" + "\r" + "Записать файлы?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            for (int i = 0; i < filesCopy.Length; i++)
                            {
                                string file = Path.GetFileName(filesCopy[i]);
                                listBox1.Items.Add(file);
                            }
                            label3.Text = "Папка: " + namePathForCopy;
                        }
                    }
                    else
                    {
                        label3.Text = "Папка: " + namePathForCopy;
                    }
                }
                if (label2.Text == label3.Text)
                {
                    MessageBox.Show("Выбраны одинаковые папки!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (filesCopy != null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    listBox1.Items.Clear();
                    filesCopy = null;
                    namePathForCopy = fileDialog.SelectedPath;
                    filesCopy = Directory.GetFiles(fileDialog.SelectedPath);

                    if (filesCopy.Length != 0)
                    {
                        DialogResult dialog = new DialogResult();
                        dialog = MessageBox.Show("В папке уже умеются файлы!" + "\r" + "Записать файлы?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            for (int i = 0; i < filesCopy.Length; i++)
                            {
                                string file = Path.GetFileName(filesCopy[i]);
                                listBox1.Items.Add(file);
                            }
                            label3.Text = "Папка: " + namePathForCopy;
                        }
                    }
                    else
                    {
                        label3.Text = "Папка: " + namePathForCopy;
                    }
                }
                if (label2.Text == label3.Text)
                {
                    MessageBox.Show("Выбраны одинаковые папки!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали папку!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                pictureBox3.BackgroundImage = FileWorker.Properties.Resources.dark_web_move;
            }
            else
            {
                pictureBox3.BackgroundImage = FileWorker.Properties.Resources.white_web_move;
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox3.BackgroundImage = FileWorker.Properties.Resources.dark_web;
            }
            else
            {
                pictureBox3.BackgroundImage = FileWorker.Properties.Resources.white_web;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://fileworker.net");
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_back_move;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_back_move;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_back;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_back;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ButtonForm buttonForm = new ButtonForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X, Location.Y)
            };
            buttonForm.Show();
            Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SetupFormAct == false)
            {
                SetupForm setupForm = new SetupForm();
                setupForm.Show();
            }
            else if (Properties.Settings.Default.SetupFormAct == true)
            {
                SetupForm setupForm = new SetupForm();
                setupForm.Focus();
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.dark_setup_move;
            }
            else
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.white_settings_move;
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.dark_setup;
            }
            else
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.white_setings;
            }
        }

        public void DarkThemeTrue()
        {
            BackColor = Color.FromArgb(34, 34, 35);
            panel5.BackColor = Color.FromArgb(26, 26, 26);
            panel1.BackColor = Color.FromArgb(34, 34, 35);

            panel5.ForeColor = Color.White;
            panel1.ForeColor = Color.White;

            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox3.BackgroundImage = Properties.Resources.dark_web;
            pictureBox4.BackgroundImage = Properties.Resources.dark_back;
            pictureBox5.BackgroundImage = Properties.Resources.dark_setup;

            choosePath_button.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;

            label6.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;

            radioButton1.ForeColor = Color.White;
            radioButton2.ForeColor = Color.White;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FilesListBox.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.White));
                Invoke(new Action(() => listBox1.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => listBox1.ForeColor = Color.White));
                Invoke(new Action(() => comboBox1.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => comboBox1.ForeColor = Color.White));
            }
            else
            {
                FilesListBox.BackColor = Color.FromArgb(34, 34, 35);
                FilesListBox.ForeColor = Color.White;
                listBox1.BackColor = Color.FromArgb(34, 34, 35);
                listBox1.ForeColor = Color.White;
                comboBox1.BackColor = Color.FromArgb(34, 34, 35);
                comboBox1.ForeColor = Color.White;
            }
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            panel1.BackColor = Color.White;
            BackColor = Color.White;

            panel5.ForeColor = Color.Black;
            panel1.ForeColor = Color.Black;

            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            pictureBox4.BackgroundImage = Properties.Resources.white_back;
            pictureBox5.BackgroundImage = Properties.Resources.white_setings;

            choosePath_button.ForeColor = Color.Black;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;

            label6.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FilesListBox.BackColor = Color.White));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.Black));
                Invoke(new Action(() => listBox1.BackColor = Color.White));
                Invoke(new Action(() => listBox1.ForeColor = Color.Black));
                Invoke(new Action(() => comboBox1.BackColor = Color.White));
                Invoke(new Action(() => comboBox1.ForeColor = Color.Black));
            }
            else
            {
                FilesListBox.BackColor = Color.White;
                FilesListBox.ForeColor = Color.Black;
                listBox1.BackColor = Color.White;
                listBox1.ForeColor = Color.Black;
                comboBox1.BackColor = Color.White;
                comboBox1.ForeColor = Color.Black;
            }
        }

        private async void Circle()
        {
            await Task.Run(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (pathCopy == true && pathForCopy == true)
                    {
                        Invoke(new Action(() => button3.Enabled = true));
                    }

                    if (Properties.Settings.Default.darkTheme == true && SetupForm.darkThemeDo == true)
                    {
                        DarkThemeTrue();
                    }

                    if (Properties.Settings.Default.darkTheme == false && SetupForm.darkThemeDo == true)
                    {
                        DarkThemeFalse();
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

        private void button2_Click(object sender, EventArgs e)
        {
            FtpAddProf ftpAdd = new FtpAddProf();
            ftpAdd.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Enabled = true;
                comboBox1.Enabled = false;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                button2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                button1.Enabled = false;
                comboBox1.Enabled = true;
                button2.Enabled = true;
                if (comboBox1.Enabled == true)
                {
                    if (Properties.Settings.Default.ftp1true == true)
                    {
                        string ftp1 = "Профиль №1 " + Properties.Settings.Default.ftpName1.ToString() + " " + Properties.Settings.Default.ftp1.ToString();
                        comboBox1.Items.Add(ftp1);
                    }
                    if (Properties.Settings.Default.ftp2true == true)
                    {
                        string ftp2 = "Профиль №2 " + Properties.Settings.Default.ftpName2.ToString() + " " + Properties.Settings.Default.ftp2.ToString();
                        comboBox1.Items.Add(ftp2);
                    }
                    if (Properties.Settings.Default.ftp3true == true)
                    {
                        string ftp3 = "Профиль №3 " + Properties.Settings.Default.ftpName3.ToString() + " " + Properties.Settings.Default.ftp3.ToString();
                        comboBox1.Items.Add(ftp3);
                    }
                    comboBox1.Text = "Выберите FTP профиль";
                }
            }
            label3.Text = "Папка для копирования не выбрана";
            listBox1.Items.Clear();
        }

        private void ReservCopy_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Enabled = true;
                comboBox1.Enabled = false;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                button2.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pathForCopy = true;
            if (comboBox1.Text != "")
            {
                FTPprofile = comboBox1.Text.Remove(11, comboBox1.Text.Length - 11);
            }

            if (FTPprofile == "Профиль №1 ")
            {
                label3.Text = Properties.Settings.Default.ftp1 + "/File Worker Reserv";
                ftpCheckFiles(Properties.Settings.Default.ftp1, Properties.Settings.Default.ftpName1, Properties.Settings.Default.ftpPass1);
            }
            else if (FTPprofile == "Профиль №2 ")
            {
                label3.Text = Properties.Settings.Default.ftp2 + "/File Worker Reserv";
                ftpCheckFiles(Properties.Settings.Default.ftp2, Properties.Settings.Default.ftpName2, Properties.Settings.Default.ftpPass2);
            }
            else if (FTPprofile == "Профиль №3 ")
            {
                label3.Text = Properties.Settings.Default.ftp3 + "/File Worker Reserv";
                ftpCheckFiles(Properties.Settings.Default.ftp3, Properties.Settings.Default.ftpName3, Properties.Settings.Default.ftpPass3);
            }
        }

        private void ftpCheckFiles(string url, string username, string password)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(url + "/File%20Worker%20Reserv");
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
                if (directories.Count > 0)
                {
                    MessageBox.Show("В папке уже умеются файлы!" + "\r" + "Записать файлы?", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                for (int i = 0; i < directories.Count - 1; i++)
                {
                    listBox1.Items.Add(directories[i]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string file = Path.GetFileName(files[i]);
                    File.Copy(files[i], namePathForCopy + @"\\" + file, true);
                }
                string[] filesDoCopy = Directory.GetFiles(namePathForCopy);
                for (int i = 0; i < filesDoCopy.Length; i++)
                {
                    string f = Path.GetFileName(filesDoCopy[i]);
                    listBox1.Items.Add(f);
                }
                MessageBox.Show("Резервное копирование выполнено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton2.Checked == true)
            {
                string url = "";
                string username = "";
                string password = "";
                if (FTPprofile == "Профиль №1 ")
                {
                    url = Properties.Settings.Default.ftp1;
                    username = Properties.Settings.Default.ftpName1;
                    password = Properties.Settings.Default.ftpPass1;
                }
                if (FTPprofile == "Профиль №2 ")
                {
                    url = Properties.Settings.Default.ftp2;
                    username = Properties.Settings.Default.ftpName2;
                    password = Properties.Settings.Default.ftpPass2;
                }
                if (FTPprofile == "Профиль №3 ")
                {
                    url = Properties.Settings.Default.ftp3;
                    username = Properties.Settings.Default.ftpName3;
                    password = Properties.Settings.Default.ftpPass3;
                }
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(files[i]);
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(url + "/File%20Worker%20Reserv/" + Path.GetFileName(files[i])));
                    request.Credentials = new NetworkCredential(username, password);
                    request.KeepAlive = true;
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;
                    request.ContentLength = fileInfo.Length;
                    int buffLength = 2048;
                    byte[] buff = new byte[buffLength];
                    int contentLen;
                    FileStream stream = fileInfo.OpenRead();
                    try
                    {
                        Stream strm = request.GetRequestStream();
                        contentLen = stream.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = stream.Read(buff, 0, buffLength);
                        }
                        strm.Close();
                        stream.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
                MessageBox.Show("Резервное копирование выполнено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
