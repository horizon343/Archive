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
            LastNameTextField.Location = new Point(244, 169);
            LastNameTextField.Margin = new Padding(3, 4, 3, 4);
            LastNameTextField.Name = "LastNameTextField";
            LastNameTextField.Size = new Size(302, 27);
            LastNameTextField.TabIndex = 1;
            // 
            // FirstNameTextField
            // 
            FirstNameTextField.Location = new Point(244, 208);
            FirstNameTextField.Margin = new Padding(3, 4, 3, 4);
            FirstNameTextField.Name = "FirstNameTextField";
            FirstNameTextField.Size = new Size(302, 27);
            FirstNameTextField.TabIndex = 2;
            // 
            // MiddleNameTextField
            // 
            MiddleNameTextField.Location = new Point(244, 247);
            MiddleNameTextField.Margin = new Padding(3, 4, 3, 4);
            MiddleNameTextField.Name = "MiddleNameTextField";
            MiddleNameTextField.Size = new Size(302, 27);
            MiddleNameTextField.TabIndex = 3;
            // 
            // RegionTextField
            // 
            RegionTextField.Location = new Point(244, 325);
            RegionTextField.Margin = new Padding(3, 4, 3, 4);
            RegionTextField.Name = "RegionTextField";
            RegionTextField.Size = new Size(302, 27);
            RegionTextField.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(122, 135);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 11;
            label1.Text = "Номер";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(122, 173);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 12;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(122, 212);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 13;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(122, 251);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 14;
            label4.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(122, 289);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 15;
            label5.Text = "Дата рождения";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(122, 335);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 16;
            label6.Text = "Регион";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(586, 135);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 17;
            label7.Text = "Район";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(587, 173);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 18;
            label8.Text = "Город";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(587, 212);
            label9.Name = "label9";
            label9.Size = new Size(51, 20);
            label9.TabIndex = 19;
            label9.Text = "Адрес";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(586, 251);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 20;
            label10.Text = "Телефон";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(586, 289);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 21;
            label11.Text = "Индекс";
            // 
            // RecordsTable
            // 
            RecordsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecordsTable.Location = new Point(244, 363);
            RecordsTable.Margin = new Padding(3, 4, 3, 4);
            RecordsTable.Name = "RecordsTable";
            RecordsTable.RowHeadersWidth = 51;
            RecordsTable.RowTemplate.Height = 25;
            RecordsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RecordsTable.Size = new Size(719, 243);
            RecordsTable.TabIndex = 0;
            RecordsTable.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(122, 377);
            label12.Name = "label12";
            label12.Size = new Size(52, 20);
            label12.TabIndex = 23;
            label12.Text = "Карты";
            // 
            // AddRecordButton
            // 
            AddRecordButton.ForeColor = Color.Black;
            AddRecordButton.Location = new Point(244, 613);
            AddRecordButton.Margin = new Padding(3, 4, 3, 4);
            AddRecordButton.Name = "AddRecordButton";
            AddRecordButton.Size = new Size(136, 31);
            AddRecordButton.TabIndex = 11;
            AddRecordButton.Text = "Добавить карту";
            AddRecordButton.UseVisualStyleBackColor = true;
            AddRecordButton.Click += AddRecordButton_Click;
            // 
            // PhoneTextField
            // 
            PhoneTextField.Location = new Point(661, 247);
            PhoneTextField.Margin = new Padding(3, 4, 3, 4);
            PhoneTextField.Name = "PhoneTextField";
            PhoneTextField.Size = new Size(302, 27);
            PhoneTextField.TabIndex = 9;
            // 
            // AddressTextField
            // 
            AddressTextField.Location = new Point(661, 208);
            AddressTextField.Margin = new Padding(3, 4, 3, 4);
            AddressTextField.Name = "AddressTextField";
            AddressTextField.Size = new Size(302, 27);
            AddressTextField.TabIndex = 8;
            // 
            // CityTextField
            // 
            CityTextField.Location = new Point(661, 169);
            CityTextField.Margin = new Padding(3, 4, 3, 4);
            CityTextField.Name = "CityTextField";
            CityTextField.Size = new Size(302, 27);
            CityTextField.TabIndex = 7;
            // 
            // DistrictTextField
            // 
            DistrictTextField.Location = new Point(661, 131);
            DistrictTextField.Margin = new Padding(3, 4, 3, 4);
            DistrictTextField.Name = "DistrictTextField";
            DistrictTextField.Size = new Size(302, 27);
            DistrictTextField.TabIndex = 6;
            // 
            // IndexTextField
            // 
            IndexTextField.Location = new Point(661, 285);
            IndexTextField.Margin = new Padding(3, 4, 3, 4);
            IndexTextField.Name = "IndexTextField";
            IndexTextField.Size = new Size(302, 27);
            IndexTextField.TabIndex = 10;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(255, 128, 0);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Margin = new Padding(3, 4, 3, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1125, 101);
            panelTitleBar.TabIndex = 30;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(410, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(330, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Информация о пациенте";
            // 
            // DateOfBirthTextField
            // 
            DateOfBirthTextField.Location = new Point(244, 285);
            DateOfBirthTextField.Margin = new Padding(3, 4, 3, 4);
            DateOfBirthTextField.Name = "DateOfBirthTextField";
            DateOfBirthTextField.Size = new Size(302, 27);
            DateOfBirthTextField.TabIndex = 4;
            // 
            // PatientNumberLabel
            // 
            PatientNumberLabel.AutoSize = true;
            PatientNumberLabel.ForeColor = Color.Black;
            PatientNumberLabel.Location = new Point(244, 135);
            PatientNumberLabel.Name = "PatientNumberLabel";
            PatientNumberLabel.Size = new Size(57, 20);
            PatientNumberLabel.TabIndex = 11;
            PatientNumberLabel.Text = "Номер";
            // 
            // ErrorTextLabel
            // 
            ErrorTextLabel.AutoSize = true;
            ErrorTextLabel.ForeColor = Color.Black;
            ErrorTextLabel.Location = new Point(661, 328);
            ErrorTextLabel.Name = "ErrorTextLabel";
            ErrorTextLabel.Size = new Size(0, 20);
            ErrorTextLabel.TabIndex = 21;
            // 
            // SaveButton
            // 
            SaveButton.Enabled = false;
            SaveButton.ForeColor = Color.Black;
            SaveButton.Location = new Point(827, 613);
            SaveButton.Margin = new Padding(3, 4, 3, 4);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(136, 31);
            SaveButton.TabIndex = 13;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ShowOrHideButton
            // 
            ShowOrHideButton.ForeColor = Color.Black;
            ShowOrHideButton.Location = new Point(685, 613);
            ShowOrHideButton.Margin = new Padding(3, 4, 3, 4);
            ShowOrHideButton.Name = "ShowOrHideButton";
            ShowOrHideButton.Size = new Size(136, 31);
            ShowOrHideButton.TabIndex = 12;
            ShowOrHideButton.Text = "Скрыть";
            ShowOrHideButton.UseVisualStyleBackColor = true;
            ShowOrHideButton.Click += ShowOrHideButton_Click;
            // 
            // FormPatientAndRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPatientAndRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Информация о пациенте";
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