using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
            Reset();
            Circle();
            Properties.Settings.Default.SetupFormAct = true;
            Properties.Settings.Default.Save();
        }

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public static bool darkThemeDo = false;

        private void ButtonForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void ButtonForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Location = Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void ButtonForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            ButtonForm buttonForm = new ButtonForm();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (FileWorker.Properties.Settings.Default.darkTheme == false)
            {
                Properties.Settings.Default.darkTheme = true;
                Properties.Settings.Default.Save();
                darkThemeDo = true;
            }
            else
            {
                Properties.Settings.Default.darkTheme = false;
                Properties.Settings.Default.Save();
                darkThemeDo = true;
            }
        }

        public void DarkThemeTrue()
        {
            panel5.BackColor = Color.FromArgb(26, 26, 26);
            panel5.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            BackColor = Color.FromArgb(34, 34, 35);
            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox3.BackgroundImage = FileWorker.Properties.Resources.dark_true;
            darkThemeDo = false;
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            BackColor = Color.White;
            panel5.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = FileWorker.Properties.Resources.white_false;
            darkThemeDo = false;
        }

        private async void Circle()
        {
            await Task.Run(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (Properties.Settings.Default.darkTheme == true && darkThemeDo == true)
                    {
                        DarkThemeTrue();
                    }

                    if (Properties.Settings.Default.darkTheme == false && darkThemeDo == true)
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

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SetupFormAct = false;
            Properties.Settings.Default.Save();
        }
    }
}
