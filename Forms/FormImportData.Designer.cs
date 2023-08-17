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
            ExampleImportDepartments = new Button();
            ExampleImportMKB = new Button();
            ExampleImportPatientAndRecord = new Button();
            ExportDepartmentButton = new Button();
            ExportMKBButton = new Button();
            ExportPatientAndRecordButton = new Button();
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
            ImportPatientAndRecordButton.TabIndex = 3;
            ImportPatientAndRecordButton.Text = "Импорт";
            ImportPatientAndRecordButton.UseVisualStyleBackColor = true;
            ImportPatientAndRecordButton.Click += ImportPatientAndRecordButton_Click;
            // 
            // ExampleImportDepartments
            // 
            ExampleImportDepartments.ForeColor = SystemColors.Desktop;
            ExampleImportDepartments.Location = new Point(357, 62);
            ExampleImportDepartments.Margin = new Padding(3, 4, 3, 4);
            ExampleImportDepartments.Name = "ExampleImportDepartments";
            ExampleImportDepartments.Size = new Size(153, 31);
            ExampleImportDepartments.TabIndex = 4;
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
            ExampleImportMKB.TabIndex = 5;
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
            ExampleImportPatientAndRecord.TabIndex = 6;
            ExampleImportPatientAndRecord.Text = "Пример импорта";
            ExampleImportPatientAndRecord.UseVisualStyleBackColor = true;
            ExampleImportPatientAndRecord.Click += ExampleImportPatientAndRecord_Click;
            // 
            // ExportDepartmentButton
            // 
            ExportDepartmentButton.ForeColor = SystemColors.Desktop;
            ExportDepartmentButton.Location = new Point(516, 62);
            ExportDepartmentButton.Margin = new Padding(3, 4, 3, 4);
            ExportDepartmentButton.Name = "ExportDepartmentButton";
            ExportDepartmentButton.Size = new Size(102, 31);
            ExportDepartmentButton.TabIndex = 1;
            ExportDepartmentButton.Text = "Экспорт";
            ExportDepartmentButton.UseVisualStyleBackColor = true;
            ExportDepartmentButton.Click += ExportDepartmentButton_Click;
            // 
            // ExportMKBButton
            // 
            ExportMKBButton.ForeColor = SystemColors.Desktop;
            ExportMKBButton.Location = new Point(516, 105);
            ExportMKBButton.Margin = new Padding(3, 4, 3, 4);
            ExportMKBButton.Name = "ExportMKBButton";
            ExportMKBButton.Size = new Size(102, 31);
            ExportMKBButton.TabIndex = 1;
            ExportMKBButton.Text = "Экспорт";
            ExportMKBButton.UseVisualStyleBackColor = true;
            ExportMKBButton.Click += ExportMKBButton_Click;
            // 
            // ExportPatientAndRecordButton
            // 
            ExportPatientAndRecordButton.ForeColor = SystemColors.Desktop;
            ExportPatientAndRecordButton.Location = new Point(516, 144);
            ExportPatientAndRecordButton.Margin = new Padding(3, 4, 3, 4);
            ExportPatientAndRecordButton.Name = "ExportPatientAndRecordButton";
            ExportPatientAndRecordButton.Size = new Size(102, 31);
            ExportPatientAndRecordButton.TabIndex = 1;
            ExportPatientAndRecordButton.Text = "Экспорт";
            ExportPatientAndRecordButton.UseVisualStyleBackColor = true;
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
            Controls.Add(ExportPatientAndRecordButton);
            Controls.Add(ExportMKBButton);
            Controls.Add(ExportDepartmentButton);
            Controls.Add(ImportDepartmentsButton);
            Controls.Add(label1);
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
        private Button ExampleImportDepartments;
        private Button ExampleImportMKB;
        private Button ExampleImportPatientAndRecord;
        private Button ExportDepartmentButton;
        private Button ExportMKBButton;
        private Button ExportPatientAndRecordButton;
    }
}