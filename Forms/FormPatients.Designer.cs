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
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            AddPatientButton = new Button();
            label1 = new Label();
            AddRecordButton = new Button();
            OpenRecordsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 397);
            dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Номер", "Фамилия", "Дата Рождения" });
            comboBox1.Location = new Point(194, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(98, 23);
            comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(69, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(119, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // AddPatientButton
            // 
            AddPatientButton.FlatStyle = FlatStyle.Flat;
            AddPatientButton.ForeColor = Color.Black;
            AddPatientButton.Location = new Point(547, 12);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(126, 23);
            AddPatientButton.TabIndex = 3;
            AddPatientButton.Text = "Добавить пациента";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(21, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Поиск";
            label1.Click += label1_Click;
            // 
            // AddRecordButton
            // 
            AddRecordButton.FlatStyle = FlatStyle.Flat;
            AddRecordButton.ForeColor = Color.Black;
            AddRecordButton.Location = new Point(402, 12);
            AddRecordButton.Name = "AddRecordButton";
            AddRecordButton.Size = new Size(123, 23);
            AddRecordButton.TabIndex = 5;
            AddRecordButton.Text = "Добавить Карту";
            AddRecordButton.UseVisualStyleBackColor = true;
            AddRecordButton.Click += button2_Click;
            // 
            // OpenRecordsButton
            // 
            OpenRecordsButton.FlatStyle = FlatStyle.Flat;
            OpenRecordsButton.ForeColor = Color.Black;
            OpenRecordsButton.Location = new Point(308, 12);
            OpenRecordsButton.Name = "OpenRecordsButton";
            OpenRecordsButton.Size = new Size(75, 23);
            OpenRecordsButton.TabIndex = 6;
            OpenRecordsButton.Text = "Открыть";
            OpenRecordsButton.UseVisualStyleBackColor = true;
            OpenRecordsButton.Click += OpenRecordsButton_Click;
            // 
            // FormPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OpenRecordsButton);
            Controls.Add(AddRecordButton);
            Controls.Add(label1);
            Controls.Add(AddPatientButton);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "FormPatients";
            Text = "Пациенты";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button AddPatientButton;
        private Label label1;
        private Button AddRecordButton;
        private Button OpenRecordsButton;
    }
}