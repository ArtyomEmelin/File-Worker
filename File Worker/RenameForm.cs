using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorker
{
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
            Reset();
            Circle();
        }

        public string namePath;                             //Имя папки
        public static string[] files;                       //Все файлы
        public string[] filesWithOutExtension;              //Название файлов без расширений
        public string[] Extension;                          //Расширения файлов
        public string userName = Environment.UserName;      //
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public static string[] filesReserved;               //Резервное копирование файлов


        public void RenanameFilesWithNewText() //Переименование если стирается старое название
        {

            if (files.Length >= 1)
            {
                FilesListBox.Items.Clear();

                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (AddNumberFile.Text != null)
                        {
                            AddNumberForFiles();
                            if (AddNameFiles.Text != null)
                            {
                                AddNewNameForFiles();
                                if (DateCheckBox.Checked | FileCreationDateСheckBox.Checked | FileModificationDateCheckBox.Checked == true)
                                {
                                    if (DateRadioButtonStart.Checked == true)
                                    {
                                        AddDateForFiles();
                                        if (UserNameCheckBox.Checked == true)
                                        {
                                            AddUserNameForFiles();
                                        }
                                    }
                                    else if (DateRadioButtonEnd.Checked == true)
                                    {
                                        if (UserNameCheckBox.Checked == true)
                                        {
                                            AddUserNameForFiles();
                                            AddDateForFiles();
                                        }
                                    }
                                }
                                else if (UserNameCheckBox.Checked == true)
                                {
                                    AddUserNameForFiles();
                                }
                            }
                        }
                    }
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);
                        FilesListBox.Items.Add(fileInfo.Name);
                    }
                }
                catch
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (File.Exists(files[i]) | File.Exists(filesReserved[i]))
                        {
                            File.Move(files[i], filesReserved[i]);
                        }
                    }
                    MessageBox.Show("Извините но что-то пошло не так, попробуйте повторить действие или перезапустить программу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AddNewNameForFiles()//ДОБАВЛЯТЬ НОВОЕ ИМЯ К ФАЙЛУ
        {
            string newNameFile = AddNameFiles.Text;

            for (int i = 0; i < files.Length; i++)
            {
                string nameExtension = Path.GetExtension(files[i]);
                string nameFile = Path.GetFileNameWithoutExtension(files[i]);
                if (radioButtonStart.Checked == true)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        string newName = namePath + nameFile + " " + newNameFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else
                    {
                        string newName = namePath + newNameFile + " " + nameFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                }
                else if (radioButtonEnd.Checked == true)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        string newName = namePath + nameFile + " " + newNameFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else
                    {
                        string newName = namePath + newNameFile + " " + nameFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                }
            }
        }

        public void AddUserNameForFiles()//ДОБАВЛЯТЬ ИМЯ ПОЛЬЗОВАТЕЛЯ К ФАЙЛАМ
        {
            for (int i = 0; i < files.Length; i++)
            {
                string nameExtension = Path.GetExtension(files[i]);
                string nameFile = Path.GetFileNameWithoutExtension(files[i]);
                if (UserNameRadioButtonStart.Checked == true)
                {
                    string newName = namePath + nameFile + " " + userName + nameExtension;
                    File.Move(files[i], newName);
                    files[i] = newName;
                }
                else if (UserNameRadioButtonEnd.Checked == true)
                {
                    string newName = namePath + nameFile + " " + userName + nameExtension;
                    File.Move(files[i], newName);
                    files[i] = newName;
                }
            }
        }

        public void AddNumberForFiles() //ДОБАВЛЯТЬ НОМЕР К ФАЙЛАМ
        {
            int numberForFile = Convert.ToInt32(AddNumberFile.Text);
            for (int i = 0; i < files.Length; i++)
            {
                string nameExtension = Path.GetExtension(files[i]);
                string nameFile = Path.GetFileNameWithoutExtension(files[i]);
                if (EraseCheckBox.Checked == true)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        string newName = namePath + numberForFile + "." + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else if (NumberForFileEnd.Checked == true)
                    {
                        string newName = namePath + "№" + numberForFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                }
                else if (EraseCheckBox.Checked == false)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        string newName = namePath + numberForFile + "." + nameFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else if (NumberForFileEnd.Checked == true)
                    {
                        string newName = namePath + nameFile + "№" + numberForFile + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                }
                numberForFile++;
            }
        }

        public void AddDateForFiles() //ДОБАВЛЯТЬ ДАТУ К ФАЙЛАМ
        {
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo dateFile = new FileInfo(files[i]);
                string dateCreate = dateFile.CreationTime.Day + "." + dateFile.CreationTime.Month + "." + dateFile.CreationTime.Year + " " + dateFile.CreationTime.Hour + " HH " + dateFile.CreationTime.Minute + " mm";
                string dateModification = dateFile.LastWriteTime.Day + "." + dateFile.LastWriteTime.Month + "." + dateFile.LastWriteTime.Year + " " + dateFile.LastWriteTime.Hour + " HH " + dateFile.LastWriteTime.Minute + " mm";

                string nameExtension = Path.GetExtension(files[i]);
                string nameFile = Path.GetFileNameWithoutExtension(files[i]);

                if (FileCreationDateСheckBox.Checked == true)
                {
                    if (nameFile.Length > 1)
                    {
                        string newName = namePath + nameFile + " " + dateCreate + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else if (nameFile.Length == 1)
                    {
                        if (DateRadioButtonStart.Checked == true)
                        {
                            string newName = namePath + dateCreate + nameExtension;
                            File.Move(files[i], newName);
                            files[i] = newName;
                        }
                    }
                }
                else if (FileModificationDateCheckBox.Checked == true)
                {
                    if (nameFile.Length > 1)
                    {
                        string newName = namePath + nameFile + " " + dateModification + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else if (nameFile.Length == 1)
                    {
                        if (DateRadioButtonStart.Checked == true)
                        {
                            string newName = namePath + nameFile + dateModification + nameExtension;
                            File.Move(files[i], newName);
                            files[i] = newName;
                        }
                    }
                }
                else if (DateCheckBox.Checked == true)
                {
                    DateTime userdateTimeConv = Convert.ToDateTime(DateTimeMaskedTextBox.Text);
                    string userDateTime = userdateTimeConv.Day + "." + userdateTimeConv.Month + "." + userdateTimeConv.Year + " " + userdateTimeConv.Hour + " HH " + userdateTimeConv.Minute + " mm";

                    if (nameFile.Length > 1)
                    {
                        string newName = namePath + nameFile + " " + userDateTime + nameExtension;
                        File.Move(files[i], newName);
                        files[i] = newName;
                    }
                    else if (nameFile.Length == 1)
                    {
                        if (DateRadioButtonStart.Checked == true)
                        {
                            string newName = namePath + nameFile + userDateTime + nameExtension;
                            File.Move(files[i], newName);
                            files[i] = newName;
                        }
                    }
                }
            }
        }

        public void preview()
        {
            int numberForFile = Convert.ToInt32(AddNumberFile.Text);
            string nameFile = "";
            string nameExtension = "";
            label10.Text = "";

            if (files == null)
            {
                nameExtension = ".txt";
            }
            else
            {
                nameExtension = Path.GetExtension(files[1]);
            }

            if (files == null)
            {
                nameFile = "ПРИМЕР ";
            }
            else
            {
                nameFile = Path.GetFileNameWithoutExtension(files[1]);
            }

            if (AddNumberFile.Text != null)
            {
                if (EraseCheckBox.Checked == true)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        nameFile = numberForFile + ".";
                    }
                    else if (NumberForFileEnd.Checked == true)
                    {
                        nameFile = "№" + numberForFile;
                    }
                }
                else if (EraseCheckBox.Checked == false)
                {
                    if (NumberForFileStart.Checked == true)
                    {
                        nameFile = numberForFile + "." + nameFile;
                    }
                    else if (NumberForFileEnd.Checked == true)
                    {
                        nameFile = nameFile + "№" + numberForFile;
                    }
                }
                if (AddNameFiles.Text != null)
                {
                    string newNameFile = AddNameFiles.Text;
                    if (radioButtonStart.Checked == true)
                    {
                        if (NumberForFileStart.Checked == true)
                        {
                            nameFile = nameFile + " " + newNameFile;
                        }
                        else
                        {
                            nameFile = newNameFile + " " + nameFile;
                        }
                    }
                    else if (radioButtonEnd.Checked == true)
                    {
                        if (NumberForFileStart.Checked == true)
                        {
                            nameFile = nameFile + " " + newNameFile;
                        }
                        else
                        {
                            nameFile = newNameFile + " " + nameFile;
                        }
                    }
                    if (DateCheckBox.Checked | FileCreationDateСheckBox.Checked | FileModificationDateCheckBox.Checked == true)
                    {
                        if (DateRadioButtonStart.Checked == true)
                        {
                            string dateCreate = "";
                            string dateModification = "";
                            if (files == null)
                            {
                                dateCreate = DateTime.Now.ToString();
                                dateModification = DateTime.Now.ToString();
                            }
                            else
                            {
                                FileInfo dateFile = new FileInfo(files[1]);
                                dateCreate = dateFile.CreationTime.Day + "." + dateFile.CreationTime.Month + "." + dateFile.CreationTime.Year + " " + dateFile.CreationTime.Hour + " HH " + dateFile.CreationTime.Minute + " mm";
                                dateModification = dateFile.LastWriteTime.Day + "." + dateFile.LastWriteTime.Month + "." + dateFile.LastWriteTime.Year + " " + dateFile.LastWriteTime.Hour + " HH " + dateFile.LastWriteTime.Minute + " mm";
                            }

                            if (FileCreationDateСheckBox.Checked == true)
                            {
                                if (nameFile.Length > 1)
                                {
                                    nameFile = nameFile + " " + dateCreate;
                                }
                                else if (nameFile.Length == 1)
                                {
                                    if (DateRadioButtonStart.Checked == true)
                                    {
                                        nameFile = namePath + dateCreate + nameExtension;
                                    }
                                }
                            }
                            else if (FileModificationDateCheckBox.Checked == true)
                            {
                                if (nameFile.Length > 1)
                                {
                                    nameFile = nameFile + " " + dateModification;
                                }
                                else if (nameFile.Length == 1)
                                {
                                    if (DateRadioButtonStart.Checked == true)
                                    {
                                        nameFile = nameFile + dateModification;
                                    }
                                }
                            }
                            else if (DateCheckBox.Checked == true)
                            {
                                try
                                {
                                    DateTime userdateTimeConv = Convert.ToDateTime(DateTimeMaskedTextBox.Text);
                                    string userDateTime = userdateTimeConv.Day + "." + userdateTimeConv.Month + "." + userdateTimeConv.Year + " " + userdateTimeConv.Hour + " HH " + userdateTimeConv.Minute + " mm";

                                    if (nameFile.Length > 1)
                                    {
                                        nameFile = nameFile + " " + userDateTime;
                                    }
                                    else if (nameFile.Length == 1)
                                    {
                                        if (DateRadioButtonStart.Checked == true)
                                        {
                                            nameFile = nameFile + userDateTime;
                                        }
                                    }
                                }
                                catch { }
                            }
                            if (UserNameCheckBox.Checked == true)
                            {
                                if (UserNameRadioButtonStart.Checked == true)
                                {
                                    nameFile = nameFile + " " + userName;
                                }
                                else if (UserNameRadioButtonEnd.Checked == true)
                                {
                                    nameFile = nameFile + " " + userName;
                                }
                            }
                        }
                        else if (DateRadioButtonEnd.Checked == true)
                        {
                            if (UserNameCheckBox.Checked == true)
                            {
                                if (UserNameRadioButtonStart.Checked == true)
                                {
                                    nameFile = nameFile + " " + userName;
                                }
                                else if (UserNameRadioButtonEnd.Checked == true)
                                {
                                    nameFile = nameFile + " " + userName;
                                }

                                string dateCreate = "";
                                string dateModification = "";
                                if (files == null)
                                {
                                    dateCreate = DateTime.Now.ToString();
                                    dateModification = DateTime.Now.ToString();
                                }
                                else
                                {
                                    FileInfo dateFile = new FileInfo(files[1]);
                                    dateCreate = dateFile.CreationTime.Day + "." + dateFile.CreationTime.Month + "." + dateFile.CreationTime.Year + " " + dateFile.CreationTime.Hour + " HH " + dateFile.CreationTime.Minute + " mm";
                                    dateModification = dateFile.LastWriteTime.Day + "." + dateFile.LastWriteTime.Month + "." + dateFile.LastWriteTime.Year + " " + dateFile.LastWriteTime.Hour + " HH " + dateFile.LastWriteTime.Minute + " mm";
                                }

                                if (FileCreationDateСheckBox.Checked == true)
                                {
                                    if (nameFile.Length > 1)
                                    {
                                        nameFile = nameFile + " " + dateCreate;
                                    }
                                    else if (nameFile.Length == 1)
                                    {
                                        if (DateRadioButtonStart.Checked == true)
                                        {
                                            nameFile = namePath + dateCreate;
                                        }
                                    }
                                }
                                else if (FileModificationDateCheckBox.Checked == true)
                                {
                                    if (nameFile.Length > 1)
                                    {
                                        nameFile = nameFile + " " + dateModification;
                                    }
                                    else if (nameFile.Length == 1)
                                    {
                                        if (DateRadioButtonStart.Checked == true)
                                        {
                                            nameFile = nameFile + dateModification;
                                        }
                                    }
                                }
                                else if (DateCheckBox.Checked == true)
                                {
                                    try
                                    {
                                        DateTime userdateTimeConv = Convert.ToDateTime(DateTimeMaskedTextBox.Text);
                                        string userDateTime = userdateTimeConv.Day + "." + userdateTimeConv.Month + "." + userdateTimeConv.Year + " " + userdateTimeConv.Hour + " HH " + userdateTimeConv.Minute + " mm";

                                        if (nameFile.Length > 1)
                                        {
                                            nameFile = nameFile + " " + userDateTime;
                                        }
                                        else if (nameFile.Length == 1)
                                        {
                                            if (DateRadioButtonStart.Checked == true)
                                            {
                                                nameFile = nameFile + userDateTime;
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    else if (UserNameCheckBox.Checked == true)
                    {
                        if (UserNameRadioButtonStart.Checked == true)
                        {
                            nameFile = nameFile + " " + userName;
                        }
                        else if (UserNameRadioButtonEnd.Checked == true)
                        {
                            nameFile = nameFile + " " + userName;
                        }
                    }
                }
            }
            label10.Text = nameFile + nameExtension;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) //UserNameCheckBox.Checked
        {
            if (UserNameCheckBox.Checked == true)
            {
                UserNameRadioButtonStart.Enabled = true;
                UserNameRadioButtonEnd.Enabled = true;
                UserNameRadioButtonStart.Checked = true;
                UserNameRadioButtonEnd.Checked = false;
            }
            else
            {
                UserNameRadioButtonStart.Enabled = false;
                UserNameRadioButtonEnd.Enabled = false;
                UserNameRadioButtonStart.Checked = false;
                UserNameRadioButtonEnd.Checked = false;
            }
            preview();
        }

        private void choosePath_Click(object sender, EventArgs e) // Выбор папки и вывод в FilesListBox
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (files == null)
            {
                if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.SelectedPath))
                {
                    namePath = fileDialog.SelectedPath + @"\";
                    files = Directory.GetFiles(fileDialog.SelectedPath);
                    filesReserved = Directory.GetFiles(fileDialog.SelectedPath);

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
                    filesReserved = Directory.GetFiles(fileDialog.SelectedPath);

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

        private void rename_button_Click(object sender, EventArgs e) //Кнопка переименовать
        {
            RenanameFilesWithNewText();
        }

        private void FileCreationDateСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileCreationDateСheckBox.Checked == true)
            {
                FileModificationDateCheckBox.Checked = false;
                DateCheckBox.Checked = false;
                DateTimeMaskedTextBox.Enabled = false;
                DateRadioButtonStart.Enabled = true;
                DateRadioButtonEnd.Enabled = true;
                DateRadioButtonStart.Checked = true;
            }
            else
            {
                FileCreationDateСheckBox.Checked = false;
                DateRadioButtonStart.Enabled = false;
                DateRadioButtonEnd.Enabled = false;
                DateRadioButtonStart.Checked = false;
                DateRadioButtonEnd.Checked = false;
            }
            preview();
        }

        private void FileModificationDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileModificationDateCheckBox.Checked == true)
            {
                FileCreationDateСheckBox.Checked = false;
                DateCheckBox.Checked = false;
                DateTimeMaskedTextBox.Enabled = false;
                DateRadioButtonStart.Enabled = true;
                DateRadioButtonEnd.Enabled = true;
                DateRadioButtonStart.Checked = true;
            }
            else
            {
                FileModificationDateCheckBox.Checked = false;
                DateRadioButtonStart.Enabled = false;
                DateRadioButtonEnd.Enabled = false;
                DateRadioButtonStart.Checked = false;
                DateRadioButtonEnd.Checked = false;
            }
            preview();
        }

        private void DateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateCheckBox.Checked == true)
            {
                FileModificationDateCheckBox.Checked = false;
                FileCreationDateСheckBox.Checked = false;
                DateTimeMaskedTextBox.Enabled = false;
                DateRadioButtonStart.Enabled = true;
                DateRadioButtonEnd.Enabled = true;
                DateTimeMaskedTextBox.Enabled = true;
                DateTime dateTime = DateTime.Now;
                DateTimeMaskedTextBox.Text = dateTime.ToString("dd.MM.yyyy hh:mm:ss");
                DateRadioButtonStart.Checked = true;
            }
            else
            {
                DateCheckBox.Checked = false;
                DateTimeMaskedTextBox.Enabled = false;
                DateRadioButtonStart.Enabled = false;
                DateRadioButtonEnd.Enabled = false;
                DateTimeMaskedTextBox.Enabled = false;
                DateTimeMaskedTextBox.Clear();
                DateRadioButtonStart.Checked = false;
                DateRadioButtonEnd.Checked = false;
            }
            preview();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void radioButtonEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (UserNameCheckBox.Checked == true)
            {
                UserNameRadioButtonStart.Enabled = true;
                UserNameRadioButtonEnd.Enabled = true;
                UserNameRadioButtonStart.Checked = true;
            }
            else
            {
                UserNameRadioButtonStart.Checked = false;
                UserNameRadioButtonEnd.Checked = false;
                UserNameRadioButtonStart.Enabled = false;
                UserNameRadioButtonEnd.Enabled = false;
            }
            preview();
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

        private void preview(object sender, EventArgs e)
        {
            preview();
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
            panel4.BackColor = Color.FromArgb(34, 34, 35);
            panel3.BackColor = Color.FromArgb(34, 34, 35);
            panel2.BackColor = Color.FromArgb(34, 34, 35);
            panel1.BackColor = Color.FromArgb(34, 34, 35);

            panel5.ForeColor = Color.White;
            panel4.ForeColor = Color.White;
            panel3.ForeColor = Color.White;
            panel2.ForeColor = Color.White;
            panel1.ForeColor = Color.White;


            pictureBox1.BackgroundImage = Properties.Resources.dark_close;
            pictureBox2.BackgroundImage = Properties.Resources.dark_min;
            pictureBox3.BackgroundImage = Properties.Resources.dark_web;
            pictureBox4.BackgroundImage = Properties.Resources.dark_back;
            pictureBox5.BackgroundImage = Properties.Resources.dark_setup;

            rename_button.ForeColor = Color.White;
            choosePath_button.ForeColor = Color.White;

            label10.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            UserNameRadioButtonStart.ForeColor = Color.White;

            if (InvokeRequired)
            {
                Invoke(new Action(() => AddNameFiles.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => AddNumberFile.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => DateTimeMaskedTextBox.BackColor = Color.FromArgb(34, 34, 35)));

                Invoke(new Action(() => AddNameFiles.ForeColor = Color.White));
                Invoke(new Action(() => AddNumberFile.ForeColor = Color.White));
                Invoke(new Action(() => DateTimeMaskedTextBox.ForeColor = Color.White));

                Invoke(new Action(() => FilesListBox.BackColor = Color.FromArgb(34, 34, 35)));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.White));
            }
            else
            {
                AddNameFiles.BackColor = Color.FromArgb(34, 34, 35);
                AddNumberFile.BackColor = Color.FromArgb(34, 34, 35);
                DateTimeMaskedTextBox.BackColor = Color.FromArgb(34, 34, 35);

                AddNameFiles.ForeColor = Color.White;
                AddNumberFile.ForeColor = Color.White;
                DateTimeMaskedTextBox.ForeColor = Color.White;

                FilesListBox.BackColor = Color.FromArgb(34, 34, 35);
                FilesListBox.ForeColor = Color.White;
            }
        }

        public void DarkThemeFalse()
        {
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            panel4.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel2.BackColor = Color.White;
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
            label10.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;

            BackColor = Color.White;
            panel5.BackColor = Color.FromArgb(143, 142, 147);
            panel4.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel1.BackColor = Color.White;

            panel5.ForeColor = Color.Black;
            panel4.ForeColor = Color.Black;
            panel3.ForeColor = Color.Black;
            panel2.ForeColor = Color.Black;
            panel1.ForeColor = Color.Black;


            pictureBox1.BackgroundImage = Properties.Resources.white_close;
            pictureBox2.BackgroundImage = Properties.Resources.white_min;
            pictureBox3.BackgroundImage = Properties.Resources.white_web;
            pictureBox4.BackgroundImage = Properties.Resources.white_back;
            pictureBox5.BackgroundImage = Properties.Resources.white_setings;

            rename_button.ForeColor = Color.Black;
            choosePath_button.ForeColor = Color.Black;

            label10.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            UserNameRadioButtonStart.ForeColor = Color.Black;

            if (InvokeRequired)
            {
                Invoke(new Action(() => AddNameFiles.BackColor = Color.White));
                Invoke(new Action(() => AddNumberFile.BackColor = Color.White));
                Invoke(new Action(() => DateTimeMaskedTextBox.BackColor = Color.White));

                Invoke(new Action(() => AddNameFiles.ForeColor = Color.Black));
                Invoke(new Action(() => AddNumberFile.ForeColor = Color.Black));
                Invoke(new Action(() => DateTimeMaskedTextBox.ForeColor = Color.Black));

                Invoke(new Action(() => FilesListBox.BackColor = Color.White));
                Invoke(new Action(() => FilesListBox.ForeColor = Color.Black));
            }
            else
            {
                AddNameFiles.BackColor = Color.White;
                AddNumberFile.BackColor = Color.White;
                DateTimeMaskedTextBox.BackColor = Color.White;

                AddNameFiles.ForeColor = Color.Black;
                AddNumberFile.ForeColor = Color.Black;
                DateTimeMaskedTextBox.ForeColor = Color.Black;

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
    }
}
