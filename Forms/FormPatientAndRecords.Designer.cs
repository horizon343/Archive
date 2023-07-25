namespace Archive.Forms
{
    partial class FormPatientAndRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LastNameTextField = new TextBox();
            FirstNameTextField = new TextBox();
            MiddleNameTextField = new TextBox();
            RegionTextField = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            RecordsTable = new DataGridView();
            label12 = new Label();
            AddRecordButton = new Button();
            PhoneTextField = new TextBox();
            AddressTextField = new TextBox();
            CityTextField = new TextBox();
            DistrictTextField = new TextBox();
            IndexTextField = new TextBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            DateOfBirthTextField = new TextBox();
            PatientNumberLabel = new Label();
            ErrorTextLabel = new Label();
            SaveButton = new Button();
            ShowOrHideButton = new Button();
            ((System.ComponentModel.ISupportInitialize)RecordsTable).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // LastNameTextField
            // 
            LastNameTextField.Location = new Point(103, 111);
            LastNameTextField.Name = "LastNameTextField";
            LastNameTextField.Size = new Size(265, 23);
            LastNameTextField.TabIndex = 1;
            // 
            // FirstNameTextField
            // 
            FirstNameTextField.Location = new Point(103, 140);
            FirstNameTextField.Name = "FirstNameTextField";
            FirstNameTextField.Size = new Size(265, 23);
            FirstNameTextField.TabIndex = 2;
            // 
            // MiddleNameTextField
            // 
            MiddleNameTextField.Location = new Point(103, 169);
            MiddleNameTextField.Name = "MiddleNameTextField";
            MiddleNameTextField.Size = new Size(265, 23);
            MiddleNameTextField.TabIndex = 3;
            // 
            // RegionTextField
            // 
            RegionTextField.Location = new Point(103, 227);
            RegionTextField.Name = "RegionTextField";
            RegionTextField.Size = new Size(265, 23);
            RegionTextField.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 85);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 11;
            label1.Text = "Номер";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 114);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 12;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 143);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 13;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(12, 172);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 14;
            label4.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 201);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 15;
            label5.Text = "Дата рождения";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(12, 235);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 16;
            label6.Text = "Регион";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(418, 85);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 17;
            label7.Text = "Район";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(419, 114);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 18;
            label8.Text = "Город";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(419, 143);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 19;
            label9.Text = "Адрес";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(418, 172);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 20;
            label10.Text = "Телефон";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(418, 201);
            label11.Name = "label11";
            label11.Size = new Size(47, 15);
            label11.TabIndex = 21;
            label11.Text = "Индекс";
            // 
            // RecordsTable
            // 
            RecordsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecordsTable.Location = new Point(103, 256);
            RecordsTable.Name = "RecordsTable";
            RecordsTable.RowTemplate.Height = 25;
            RecordsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RecordsTable.Size = new Size(645, 182);
            RecordsTable.TabIndex = 0;
            RecordsTable.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 267);
            label12.Name = "label12";
            label12.Size = new Size(41, 15);
            label12.TabIndex = 23;
            label12.Text = "Карты";
            // 
            // AddRecordButton
            // 
            AddRecordButton.ForeColor = Color.Black;
            AddRecordButton.Location = new Point(103, 444);
            AddRecordButton.Name = "AddRecordButton";
            AddRecordButton.Size = new Size(119, 23);
            AddRecordButton.TabIndex = 11;
            AddRecordButton.Text = "Добавить карту";
            AddRecordButton.UseVisualStyleBackColor = true;
            AddRecordButton.Click += AddRecordButton_Click;
            // 
            // PhoneTextField
            // 
            PhoneTextField.Location = new Point(483, 169);
            PhoneTextField.Name = "PhoneTextField";
            PhoneTextField.Size = new Size(265, 23);
            PhoneTextField.TabIndex = 9;
            // 
            // AddressTextField
            // 
            AddressTextField.Location = new Point(483, 140);
            AddressTextField.Name = "AddressTextField";
            AddressTextField.Size = new Size(265, 23);
            AddressTextField.TabIndex = 8;
            // 
            // CityTextField
            // 
            CityTextField.Location = new Point(483, 111);
            CityTextField.Name = "CityTextField";
            CityTextField.Size = new Size(265, 23);
            CityTextField.TabIndex = 7;
            // 
            // DistrictTextField
            // 
            DistrictTextField.Location = new Point(483, 82);
            DistrictTextField.Name = "DistrictTextField";
            DistrictTextField.Size = new Size(265, 23);
            DistrictTextField.TabIndex = 6;
            // 
            // IndexTextField
            // 
            IndexTextField.Location = new Point(483, 198);
            IndexTextField.Name = "IndexTextField";
            IndexTextField.Size = new Size(265, 23);
            IndexTextField.TabIndex = 10;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(255, 128, 0);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(800, 76);
            panelTitleBar.TabIndex = 30;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(222, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(267, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Информация о пациенте";
            // 
            // DateOfBirthTextField
            // 
            DateOfBirthTextField.Location = new Point(103, 198);
            DateOfBirthTextField.Name = "DateOfBirthTextField";
            DateOfBirthTextField.Size = new Size(265, 23);
            DateOfBirthTextField.TabIndex = 4;
            // 
            // PatientNumberLabel
            // 
            PatientNumberLabel.AutoSize = true;
            PatientNumberLabel.ForeColor = Color.Black;
            PatientNumberLabel.Location = new Point(103, 85);
            PatientNumberLabel.Name = "PatientNumberLabel";
            PatientNumberLabel.Size = new Size(45, 15);
            PatientNumberLabel.TabIndex = 11;
            PatientNumberLabel.Text = "Номер";
            // 
            // ErrorTextLabel
            // 
            ErrorTextLabel.AutoSize = true;
            ErrorTextLabel.ForeColor = Color.Black;
            ErrorTextLabel.Location = new Point(483, 230);
            ErrorTextLabel.Name = "ErrorTextLabel";
            ErrorTextLabel.Size = new Size(0, 15);
            ErrorTextLabel.TabIndex = 21;
            // 
            // SaveButton
            // 
            SaveButton.Enabled = false;
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(629, 444);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(119, 23);
            SaveButton.TabIndex = 13;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ShowOrHideButton
            // 
            ShowOrHideButton.ForeColor = Color.Black;
            ShowOrHideButton.Location = new Point(504, 444);
            ShowOrHideButton.Name = "ShowOrHideButton";
            ShowOrHideButton.Size = new Size(119, 23);
            ShowOrHideButton.TabIndex = 12;
            ShowOrHideButton.Text = "Скрыть";
            ShowOrHideButton.UseVisualStyleBackColor = true;
            ShowOrHideButton.Click += ShowOrHideButton_Click;
            // 
            // FormPatientAndRecords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 474);
            Controls.Add(DateOfBirthTextField);
            Controls.Add(panelTitleBar);
            Controls.Add(IndexTextField);
            Controls.Add(PhoneTextField);
            Controls.Add(AddressTextField);
            Controls.Add(CityTextField);
            Controls.Add(DistrictTextField);
            Controls.Add(ShowOrHideButton);
            Controls.Add(SaveButton);
            Controls.Add(AddRecordButton);
            Controls.Add(label12);
            Controls.Add(RecordsTable);
            Controls.Add(ErrorTextLabel);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PatientNumberLabel);
            Controls.Add(label1);
            Controls.Add(RegionTextField);
            Controls.Add(MiddleNameTextField);
            Controls.Add(FirstNameTextField);
            Controls.Add(LastNameTextField);
            Name = "FormPatientAndRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPatientAndRecords";
            ((System.ComponentModel.ISupportInitialize)RecordsTable).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox LastNameTextField;
        private TextBox FirstNameTextField;
        private TextBox MiddleNameTextField;
        private TextBox RegionTextField;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private DataGridView RecordsTable;
        private Label label12;
        private Button AddRecordButton;
        private TextBox PhoneTextField;
        private TextBox AddressTextField;
        private TextBox CityTextField;
        private TextBox DistrictTextField;
        private TextBox IndexTextField;
        private Panel panelTitleBar;
        private Label lblTitle;
        private TextBox DateOfBirthTextField;
        private Label PatientNumberLabel;
        private Label ErrorTextLabel;
        private Button SaveButton;
        private Button ShowOrHideButton;
    }
}