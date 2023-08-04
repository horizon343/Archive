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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            PatientsTable.DefaultCellStyle = dataGridViewCellStyle3;
            PatientsTable.Location = new Point(12, 64);
            PatientsTable.Margin = new Padding(3, 4, 3, 4);
            PatientsTable.Name = "PatientsTable";
            PatientsTable.RowHeadersWidth = 51;
            PatientsTable.RowTemplate.Height = 25;
            PatientsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PatientsTable.Size = new Size(1101, 572);
            PatientsTable.TabIndex = 0;
            PatientsTable.TabStop = false;
            // 
            // LastNameTextField
            // 
            LastNameTextField.Location = new Point(169, 7);
            LastNameTextField.Margin = new Padding(3, 4, 3, 4);
            LastNameTextField.Name = "LastNameTextField";
            LastNameTextField.PlaceholderText = "Фамилия";
            LastNameTextField.Size = new Size(137, 27);
            LastNameTextField.TabIndex = 2;
            // 
            // AddPatientButton
            // 
            AddPatientButton.ForeColor = Color.Black;
            AddPatientButton.Location = new Point(5, 7);
            AddPatientButton.Margin = new Padding(3, 4, 3, 4);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(144, 33);
            AddPatientButton.TabIndex = 7;
            AddPatientButton.Text = "Добавить пациента";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += AddPatientButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 4;
            label1.Text = "Поиск";
            // 
            // SearchButton
            // 
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(724, 4);
            SearchButton.Margin = new Padding(3, 4, 3, 4);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(86, 33);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // PrevPageButton
            // 
            PrevPageButton.ForeColor = Color.Black;
            PrevPageButton.Location = new Point(0, 4);
            PrevPageButton.Margin = new Padding(3, 4, 3, 4);
            PrevPageButton.Name = "PrevPageButton";
            PrevPageButton.Size = new Size(141, 33);
            PrevPageButton.TabIndex = 8;
            PrevPageButton.Text = "Предыдущая";
            PrevPageButton.UseVisualStyleBackColor = true;
            PrevPageButton.Click += PrevPageButton_Click;
            // 
            // NextPageButton
            // 
            NextPageButton.ForeColor = Color.Black;
            NextPageButton.Location = new Point(243, 4);
            NextPageButton.Margin = new Padding(3, 4, 3, 4);
            NextPageButton.Name = "NextPageButton";
            NextPageButton.Size = new Size(141, 33);
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
            CountPageTextBox.Location = new Point(150, 9);
            CountPageTextBox.MinimumSize = new Size(86, 0);
            CountPageTextBox.Name = "CountPageTextBox";
            CountPageTextBox.Size = new Size(86, 20);
            CountPageTextBox.TabIndex = 4;
            CountPageTextBox.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.Controls.Add(NextPageButton);
            panel1.Controls.Add(PrevPageButton);
            panel1.Controls.Add(CountPageTextBox);
            panel1.Location = new Point(375, 644);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(390, 42);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(AddPatientButton);
            panel2.Location = new Point(961, 13);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(152, 43);
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
            panel3.Location = new Point(12, 13);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(817, 43);
            panel3.TabIndex = 9;
            // 
            // PatientNumberTextField
            // 
            PatientNumberTextField.Location = new Point(61, 7);
            PatientNumberTextField.Margin = new Padding(3, 4, 3, 4);
            PatientNumberTextField.Name = "PatientNumberTextField";
            PatientNumberTextField.PlaceholderText = "Номер";
            PatientNumberTextField.Size = new Size(102, 27);
            PatientNumberTextField.TabIndex = 1;
            // 
            // DateOfBirthTextField
            // 
            DateOfBirthTextField.Location = new Point(598, 7);
            DateOfBirthTextField.Margin = new Padding(3, 4, 3, 4);
            DateOfBirthTextField.Name = "DateOfBirthTextField";
            DateOfBirthTextField.PlaceholderText = "Дата рождения";
            DateOfBirthTextField.Size = new Size(120, 27);
            DateOfBirthTextField.TabIndex = 5;
            // 
            // MiddleNameTextField
            // 
            MiddleNameTextField.Location = new Point(455, 7);
            MiddleNameTextField.Margin = new Padding(3, 4, 3, 4);
            MiddleNameTextField.Name = "MiddleNameTextField";
            MiddleNameTextField.PlaceholderText = "Отчество";
            MiddleNameTextField.Size = new Size(137, 27);
            MiddleNameTextField.TabIndex = 4;
            // 
            // FirstNameTextField
            // 
            FirstNameTextField.Location = new Point(312, 7);
            FirstNameTextField.Margin = new Padding(3, 4, 3, 4);
            FirstNameTextField.Name = "FirstNameTextField";
            FirstNameTextField.PlaceholderText = "Имя";
            FirstNameTextField.Size = new Size(137, 27);
            FirstNameTextField.TabIndex = 3;
            // 
            // FormPatients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(PatientsTable);
            Margin = new Padding(3, 4, 3, 4);
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
        private TextBox PatientNumberTextField;
    }
}