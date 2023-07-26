namespace Archive.Forms
{
    partial class FormImportData
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
            departments = new Label();
            ImportDepartmentsButton = new Button();
            label1 = new Label();
            ImportMKBButton = new Button();
            label2 = new Label();
            label3 = new Label();
            ImportPatientAndRecordButton = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // departments
            // 
            departments.AutoSize = true;
            departments.ForeColor = SystemColors.Desktop;
            departments.Location = new Point(46, 77);
            departments.Name = "departments";
            departments.Size = new Size(112, 15);
            departments.TabIndex = 0;
            departments.Text = "Импорт отделений";
            // 
            // ImportDepartmentsButton
            // 
            ImportDepartmentsButton.ForeColor = SystemColors.Desktop;
            ImportDepartmentsButton.Location = new Point(207, 73);
            ImportDepartmentsButton.Name = "ImportDepartmentsButton";
            ImportDepartmentsButton.Size = new Size(75, 23);
            ImportDepartmentsButton.TabIndex = 1;
            ImportDepartmentsButton.Text = "Импорт";
            ImportDepartmentsButton.UseVisualStyleBackColor = true;
            ImportDepartmentsButton.Click += ImportDepartmentsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(46, 109);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Импорт МКБ";
            // 
            // ImportMKBButton
            // 
            ImportMKBButton.ForeColor = SystemColors.Desktop;
            ImportMKBButton.Location = new Point(207, 105);
            ImportMKBButton.Name = "ImportMKBButton";
            ImportMKBButton.Size = new Size(75, 23);
            ImportMKBButton.TabIndex = 2;
            ImportMKBButton.Text = "Импорт";
            ImportMKBButton.UseVisualStyleBackColor = true;
            ImportMKBButton.Click += ImportMKBButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(46, 41);
            label2.Name = "label2";
            label2.Size = new Size(348, 15);
            label2.TabIndex = 0;
            label2.Text = "Импорт полностью перезаписывает таблицу в базе данных !!!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(46, 138);
            label3.Name = "label3";
            label3.Size = new Size(149, 15);
            label3.TabIndex = 0;
            label3.Text = "Импорт пациентов и карт";
            // 
            // ImportPatientAndRecordButton
            // 
            ImportPatientAndRecordButton.ForeColor = SystemColors.Desktop;
            ImportPatientAndRecordButton.Location = new Point(207, 134);
            ImportPatientAndRecordButton.Name = "ImportPatientAndRecordButton";
            ImportPatientAndRecordButton.Size = new Size(75, 23);
            ImportPatientAndRecordButton.TabIndex = 2;
            ImportPatientAndRecordButton.Text = "Импорт";
            ImportPatientAndRecordButton.UseVisualStyleBackColor = true;
            ImportPatientAndRecordButton.Click += ImportPatientAndRecordButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(302, 77);
            label4.Name = "label4";
            label4.Size = new Size(435, 15);
            label4.TabIndex = 0;
            label4.Text = "Таблица должна содержать 1 столбец (название отделений) без заголовков";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(302, 109);
            label5.Name = "label5";
            label5.Size = new Size(403, 15);
            label5.TabIndex = 0;
            label5.Text = "Таблица должна содержать 2 столбца (код и название) без заголовков";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Desktop;
            label6.Location = new Point(19, 170);
            label6.Name = "label6";
            label6.Size = new Size(953, 15);
            label6.TabIndex = 0;
            label6.Text = "Таблица пациентов должна содержать 12 столбцов (код, номер, фамилия, имя, отчество, дата рождения, регион, район, город, адрес, телефон, индекс) без заголовков";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(19, 198);
            label7.Name = "label7";
            label7.Size = new Size(840, 15);
            label7.TabIndex = 0;
            label7.Text = "Таблица карт должна содержать 6 столбцов (номер пациента, дата поступления, дата выписки, отделение, номер истории, МКБ) без заголовков";
            // 
            // FormImportData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 524);
            Controls.Add(ImportPatientAndRecordButton);
            Controls.Add(ImportMKBButton);
            Controls.Add(label3);
            Controls.Add(ImportDepartmentsButton);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(departments);
            Name = "FormImportData";
            Text = "Import Data";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label departments;
        private Button ImportDepartmentsButton;
        private Label label1;
        private Button ImportMKBButton;
        private Label label2;
        private Label label3;
        private Button ImportPatientAndRecordButton;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}