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
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelDesktopPanel = new Panel();
            panelMenu.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(ImportDataButton);
            panelMenu.Controls.Add(Departments_button);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 542);
            panelMenu.TabIndex = 0;
            // 
            // ImportDataButton
            // 
            ImportDataButton.Dock = DockStyle.Top;
            ImportDataButton.FlatAppearance.BorderSize = 0;
            ImportDataButton.FlatStyle = FlatStyle.Flat;
            ImportDataButton.ForeColor = Color.Gainsboro;
            ImportDataButton.Location = new Point(0, 320);
            ImportDataButton.Name = "ImportDataButton";
            ImportDataButton.Size = new Size(220, 60);
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
            Departments_button.Location = new Point(0, 260);
            Departments_button.Name = "Departments_button";
            Departments_button.Size = new Size(220, 60);
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
            button3.Location = new Point(0, 200);
            button3.Name = "button3";
            button3.Size = new Size(220, 60);
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
            button2.Location = new Point(0, 140);
            button2.Name = "button2";
            button2.Size = new Size(220, 60);
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
            button1.Location = new Point(0, 80);
            button1.Name = "button1";
            button1.Size = new Size(220, 60);
            button1.TabIndex = 1;
            button1.Text = "Карты";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(965, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(444, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(76, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Меню";
            // 
            // panelDesktopPanel
            // 
            panelDesktopPanel.Dock = DockStyle.Fill;
            panelDesktopPanel.Location = new Point(220, 80);
            panelDesktopPanel.Name = "panelDesktopPanel";
            panelDesktopPanel.Size = new Size(965, 462);
            panelDesktopPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 542);
            Controls.Add(panelDesktopPanel);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            ForeColor = Color.White;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database";
            panelMenu.ResumeLayout(false);
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
    }
}