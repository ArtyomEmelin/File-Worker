using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class ButtonForm : Form
    {
        public ButtonForm()
        {
            InitializeComponent();
            Reset();
            Circle();
        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        private void ButtonForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = Location;
        }

        private void ButtonForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Location = Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void ButtonForm_MouseUp(object sender, MouseEventArgs e)
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

        private void choosePath_button_Click(object sender, EventArgs e)
        {
            RenameForm renameForm = new RenameForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X, Location.Y)
            };
            renameForm.Show();
            Hide();
        }

        private void rename_button_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Переименовывает ваши файлы в выбраной папке, " + "\r" + "шаблону. Вы можете настроить шаблон самостоятельно." + "\r" + "Есть возможность добавлять различные даты к имени " + "\r" + "файла, имя пользователя, уникателньый индентификатор," + "\r" + "стирать или оставлять старое название.";
        }

        private void reserve_button_Click(object sender, EventArgs e)
        {
            ReservCopy reservCopy = new ReservCopy
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X, Location.Y)
            };
            reservCopy.Show();
            Hide();
        }

        private void reserve_button_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Возможность сделать резервное копирование." + "\r" + "Вы выбираете куда делать резервное копирование, " + "\r" + "либо локально на вашем ПК, либо на FTP сервер.";
        }

        private void reserve_button_MouseLeave(object sender, EventArgs e)
        {
            label10.Text = "Наведите на любую кнопку и здесь появится описание.";
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_setup_move;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_settings_move;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkTheme == true)
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.dark_setup;
            }
            else
            {
                pictureBox4.BackgroundImage = FileWorker.Properties.Resources.white_setings;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
            //if (Properties.Settings.Default.SetupFormAct == false)
            //{
            //    SetupForm setupForm = new SetupForm();
            //    setupForm.Show();
            //}
            //else if (Properties.Settings.Default.SetupFormAct == true)
            //{
            //    SetupForm setupForm = new SetupForm();
            //    setupForm.Focus();
            //}
        }

        public void DarkThemeTrue()
        {
            panel5.BackColor = Color.FromArgb(26, 26, 26);
            panel5.ForeColor = Color.White;
            BackColor = Color.FromArgb(34, 34, 35);
            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox3.BackgroundImage = Properties.Resources.dark_web;
            pictureBox4.BackgroundImage = Properties.Resources.dark_setup;
            rename_button.ForeColor = Color.White;
            reserve_button.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            BackColor = Color.White;
            panel5.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            pictureBox4.BackgroundImage = Properties.Resources.white_setings;
            rename_button.ForeColor = Color.Black;
            reserve_button.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeExp changeExp = new ChangeExp
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X, Location.Y)
            };
            changeExp.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchError searchError = new SearchError
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            searchError.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            reference.Show();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Возможность изменить расширения файлов. Вы можете" + "\r" + "выбрать два способа изменения расширений, либо" + "\r" + "изменить определенные расширения, либо все сразу.";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Выбрав папку, программа автоматически начнет" + "\r" + "поиск ошибок в данной папке, при помощи рекурсии." + "\r" + "Если путь и имя файла вместе взятых длинее более чем" + "\r" + "на 255 символов Windows откзывается работать с" + "\r" + "такими файлами.";
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = "Здесь вы можете более подробно ознакомиться" + "\r" + "с приложение File Worker.";
        }
    }
}
