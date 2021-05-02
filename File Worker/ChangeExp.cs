using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class ChangeExp : Form
    {
        public ChangeExp()
        {
            InitializeComponent();
            Reset();
            Circle();
        }

        public string namePath;                             //Имя папки
        public static string[] files;                       //Все файлы
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public string[] filesExForChan;

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ButtonForm buttonForm = new ButtonForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X, Location.Y)
            };
            buttonForm.Show();
            Hide();
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
                pictureBox6.BackgroundImage = FileWorker.Properties.Resources.dark_close_move;
            }
            else
            {
                pictureBox6.BackgroundImage = FileWorker.Properties.Resources.white_close_move;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.dark_min_move;
            }
            else
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.white_min_move;
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.dark_min;
            }
            else
            {
                pictureBox5.BackgroundImage = FileWorker.Properties.Resources.white_min;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox6.BackgroundImage = FileWorker.Properties.Resources.dark_close;
            }
            else
            {
                pictureBox6.BackgroundImage = FileWorker.Properties.Resources.white_close;
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
                pictureBox7.BackgroundImage = FileWorker.Properties.Resources.dark_setup_move;
            }
            else
            {
                pictureBox7.BackgroundImage = FileWorker.Properties.Resources.white_settings_move;
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox7.BackgroundImage = FileWorker.Properties.Resources.dark_setup;
            }
            else
            {
                pictureBox7.BackgroundImage = FileWorker.Properties.Resources.white_setings;
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

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox8.BackgroundImage = FileWorker.Properties.Resources.dark_back_move;
            }
            else
            {
                pictureBox8.BackgroundImage = FileWorker.Properties.Resources.white_back_move;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox8.BackgroundImage = FileWorker.Properties.Resources.dark_back;
            }
            else
            {
                pictureBox8.BackgroundImage = FileWorker.Properties.Resources.white_back;
            }
        }

        public void DarkThemeTrue()
        {
            BackColor = Color.FromArgb(34, 34, 35);
            panel5.BackColor = Color.FromArgb(26, 26, 26);
            panel4.BackColor = Color.FromArgb(34, 34, 35);
            panel1.BackColor = Color.FromArgb(34, 34, 35);

            panel5.ForeColor = Color.White;
            panel4.ForeColor = Color.White;
            panel1.ForeColor = Color.White;


            pictureBox6.BackgroundImage = Properties.Resources.dark_close;
            pictureBox5.BackgroundImage = Properties.Resources.dark_min;
            pictureBox4.BackgroundImage = Properties.Resources.dark_web;
            pictureBox8.BackgroundImage = Properties.Resources.dark_back;
            pictureBox7.BackgroundImage = Properties.Resources.dark_setup;

            rename_button.ForeColor = Color.White;
            choosePath_button.ForeColor = Color.White;

            label8.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FilesListBox.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.White));
            }
            else
            {
                FilesListBox.BackColor = Color.FromArgb(34, 34, 35);
                FilesListBox.ForeColor = Color.White;
            }
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            panel4.BackColor = Color.White;
            panel1.BackColor = Color.White;
            BackColor = Color.White;
            panel5.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            pictureBox4.BackgroundImage = Properties.Resources.white_back;
            pictureBox5.BackgroundImage = Properties.Resources.white_setings;
            rename_button.ForeColor = Color.Black;
            choosePath_button.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;

            BackColor = Color.White;
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            panel4.BackColor = Color.White;
            panel1.BackColor = Color.White;

            panel5.ForeColor = Color.Black;
            panel4.ForeColor = Color.Black;
            panel1.ForeColor = Color.Black;


            pictureBox6.BackgroundImage = Properties.Resources.white_close;
            pictureBox5.BackgroundImage = Properties.Resources.white_min;
            pictureBox4.BackgroundImage = Properties.Resources.white_web;
            pictureBox8.BackgroundImage = Properties.Resources.white_back;
            pictureBox7.BackgroundImage = Properties.Resources.white_setings;

            rename_button.ForeColor = Color.Black;
            choosePath_button.ForeColor = Color.Black;

            label8.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FilesListBox.BackColor = Color.White));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.Black));
            }
            else
            {
                FilesListBox.BackColor = Color.White;
                FilesListBox.ForeColor = Color.Black;
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
                        Invoke(new Action(() => DarkThemeTrue()));
                    }

                    if (Properties.Settings.Default.darkTheme == false && SetupForm.darkThemeDo == true)
                    {
                        Invoke(new Action(() => DarkThemeFalse()));
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


        private void choosePath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (files == null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    namePath = fileDialog.SelectedPath + @"\";
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
                        rename_button.Enabled = true;
                        label3.Text = "Папка: " + namePath;
                    }
                }
            }
            else if (files != null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    FilesListBox.Items.Clear();
                    files = null;
                    namePath = fileDialog.SelectedPath + @"\";
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
                        rename_button.Enabled = true;
                        label3.Text = "Папка: " + namePath;
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали папку!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rename_button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите изменить расширения файлов?" + "\r" +
                "После того как вы нажмете на кнопку \"Да\", изменения невозможно будет вернуть.", "Согласие", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string exp = textBox1.Text;
                string expChan = textBox2.Text;
                int count = 0;
                filesExForChan = Directory.GetFiles(namePath, exp);
                if (radioButtonStart.Checked == true && filesExForChan != null)
                {
                    DirectoryInfo d = new DirectoryInfo(namePath);
                    FileInfo[] Files = d.GetFiles();

                    foreach (FileInfo file in Files)
                    {
                        string changed = Path.ChangeExtension(file.FullName, expChan);
                        File.Copy(file.FullName, changed);
                        File.Delete(file.FullName);
                        count++;
                    }
                }
                else if (radioButtonEnd.Checked == true && filesExForChan != null)
                {
                    string[] files = Directory.GetFiles(namePath, "*." + exp);

                    foreach (string file in files)
                    {
                        string changed = Path.ChangeExtension(file, expChan);
                        File.Copy(file, changed);
                        File.Delete(file);
                        count++;
                    }
                }
                FilesListBox.Items.Clear();
                files = Directory.GetFiles(namePath);
                for (int i = 0; i < files.Length; i++)
                {
                    FilesListBox.Items.Add(Path.GetFileName(files[i]));
                }

                MessageBox.Show("Успешно измененны расширения у " + count + " файлов.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void radioButtonEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEnd.Checked == true)
            {
                textBox1.Enabled = true;
            }
        }

        private void radioButtonStart_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStart.Checked == true)
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox1_EnabledChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
