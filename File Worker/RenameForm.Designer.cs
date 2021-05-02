using System.Drawing;

namespace FileWorker
{
    partial class RenameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameForm));
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DateRadioButtonEnd = new System.Windows.Forms.RadioButton();
            this.FileModificationDateCheckBox = new System.Windows.Forms.CheckBox();
            this.DateRadioButtonStart = new System.Windows.Forms.RadioButton();
            this.DateTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DateCheckBox = new System.Windows.Forms.CheckBox();
            this.FileCreationDateСheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.choosePath_button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UserNameRadioButtonEnd = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.UserNameRadioButtonStart = new System.Windows.Forms.RadioButton();
            this.UserNameCheckBox = new System.Windows.Forms.CheckBox();
            this.rename_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NumberForFileEnd = new System.Windows.Forms.RadioButton();
            this.NumberForFileStart = new System.Windows.Forms.RadioButton();
            this.AddNumberFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonEnd = new System.Windows.Forms.RadioButton();
            this.AddNameFiles = new System.Windows.Forms.TextBox();
            this.radioButtonStart = new System.Windows.Forms.RadioButton();
            this.EraseCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(142)))), ((int)(((byte)(147)))));
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Font = new System.Drawing.Font("Verdana", 10F);
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1000, 40);
            this.panel5.TabIndex = 4;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.panel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Переименование файлов";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::FileWorker.Properties.Resources.white_web;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(903, 9);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::FileWorker.Properties.Resources.white_min;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(933, 9);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::FileWorker.Properties.Resources.white_close;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(963, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(37, 567);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(241, 18);
            this.label10.TabIndex = 61;
            this.label10.Text = "Предварительный просмотр";
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 18);
            this.label3.TabIndex = 60;
            this.label3.Text = "Папка не выбрана";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(589, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Файлы в папке";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(72, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 18);
            this.label8.TabIndex = 58;
            this.label8.Text = "Даты в имени файла";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // FilesListBox
            // 
            this.FilesListBox.BackColor = System.Drawing.Color.White;
            this.FilesListBox.ForeColor = System.Drawing.Color.Black;
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.ItemHeight = 16;
            this.FilesListBox.Location = new System.Drawing.Point(380, 316);
            this.FilesListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.FilesListBox.Size = new System.Drawing.Size(561, 196);
            this.FilesListBox.Sorted = true;
            this.FilesListBox.TabIndex = 48;
            this.FilesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.FilesListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.FilesListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.DateRadioButtonEnd);
            this.panel4.Controls.Add(this.FileModificationDateCheckBox);
            this.panel4.Controls.Add(this.DateRadioButtonStart);
            this.panel4.Controls.Add(this.DateTimeMaskedTextBox);
            this.panel4.Controls.Add(this.DateCheckBox);
            this.panel4.Controls.Add(this.FileCreationDateСheckBox);
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(17, 316);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(303, 208);
            this.panel4.TabIndex = 57;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // DateRadioButtonEnd
            // 
            this.DateRadioButtonEnd.AutoSize = true;
            this.DateRadioButtonEnd.Enabled = false;
            this.DateRadioButtonEnd.Location = new System.Drawing.Point(22, 180);
            this.DateRadioButtonEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateRadioButtonEnd.Name = "DateRadioButtonEnd";
            this.DateRadioButtonEnd.Size = new System.Drawing.Size(85, 21);
            this.DateRadioButtonEnd.TabIndex = 15;
            this.DateRadioButtonEnd.TabStop = true;
            this.DateRadioButtonEnd.Text = "В конец";
            this.DateRadioButtonEnd.UseVisualStyleBackColor = true;
            this.DateRadioButtonEnd.CheckedChanged += new System.EventHandler(this.preview);
            this.DateRadioButtonEnd.TextChanged += new System.EventHandler(this.preview);
            // 
            // FileModificationDateCheckBox
            // 
            this.FileModificationDateCheckBox.AutoSize = true;
            this.FileModificationDateCheckBox.Location = new System.Drawing.Point(22, 48);
            this.FileModificationDateCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FileModificationDateCheckBox.Name = "FileModificationDateCheckBox";
            this.FileModificationDateCheckBox.Size = new System.Drawing.Size(272, 21);
            this.FileModificationDateCheckBox.TabIndex = 18;
            this.FileModificationDateCheckBox.Text = "Добавлять дату изменения файла";
            this.FileModificationDateCheckBox.UseVisualStyleBackColor = true;
            this.FileModificationDateCheckBox.CheckedChanged += new System.EventHandler(this.FileModificationDateCheckBox_CheckedChanged);
            // 
            // DateRadioButtonStart
            // 
            this.DateRadioButtonStart.AutoSize = true;
            this.DateRadioButtonStart.Enabled = false;
            this.DateRadioButtonStart.Location = new System.Drawing.Point(22, 148);
            this.DateRadioButtonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateRadioButtonStart.Name = "DateRadioButtonStart";
            this.DateRadioButtonStart.Size = new System.Drawing.Size(92, 21);
            this.DateRadioButtonStart.TabIndex = 14;
            this.DateRadioButtonStart.TabStop = true;
            this.DateRadioButtonStart.Text = "В начало";
            this.DateRadioButtonStart.UseVisualStyleBackColor = true;
            this.DateRadioButtonStart.CheckedChanged += new System.EventHandler(this.preview);
            this.DateRadioButtonStart.TextChanged += new System.EventHandler(this.preview);
            // 
            // DateTimeMaskedTextBox
            // 
            this.DateTimeMaskedTextBox.BackColor = System.Drawing.Color.White;
            this.DateTimeMaskedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DateTimeMaskedTextBox.Enabled = false;
            this.DateTimeMaskedTextBox.ForeColor = System.Drawing.Color.Black;
            this.DateTimeMaskedTextBox.Location = new System.Drawing.Point(22, 112);
            this.DateTimeMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateTimeMaskedTextBox.Mask = "00/00/0000 90:00";
            this.DateTimeMaskedTextBox.Name = "DateTimeMaskedTextBox";
            this.DateTimeMaskedTextBox.Size = new System.Drawing.Size(197, 17);
            this.DateTimeMaskedTextBox.TabIndex = 14;
            this.DateTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            this.DateTimeMaskedTextBox.TextChanged += new System.EventHandler(this.preview);
            // 
            // DateCheckBox
            // 
            this.DateCheckBox.AutoSize = true;
            this.DateCheckBox.Location = new System.Drawing.Point(22, 80);
            this.DateCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateCheckBox.Name = "DateCheckBox";
            this.DateCheckBox.Size = new System.Drawing.Size(182, 21);
            this.DateCheckBox.TabIndex = 16;
            this.DateCheckBox.Text = "Добавлять свою дату";
            this.DateCheckBox.UseVisualStyleBackColor = true;
            this.DateCheckBox.CheckedChanged += new System.EventHandler(this.DateCheckBox_CheckedChanged);
            // 
            // FileCreationDateСheckBox
            // 
            this.FileCreationDateСheckBox.AutoSize = true;
            this.FileCreationDateСheckBox.Location = new System.Drawing.Point(22, 16);
            this.FileCreationDateСheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FileCreationDateСheckBox.Name = "FileCreationDateСheckBox";
            this.FileCreationDateСheckBox.Size = new System.Drawing.Size(262, 21);
            this.FileCreationDateСheckBox.TabIndex = 17;
            this.FileCreationDateСheckBox.Text = "Добавлять дату создания файла";
            this.FileCreationDateСheckBox.UseVisualStyleBackColor = true;
            this.FileCreationDateСheckBox.CheckedChanged += new System.EventHandler(this.FileCreationDateСheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(718, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 18);
            this.label2.TabIndex = 56;
            this.label2.Text = "Имя пользователя";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(96, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 52;
            this.label6.Text = "Имя файла";
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(406, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Уникальный ID";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // choosePath_button
            // 
            this.choosePath_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(142)))), ((int)(((byte)(147)))));
            this.choosePath_button.FlatAppearance.BorderSize = 0;
            this.choosePath_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosePath_button.ForeColor = System.Drawing.Color.Black;
            this.choosePath_button.Location = new System.Drawing.Point(16, 607);
            this.choosePath_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.choosePath_button.Name = "choosePath_button";
            this.choosePath_button.Size = new System.Drawing.Size(166, 30);
            this.choosePath_button.TabIndex = 47;
            this.choosePath_button.Text = "Выбрать папку";
            this.choosePath_button.UseVisualStyleBackColor = false;
            this.choosePath_button.Click += new System.EventHandler(this.choosePath_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.UserNameRadioButtonEnd);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.UserNameRadioButtonStart);
            this.panel3.Controls.Add(this.UserNameCheckBox);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(672, 104);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 164);
            this.panel3.TabIndex = 55;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // UserNameRadioButtonEnd
            // 
            this.UserNameRadioButtonEnd.AutoSize = true;
            this.UserNameRadioButtonEnd.Enabled = false;
            this.UserNameRadioButtonEnd.Location = new System.Drawing.Point(10, 126);
            this.UserNameRadioButtonEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameRadioButtonEnd.Name = "UserNameRadioButtonEnd";
            this.UserNameRadioButtonEnd.Size = new System.Drawing.Size(85, 21);
            this.UserNameRadioButtonEnd.TabIndex = 15;
            this.UserNameRadioButtonEnd.TabStop = true;
            this.UserNameRadioButtonEnd.Text = "В конец";
            this.UserNameRadioButtonEnd.UseVisualStyleBackColor = true;
            this.UserNameRadioButtonEnd.CheckedChanged += new System.EventHandler(this.preview);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(4, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 18);
            this.label7.TabIndex = 28;
            // 
            // UserNameRadioButtonStart
            // 
            this.UserNameRadioButtonStart.AutoSize = true;
            this.UserNameRadioButtonStart.Enabled = false;
            this.UserNameRadioButtonStart.Location = new System.Drawing.Point(10, 90);
            this.UserNameRadioButtonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameRadioButtonStart.Name = "UserNameRadioButtonStart";
            this.UserNameRadioButtonStart.Size = new System.Drawing.Size(92, 21);
            this.UserNameRadioButtonStart.TabIndex = 14;
            this.UserNameRadioButtonStart.TabStop = true;
            this.UserNameRadioButtonStart.Text = "В начало";
            this.UserNameRadioButtonStart.UseVisualStyleBackColor = true;
            this.UserNameRadioButtonStart.CheckedChanged += new System.EventHandler(this.preview);
            // 
            // UserNameCheckBox
            // 
            this.UserNameCheckBox.AutoSize = true;
            this.UserNameCheckBox.Location = new System.Drawing.Point(10, 18);
            this.UserNameCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameCheckBox.Name = "UserNameCheckBox";
            this.UserNameCheckBox.Size = new System.Drawing.Size(239, 21);
            this.UserNameCheckBox.TabIndex = 13;
            this.UserNameCheckBox.Text = "Добавлять имя пользователя";
            this.UserNameCheckBox.UseVisualStyleBackColor = true;
            this.UserNameCheckBox.CheckedChanged += new System.EventHandler(this.radioButtonEnd_CheckedChanged);
            // 
            // rename_button
            // 
            this.rename_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(142)))), ((int)(((byte)(147)))));
            this.rename_button.Enabled = false;
            this.rename_button.FlatAppearance.BorderSize = 0;
            this.rename_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rename_button.ForeColor = System.Drawing.Color.Black;
            this.rename_button.Location = new System.Drawing.Point(188, 607);
            this.rename_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rename_button.Name = "rename_button";
            this.rename_button.Size = new System.Drawing.Size(166, 30);
            this.rename_button.TabIndex = 49;
            this.rename_button.Text = "Переименовать";
            this.rename_button.UseVisualStyleBackColor = false;
            this.rename_button.Click += new System.EventHandler(this.rename_button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.NumberForFileEnd);
            this.panel2.Controls.Add(this.NumberForFileStart);
            this.panel2.Controls.Add(this.AddNumberFile);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(344, 104);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 164);
            this.panel2.TabIndex = 53;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // NumberForFileEnd
            // 
            this.NumberForFileEnd.AutoSize = true;
            this.NumberForFileEnd.Location = new System.Drawing.Point(22, 126);
            this.NumberForFileEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumberForFileEnd.Name = "NumberForFileEnd";
            this.NumberForFileEnd.Size = new System.Drawing.Size(85, 21);
            this.NumberForFileEnd.TabIndex = 16;
            this.NumberForFileEnd.TabStop = true;
            this.NumberForFileEnd.Text = "В конец";
            this.NumberForFileEnd.UseVisualStyleBackColor = true;
            this.NumberForFileEnd.CheckedChanged += new System.EventHandler(this.preview);
            // 
            // NumberForFileStart
            // 
            this.NumberForFileStart.AutoSize = true;
            this.NumberForFileStart.Checked = true;
            this.NumberForFileStart.Location = new System.Drawing.Point(22, 90);
            this.NumberForFileStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumberForFileStart.Name = "NumberForFileStart";
            this.NumberForFileStart.Size = new System.Drawing.Size(92, 21);
            this.NumberForFileStart.TabIndex = 15;
            this.NumberForFileStart.TabStop = true;
            this.NumberForFileStart.Text = "В начало";
            this.NumberForFileStart.UseVisualStyleBackColor = true;
            this.NumberForFileStart.CheckedChanged += new System.EventHandler(this.preview);
            // 
            // AddNumberFile
            // 
            this.AddNumberFile.BackColor = System.Drawing.Color.White;
            this.AddNumberFile.ForeColor = System.Drawing.Color.Black;
            this.AddNumberFile.Location = new System.Drawing.Point(22, 17);
            this.AddNumberFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddNumberFile.Name = "AddNumberFile";
            this.AddNumberFile.Size = new System.Drawing.Size(93, 24);
            this.AddNumberFile.TabIndex = 7;
            this.AddNumberFile.Text = "1";
            this.AddNumberFile.TextChanged += new System.EventHandler(this.preview);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radioButtonEnd);
            this.panel1.Controls.Add(this.AddNameFiles);
            this.panel1.Controls.Add(this.radioButtonStart);
            this.panel1.Controls.Add(this.EraseCheckBox);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(16, 104);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 164);
            this.panel1.TabIndex = 51;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            // 
            // radioButtonEnd
            // 
            this.radioButtonEnd.AutoSize = true;
            this.radioButtonEnd.Location = new System.Drawing.Point(24, 124);
            this.radioButtonEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonEnd.Name = "radioButtonEnd";
            this.radioButtonEnd.Size = new System.Drawing.Size(85, 21);
            this.radioButtonEnd.TabIndex = 15;
            this.radioButtonEnd.TabStop = true;
            this.radioButtonEnd.Text = "В конец";
            this.radioButtonEnd.UseVisualStyleBackColor = true;
            this.radioButtonEnd.CheckedChanged += new System.EventHandler(this.preview);
            this.radioButtonEnd.TextChanged += new System.EventHandler(this.preview);
            // 
            // AddNameFiles
            // 
            this.AddNameFiles.BackColor = System.Drawing.Color.White;
            this.AddNameFiles.ForeColor = System.Drawing.Color.Black;
            this.AddNameFiles.Location = new System.Drawing.Point(24, 17);
            this.AddNameFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddNameFiles.Name = "AddNameFiles";
            this.AddNameFiles.Size = new System.Drawing.Size(204, 24);
            this.AddNameFiles.TabIndex = 5;
            this.AddNameFiles.TextChanged += new System.EventHandler(this.preview);
            // 
            // radioButtonStart
            // 
            this.radioButtonStart.AutoSize = true;
            this.radioButtonStart.Checked = true;
            this.radioButtonStart.Location = new System.Drawing.Point(24, 90);
            this.radioButtonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonStart.Name = "radioButtonStart";
            this.radioButtonStart.Size = new System.Drawing.Size(92, 21);
            this.radioButtonStart.TabIndex = 14;
            this.radioButtonStart.TabStop = true;
            this.radioButtonStart.Text = "В начало";
            this.radioButtonStart.UseVisualStyleBackColor = true;
            this.radioButtonStart.CheckedChanged += new System.EventHandler(this.preview);
            this.radioButtonStart.TextChanged += new System.EventHandler(this.preview);
            // 
            // EraseCheckBox
            // 
            this.EraseCheckBox.AutoSize = true;
            this.EraseCheckBox.Location = new System.Drawing.Point(24, 55);
            this.EraseCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EraseCheckBox.Name = "EraseCheckBox";
            this.EraseCheckBox.Size = new System.Drawing.Size(209, 21);
            this.EraseCheckBox.TabIndex = 3;
            this.EraseCheckBox.Text = "Стереть старое название";
            this.EraseCheckBox.UseVisualStyleBackColor = true;
            this.EraseCheckBox.CheckedChanged += new System.EventHandler(this.radioButtonEnd_CheckedChanged);
            this.EraseCheckBox.TextChanged += new System.EventHandler(this.preview);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::FileWorker.Properties.Resources.white_setings;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Location = new System.Drawing.Point(957, 45);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.TabIndex = 65;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox5_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::FileWorker.Properties.Resources.white_back;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(12, 43);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.TabIndex = 62;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseMove);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choosePath_button);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.rename_button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Verdana", 10F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "RenameForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ManeForm_MouseUp);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton DateRadioButtonEnd;
        private System.Windows.Forms.CheckBox FileModificationDateCheckBox;
        private System.Windows.Forms.RadioButton DateRadioButtonStart;
        private System.Windows.Forms.MaskedTextBox DateTimeMaskedTextBox;
        private System.Windows.Forms.CheckBox DateCheckBox;
        private System.Windows.Forms.CheckBox FileCreationDateСheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choosePath_button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton UserNameRadioButtonEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton UserNameRadioButtonStart;
        private System.Windows.Forms.CheckBox UserNameCheckBox;
        private System.Windows.Forms.Button rename_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton NumberForFileEnd;
        private System.Windows.Forms.RadioButton NumberForFileStart;
        private System.Windows.Forms.TextBox AddNumberFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonEnd;
        private System.Windows.Forms.RadioButton radioButtonStart;
        private System.Windows.Forms.CheckBox EraseCheckBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox AddNameFiles;
    }
}

