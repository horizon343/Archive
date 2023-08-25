using Archive.DB;

namespace Archive
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            ImportDataButton = new Button();
            Departments_button = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            StorageLocationSelect = new ComboBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelDesktopPanel = new Panel();
            SettingsButton = new Button();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(SettingsButton);
            panelMenu.Controls.Add(ImportDataButton);
            panelMenu.Controls.Add(Departments_button);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(251, 723);
            panelMenu.TabIndex = 0;
            // 
            // ImportDataButton
            // 
            ImportDataButton.Dock = DockStyle.Top;
            ImportDataButton.FlatAppearance.BorderSize = 0;
            ImportDataButton.FlatStyle = FlatStyle.Flat;
            ImportDataButton.ForeColor = Color.Gainsboro;
            ImportDataButton.Location = new Point(0, 427);
            ImportDataButton.Margin = new Padding(3, 4, 3, 4);
            ImportDataButton.Name = "ImportDataButton";
            ImportDataButton.Size = new Size(251, 80);
            ImportDataButton.TabIndex = 6;
            ImportDataButton.Text = "Import Data";
            ImportDataButton.UseVisualStyleBackColor = true;
            ImportDataButton.Click += ImportDataButton_Click;
            // 
            // Departments_button
            // 
            Departments_button.Dock = DockStyle.Top;
            Departments_button.FlatAppearance.BorderSize = 0;
            Departments_button.FlatStyle = FlatStyle.Flat;
            Departments_button.ForeColor = Color.Gainsboro;
            Departments_button.Location = new Point(0, 347);
            Departments_button.Margin = new Padding(3, 4, 3, 4);
            Departments_button.Name = "Departments_button";
            Departments_button.Size = new Size(251, 80);
            Departments_button.TabIndex = 5;
            Departments_button.Text = "Отделения";
            Departments_button.UseVisualStyleBackColor = true;
            Departments_button.Click += Departments_button_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Gainsboro;
            button3.Location = new Point(0, 267);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(251, 80);
            button3.TabIndex = 3;
            button3.Text = "МКБ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Gainsboro;
            button2.Location = new Point(0, 187);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(251, 80);
            button2.TabIndex = 2;
            button2.Text = "Пациенты";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Gainsboro;
            button1.Location = new Point(0, 107);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(251, 80);
            button1.TabIndex = 1;
            button1.Text = "Карты";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Controls.Add(StorageLocationSelect);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(251, 107);
            panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(192, 20);
            label1.TabIndex = 0;
            label1.Text = "Текущее местоположение";
            // 
            // StorageLocationSelect
            // 
            StorageLocationSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            StorageLocationSelect.FormattingEnabled = true;
            StorageLocationSelect.Location = new Point(9, 43);
            StorageLocationSelect.Margin = new Padding(3, 4, 3, 4);
            StorageLocationSelect.Name = "StorageLocationSelect";
            StorageLocationSelect.Size = new Size(233, 28);
            StorageLocationSelect.TabIndex = 1;
            StorageLocationSelect.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(251, 0);
            panelTitleBar.Margin = new Padding(3, 4, 3, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1103, 107);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(507, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(93, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Меню";
            // 
            // panelDesktopPanel
            // 
            panelDesktopPanel.Dock = DockStyle.Fill;
            panelDesktopPanel.Location = new Point(251, 107);
            panelDesktopPanel.Margin = new Padding(3, 4, 3, 4);
            panelDesktopPanel.Name = "panelDesktopPanel";
            panelDesktopPanel.Size = new Size(1103, 616);
            panelDesktopPanel.TabIndex = 2;
            // 
            // SettingsButton
            // 
            SettingsButton.Dock = DockStyle.Top;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.FlatStyle = FlatStyle.Flat;
            SettingsButton.ForeColor = Color.Gainsboro;
            SettingsButton.Location = new Point(0, 507);
            SettingsButton.Margin = new Padding(3, 4, 3, 4);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(251, 80);
            SettingsButton.TabIndex = 7;
            SettingsButton.Text = "Настройки";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 723);
            Controls.Add(panelDesktopPanel);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            ForeColor = Color.White;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Архив";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Создание базы данных и таблиц, если она не создана (созданы)
        /// </summary>
        private void InitDB()
        {
            DBase dBase = new DBase();
            dBase.CreateTables();
        }

        private Panel panelMenu;
        private Button button1;
        private Button button3;
        private Button button2;
        private Panel panelLogo;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Panel panelDesktopPanel;
        private Button Departments_button;
        private Button ImportDataButton;
        private ComboBox StorageLocationSelect;
        private Label label1;
        private Button SettingsButton;
    }
}