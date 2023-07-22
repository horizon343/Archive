namespace Archive.Forms
{
    partial class FormPatients
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            PatientsTable = new DataGridView();
            LastNameTextField = new TextBox();
            AddPatientButton = new Button();
            label1 = new Label();
            SearchButton = new Button();
            PrevPageButton = new Button();
            NextPageButton = new Button();
            CountPageTextBox = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            PatientNumberTextField = new TextBox();
            DateOfBirthTextField = new TextBox();
            MiddleNameTextField = new TextBox();
            FirstNameTextField = new TextBox();
            TextError = new Label();
            ((System.ComponentModel.ISupportInitialize)PatientsTable).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // PatientsTable
            // 
            PatientsTable.AllowUserToAddRows = false;
            PatientsTable.AllowUserToDeleteRows = false;
            PatientsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PatientsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            PatientsTable.DefaultCellStyle = dataGridViewCellStyle1;
            PatientsTable.Location = new Point(12, 49);
            PatientsTable.Name = "PatientsTable";
            PatientsTable.RowTemplate.Height = 25;
            PatientsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PatientsTable.Size = new Size(935, 352);
            PatientsTable.TabIndex = 0;
            PatientsTable.TabStop = false;
            // 
            // LastNameTextField
            // 
            LastNameTextField.Location = new Point(143, 5);
            LastNameTextField.Name = "LastNameTextField";
            LastNameTextField.PlaceholderText = "Фамилия";
            LastNameTextField.Size = new Size(120, 23);
            LastNameTextField.TabIndex = 2;
            // 
            // AddPatientButton
            // 
            AddPatientButton.FlatStyle = FlatStyle.Flat;
            AddPatientButton.ForeColor = Color.Black;
            AddPatientButton.Location = new Point(3, 5);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(126, 23);
            AddPatientButton.TabIndex = 7;
            AddPatientButton.Text = "Добавить пациента";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += AddPatientButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Поиск";
            // 
            // SearchButton
            // 
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(619, 5);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // PrevPageButton
            // 
            PrevPageButton.FlatStyle = FlatStyle.Flat;
            PrevPageButton.ForeColor = Color.Black;
            PrevPageButton.Location = new Point(0, 3);
            PrevPageButton.Name = "PrevPageButton";
            PrevPageButton.Size = new Size(123, 23);
            PrevPageButton.TabIndex = 8;
            PrevPageButton.Text = "Предыдущая";
            PrevPageButton.UseVisualStyleBackColor = true;
            PrevPageButton.Click += PrevPageButton_Click;
            // 
            // NextPageButton
            // 
            NextPageButton.FlatStyle = FlatStyle.Flat;
            NextPageButton.ForeColor = Color.Black;
            NextPageButton.Location = new Point(213, 3);
            NextPageButton.Name = "NextPageButton";
            NextPageButton.Size = new Size(123, 23);
            NextPageButton.TabIndex = 9;
            NextPageButton.Text = "Следующая";
            NextPageButton.UseVisualStyleBackColor = true;
            NextPageButton.Click += NextPageButton_Click;
            // 
            // CountPageTextBox
            // 
            CountPageTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CountPageTextBox.AutoSize = true;
            CountPageTextBox.ForeColor = Color.Black;
            CountPageTextBox.Location = new Point(131, 7);
            CountPageTextBox.MinimumSize = new Size(75, 0);
            CountPageTextBox.Name = "CountPageTextBox";
            CountPageTextBox.Size = new Size(75, 15);
            CountPageTextBox.TabIndex = 4;
            CountPageTextBox.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.Controls.Add(NextPageButton);
            panel1.Controls.Add(PrevPageButton);
            panel1.Controls.Add(CountPageTextBox);
            panel1.Location = new Point(315, 407);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 29);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(AddPatientButton);
            panel2.Location = new Point(814, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(133, 31);
            panel2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(PatientNumberTextField);
            panel3.Controls.Add(DateOfBirthTextField);
            panel3.Controls.Add(MiddleNameTextField);
            panel3.Controls.Add(SearchButton);
            panel3.Controls.Add(FirstNameTextField);
            panel3.Controls.Add(LastNameTextField);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(701, 31);
            panel3.TabIndex = 9;
            // 
            // PatientNumberTextField
            // 
            PatientNumberTextField.Location = new Point(47, 5);
            PatientNumberTextField.Name = "PatientNumberTextField";
            PatientNumberTextField.PlaceholderText = "Номер";
            PatientNumberTextField.Size = new Size(90, 23);
            PatientNumberTextField.TabIndex = 1;
            // 
            // DateOfBirthTextField
            // 
            DateOfBirthTextField.Location = new Point(523, 5);
            DateOfBirthTextField.Name = "DateOfBirthTextField";
            DateOfBirthTextField.PlaceholderText = "Дата рождения";
            DateOfBirthTextField.Size = new Size(90, 23);
            DateOfBirthTextField.TabIndex = 5;
            // 
            // MiddleNameTextField
            // 
            MiddleNameTextField.Location = new Point(397, 5);
            MiddleNameTextField.Name = "MiddleNameTextField";
            MiddleNameTextField.PlaceholderText = "Отчество";
            MiddleNameTextField.Size = new Size(120, 23);
            MiddleNameTextField.TabIndex = 4;
            // 
            // FirstNameTextField
            // 
            FirstNameTextField.Location = new Point(271, 5);
            FirstNameTextField.Name = "FirstNameTextField";
            FirstNameTextField.PlaceholderText = "Имя";
            FirstNameTextField.Size = new Size(120, 23);
            FirstNameTextField.TabIndex = 3;
            // 
            // TextError
            // 
            TextError.AutoSize = true;
            TextError.BackColor = Color.Transparent;
            TextError.ForeColor = Color.Black;
            TextError.Location = new Point(66, -1);
            TextError.Name = "TextError";
            TextError.Size = new Size(0, 15);
            TextError.TabIndex = 4;
            // 
            // FormPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 448);
            Controls.Add(TextError);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(PatientsTable);
            Name = "FormPatients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пациенты";
            ((System.ComponentModel.ISupportInitialize)PatientsTable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView PatientsTable;
        private TextBox LastNameTextField;
        private Button AddPatientButton;
        private Label label1;
        private Button SearchButton;
        private Button PrevPageButton;
        private Button NextPageButton;
        private Label CountPageTextBox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox DateOfBirthTextField;
        private TextBox MiddleNameTextField;
        private TextBox FirstNameTextField;
        private Label TextError;
        private TextBox PatientNumberTextField;
    }
}