using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class FtpAddProf : Form
    {
        public FtpAddProf()
        {
            InitializeComponent();
            Reset();
            Circle();
            Properties.Settings.Default.FtpAddProfAct = true;
            Properties.Settings.Default.Save();
        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        private void choosePath_button_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ftp1 == "")
            {
                Properties.Settings.Default.ftp1 = textBox1.Text;
                Properties.Settings.Default.ftpName1 = textBox2.Text;
                Properties.Settings.Default.ftpPass1 = textBox3.Text;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.ftp1 != "")
                {
                    string ftp1 = "Профиль №1 " + Properties.Settings.Default.ftpName1.ToString() + " " + Properties.Settings.Default.ftp1.ToString();
                    comboBox1.Items.Add(ftp1);
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ftp1);
                    ftpReq(Properties.Settings.Default.ftp1, Properties.Settings.Default.ftpName1, Properties.Settings.Default.ftpPass1);
                }
            }
            else if (Properties.Settings.Default.ftp2 == "")
            {
                Properties.Settings.Default.ftp2 = textBox1.Text;
                Properties.Settings.Default.ftpName2 = textBox2.Text;
                Properties.Settings.Default.ftpPass2 = textBox3.Text;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.ftp2 != "")
                {
                    string ftp2 = "Профиль №2 " + Properties.Settings.Default.ftpName2.ToString() + " " + Properties.Settings.Default.ftp2.ToString();
                    comboBox1.Items.Add(ftp2);
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ftp2);
                    ftpReq(Properties.Settings.Default.ftp2, Properties.Settings.Default.ftpName2, Properties.Settings.Default.ftpPass2);
                }
            }
            else if (Properties.Settings.Default.ftp3 == "")
            {
                Properties.Settings.Default.ftp3 = textBox1.Text;
                Properties.Settings.Default.ftpName3 = textBox2.Text;
                Properties.Settings.Default.ftpPass3 = textBox3.Text;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.ftp3 != "")
                {
                    string ftp3 = "Профиль №3 " + Properties.Settings.Default.ftpName3.ToString() + " " + Properties.Settings.Default.ftp3.ToString();
                    comboBox1.Items.Add(ftp3);
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ftp3);
                    ftpReq(Properties.Settings.Default.ftp3, Properties.Settings.Default.ftpName3, Properties.Settings.Default.ftpPass3);
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void ftpReq(string url, string username, string password)
        {
            bool pathEx = false;
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(url);
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
                for (int i = 0; i < directories.Count - 1; i++)
                {
                    if (directories[i] == "File Worker Reserv")
                    {
                        pathEx = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            if (pathEx == false)
            {
                try
                {
                    WebRequest request = WebRequest.Create(url + "/File%20Worker%20Reserv");
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    request.Credentials = new NetworkCredential(username, password);
                    using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
                    {
                        //MessageBox.Show(resp.StatusCode.ToString());
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void FtpAddProf_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ftp1 != "")
            {
                string ftp1 = "Профиль №1 " + Properties.Settings.Default.ftpName1.ToString() + " " + Properties.Settings.Default.ftp1.ToString();
                comboBox1.Items.Add(ftp1);
            }
            if (Properties.Settings.Default.ftp2 != "")
            {
                string ftp2 = "Профиль №2 " + Properties.Settings.Default.ftpName2.ToString() + " " + Properties.Settings.Default.ftp2.ToString();
                comboBox1.Items.Add(ftp2);
            }
            if (Properties.Settings.Default.ftp3 != "")
            {
                string ftp3 = "Профиль №3 " + Properties.Settings.Default.ftpName3.ToString() + " " + Properties.Settings.Default.ftp3.ToString();
                comboBox1.Items.Add(ftp3);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (Properties.Settings.Default.ftp1 != "" && Properties.Settings.Default.ftp2 != "" && Properties.Settings.Default.ftp3 != "")
            {
                addFtp_button.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prof = "";
            if (comboBox1.Text != "")
            {
                prof = comboBox1.Text.Remove(11, comboBox1.Text.Length - 11);
            }

            if (prof == "Профиль №1 ")
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Вы уверены что хотите удалить" + "\r" + comboBox1.SelectedItem.ToString(), "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.ftp1 = null;
                    Properties.Settings.Default.ftpName1 = null;
                    Properties.Settings.Default.ftpPass1 = null;
                    Properties.Settings.Default.Save();
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    comboBox1.Text = "";
                }
            }

            if (prof == "Профиль №2 ")
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Вы уверены что хотите удалить" + "\r" + comboBox1.SelectedItem.ToString(), "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.ftp2 = null;
                    Properties.Settings.Default.ftpName2 = null;
                    Properties.Settings.Default.ftpPass2 = null;
                    Properties.Settings.Default.Save();
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    comboBox1.Text = "";
                }
            }

            if (prof == "Профиль №3 ")
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Вы уверены что хотите удалить" + "\r" + comboBox1.SelectedItem.ToString(), "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.ftp3 = null;
                    Properties.Settings.Default.ftpName3 = null;
                    Properties.Settings.Default.ftpPass3 = null;
                    Properties.Settings.Default.Save();
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    comboBox1.Text = "";
                }
            }

            if (Properties.Settings.Default.ftp1 == null | Properties.Settings.Default.ftp2 == null | Properties.Settings.Default.ftp3 == null)
            {
                addFtp_button.Enabled = true;
            }
        }

        public void DarkThemeTrue()
        {
            BackColor = Color.FromArgb(34, 34, 35);
            panel5.BackColor = Color.FromArgb(26, 26, 26);

            panel5.ForeColor = Color.White;


            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox3.BackgroundImage = Properties.Resources.dark_web;
            if (textBox3.UseSystemPasswordChar == true)
            {
                pictureBox4.BackgroundImage = Properties.Resources.скрыто_black;
            }
            else
            {
                pictureBox4.BackgroundImage = Properties.Resources.показать_black;
            }

            addFtp_button.ForeColor = Color.White;
            button1.ForeColor = Color.White;

            label5.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;

            if (InvokeRequired)
            {
                Invoke(new Action(() => textBox1.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => textBox1.ForeColor = Color.White));
                Invoke(new Action(() => textBox2.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => textBox2.ForeColor = Color.White));
                Invoke(new Action(() => textBox3.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => textBox3.ForeColor = Color.White));
                Invoke(new Action(() => comboBox1.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => comboBox1.ForeColor = Color.White));
            }
            else
            {
                textBox1.BackColor = Color.FromArgb(34, 34, 35);
                textBox1.ForeColor = Color.White;
                textBox2.BackColor = Color.FromArgb(34, 34, 35);
                textBox2.ForeColor = Color.White;
                textBox3.BackColor = Color.FromArgb(34, 34, 35);
                textBox3.ForeColor = Color.White;
                comboBox1.BackColor = Color.FromArgb(34, 34, 35);
                comboBox1.ForeColor = Color.White;
            }
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            BackColor = Color.White;

            panel5.ForeColor = Color.Black;

            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            if (textBox3.UseSystemPasswordChar == true)
            {
                pictureBox4.BackgroundImage = Properties.Resources.скрыто_white;
            }
            else
            {
                pictureBox4.BackgroundImage = Properties.Resources.показать_white;
            }

            addFtp_button.ForeColor = Color.Black;
            button1.ForeColor = Color.Black;

            label5.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            if (InvokeRequired)
            {
                Invoke(new Action(() => textBox1.BackColor = Color.White));
                Invoke(new Action(() => textBox1.ForeColor = Color.Black));
                Invoke(new Action(() => textBox2.BackColor = Color.White));
                Invoke(new Action(() => textBox2.ForeColor = Color.Black));
                Invoke(new Action(() => textBox3.BackColor = Color.White));
                Invoke(new Action(() => textBox3.ForeColor = Color.Black));
                Invoke(new Action(() => comboBox1.BackColor = Color.White));
                Invoke(new Action(() => comboBox1.ForeColor = Color.Black));
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
                textBox3.BackColor = Color.White;
                textBox3.ForeColor = Color.Black;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://fileworker.net");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox3.UseSystemPasswordChar == true)
            {
                textBox3.UseSystemPasswordChar = false;
                if (Properties.Settings.Default.darkTheme == true)
                {
                    pictureBox4.BackgroundImage = Properties.Resources.показать_black;
                }
                else
                {
                    pictureBox4.BackgroundImage = Properties.Resources.показать_white;
                }
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                if (Properties.Settings.Default.darkTheme == true)
                {
                    pictureBox4.BackgroundImage = Properties.Resources.скрыто_black;
                }
                else
                {
                    pictureBox4.BackgroundImage = Properties.Resources.скрыто_white;
                }
            }
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

        private void FtpAddProf_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FtpAddProfAct = false;
            Properties.Settings.Default.Save();
        }
    }
}
