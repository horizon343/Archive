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
            label3 = new Label();
            ImportPatientAndRecordButton = new Button();
            label6 = new Label();
            label7 = new Label();
            ExampleImportDepartments = new Button();
            ExampleImportMKB = new Button();
            ExampleImportPatientAndRecord = new Button();
            SuspendLayout();
            // 
            // departments
            // 
            departments.AutoSize = true;
            departments.ForeColor = SystemColors.Desktop;
            departments.Location = new Point(53, 67);
            departments.Name = "departments";
            departments.Size = new Size(142, 20);
            departments.TabIndex = 0;
            departments.Text = "Импорт отделений";
            // 
            // ImportDepartmentsButton
            // 
            ImportDepartmentsButton.ForeColor = SystemColors.Desktop;
            ImportDepartmentsButton.Location = new Point(249, 62);
            ImportDepartmentsButton.Margin = new Padding(3, 4, 3, 4);
            ImportDepartmentsButton.Name = "ImportDepartmentsButton";
            ImportDepartmentsButton.Size = new Size(102, 31);
            ImportDepartmentsButton.TabIndex = 1;
            ImportDepartmentsButton.Text = "Импорт";
            ImportDepartmentsButton.UseVisualStyleBackColor = true;
            ImportDepartmentsButton.Click += ImportDepartmentsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(53, 110);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Импорт МКБ";
            // 
            // ImportMKBButton
            // 
            ImportMKBButton.ForeColor = SystemColors.Desktop;
            ImportMKBButton.Location = new Point(249, 105);
            ImportMKBButton.Margin = new Padding(3, 4, 3, 4);
            ImportMKBButton.Name = "ImportMKBButton";
            ImportMKBButton.Size = new Size(102, 31);
            ImportMKBButton.TabIndex = 2;
            ImportMKBButton.Text = "Импорт";
            ImportMKBButton.UseVisualStyleBackColor = true;
            ImportMKBButton.Click += ImportMKBButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(53, 149);
            label3.Name = "label3";
            label3.Size = new Size(190, 20);
            label3.TabIndex = 0;
            label3.Text = "Импорт пациентов и карт";
            // 
            // ImportPatientAndRecordButton
            // 
            ImportPatientAndRecordButton.ForeColor = SystemColors.Desktop;
            ImportPatientAndRecordButton.Location = new Point(249, 144);
            ImportPatientAndRecordButton.Margin = new Padding(3, 4, 3, 4);
            ImportPatientAndRecordButton.Name = "ImportPatientAndRecordButton";
            ImportPatientAndRecordButton.Size = new Size(102, 31);
            ImportPatientAndRecordButton.TabIndex = 2;
            ImportPatientAndRecordButton.Text = "Импорт";
            ImportPatientAndRecordButton.UseVisualStyleBackColor = true;
            ImportPatientAndRecordButton.Click += ImportPatientAndRecordButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Desktop;
            label6.Location = new Point(22, 227);
            label6.Name = "label6";
            label6.Size = new Size(1171, 20);
            label6.TabIndex = 0;
            label6.Text = "Таблица пациентов должна содержать 12 столбцов (код, номер, фамилия, имя, отчество, дата рождения, регион, район, город, адрес, телефон, индекс) без заголовков";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(22, 264);
            label7.Name = "label7";
            label7.Size = new Size(1033, 20);
            label7.TabIndex = 0;
            label7.Text = "Таблица карт должна содержать 6 столбцов (номер пациента, дата поступления, дата выписки, отделение, номер истории, МКБ) без заголовков";
            // 
            // ExampleImportDepartments
            // 
            ExampleImportDepartments.ForeColor = SystemColors.Desktop;
            ExampleImportDepartments.Location = new Point(357, 62);
            ExampleImportDepartments.Margin = new Padding(3, 4, 3, 4);
            ExampleImportDepartments.Name = "ExampleImportDepartments";
            ExampleImportDepartments.Size = new Size(153, 31);
            ExampleImportDepartments.TabIndex = 1;
            ExampleImportDepartments.Text = "Пример импорта";
            ExampleImportDepartments.UseVisualStyleBackColor = true;
            ExampleImportDepartments.Click += ExampleImportDepartments_Click;
            // 
            // ExampleImportMKB
            // 
            ExampleImportMKB.ForeColor = SystemColors.Desktop;
            ExampleImportMKB.Location = new Point(357, 105);
            ExampleImportMKB.Margin = new Padding(3, 4, 3, 4);
            ExampleImportMKB.Name = "ExampleImportMKB";
            ExampleImportMKB.Size = new Size(153, 31);
            ExampleImportMKB.TabIndex = 1;
            ExampleImportMKB.Text = "Пример импорта";
            ExampleImportMKB.UseVisualStyleBackColor = true;
            ExampleImportMKB.Click += ExampleImportMKB_Click;
            // 
            // ExampleImportPatientAndRecord
            // 
            ExampleImportPatientAndRecord.ForeColor = SystemColors.Desktop;
            ExampleImportPatientAndRecord.Location = new Point(357, 144);
            ExampleImportPatientAndRecord.Margin = new Padding(3, 4, 3, 4);
            ExampleImportPatientAndRecord.Name = "ExampleImportPatientAndRecord";
            ExampleImportPatientAndRecord.Size = new Size(153, 31);
            ExampleImportPatientAndRecord.TabIndex = 1;
            ExampleImportPatientAndRecord.Text = "Пример импорта";
            ExampleImportPatientAndRecord.UseVisualStyleBackColor = true;
            ExampleImportPatientAndRecord.Click += ExampleImportPatientAndRecord_Click;
            // 
            // FormImportData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
            Controls.Add(ImportPatientAndRecordButton);
            Controls.Add(ImportMKBButton);
            Controls.Add(label3);
            Controls.Add(ExampleImportPatientAndRecord);
            Controls.Add(ExampleImportMKB);
            Controls.Add(ExampleImportDepartments);
            Controls.Add(ImportDepartmentsButton);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(departments);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormImportData";
            Text = "Импорт и экспорт";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label departments;
        private Button ImportDepartmentsButton;
        private Label label1;
        private Button ImportMKBButton;
        private Label label3;
        private Button ImportPatientAndRecordButton;
        private Label label6;
        private Label label7;
        private Button ExampleImportDepartments;
        private Button ExampleImportMKB;
        private Button ExampleImportPatientAndRecord;
    }
}