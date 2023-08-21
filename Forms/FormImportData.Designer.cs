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
            label2 = new Label();
            ExportStorageLocation = new Button();
            ExampleImportStorageLocation = new Button();
            ImportStorageLocation = new Button();
            ImportNewPatientAndRecord = new Button();
            ExampleImportNewPatientAndRecord = new Button();
            ProgressLabel = new Label();
            ProgressLabel2 = new Label();
            SuspendLayout();
            // 
            // departments
            // 
            departments.AutoSize = true;
            departments.ForeColor = SystemColors.Desktop;
            departments.Location = new Point(53, 69);
            departments.Name = "departments";
            departments.Size = new Size(84, 20);
            departments.TabIndex = 0;
            departments.Text = "Отделения";
            // 
            // ImportDepartmentsButton
            // 
            ImportDepartmentsButton.ForeColor = SystemColors.Desktop;
            ImportDepartmentsButton.Location = new Point(208, 64);
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
            label1.Location = new Point(53, 112);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 0;
            label1.Text = "МКБ";
            // 
            // ImportMKBButton
            // 
            ImportMKBButton.ForeColor = SystemColors.Desktop;
            ImportMKBButton.Location = new Point(208, 107);
            ImportMKBButton.Margin = new Padding(3, 4, 3, 4);
            ImportMKBButton.Name = "ImportMKBButton";
            ImportMKBButton.Size = new Size(102, 31);
            ImportMKBButton.TabIndex = 4;
            ImportMKBButton.Text = "Импорт";
            ImportMKBButton.UseVisualStyleBackColor = true;
            ImportMKBButton.Click += ImportMKBButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(53, 151);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 0;
            label3.Text = "Пациенты и карты";
            // 
            // ImportPatientAndRecordButton
            // 
            ImportPatientAndRecordButton.ForeColor = SystemColors.Desktop;
            ImportPatientAndRecordButton.Location = new Point(583, 146);
            ImportPatientAndRecordButton.Margin = new Padding(3, 4, 3, 4);
            ImportPatientAndRecordButton.Name = "ImportPatientAndRecordButton";
            ImportPatientAndRecordButton.Size = new Size(189, 31);
            ImportPatientAndRecordButton.TabIndex = 10;
            ImportPatientAndRecordButton.Text = "Импорт из старой базы";
            ImportPatientAndRecordButton.UseVisualStyleBackColor = true;
            ImportPatientAndRecordButton.Click += ImportPatientAndRecordButton_Click;
            // 
            // ExampleImportDepartments
            // 
            ExampleImportDepartments.ForeColor = SystemColors.Desktop;
            ExampleImportDepartments.Location = new Point(316, 64);
            ExampleImportDepartments.Margin = new Padding(3, 4, 3, 4);
            ExampleImportDepartments.Name = "ExampleImportDepartments";
            ExampleImportDepartments.Size = new Size(153, 31);
            ExampleImportDepartments.TabIndex = 2;
            ExampleImportDepartments.Text = "Пример импорта";
            ExampleImportDepartments.UseVisualStyleBackColor = true;
            ExampleImportDepartments.Click += ExampleImportDepartments_Click;
            // 
            // ExampleImportMKB
            // 
            ExampleImportMKB.ForeColor = SystemColors.Desktop;
            ExampleImportMKB.Location = new Point(316, 107);
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
            ExampleImportPatientAndRecord.Location = new Point(778, 146);
            ExampleImportPatientAndRecord.Margin = new Padding(3, 4, 3, 4);
            ExampleImportPatientAndRecord.Name = "ExampleImportPatientAndRecord";
            ExampleImportPatientAndRecord.Size = new Size(262, 31);
            ExampleImportPatientAndRecord.TabIndex = 11;
            ExampleImportPatientAndRecord.Text = "Пример импорта из старой базы";
            ExampleImportPatientAndRecord.UseVisualStyleBackColor = true;
            ExampleImportPatientAndRecord.Click += ExampleImportPatientAndRecord_Click;
            // 
            // ExportDepartmentButton
            // 
            ExportDepartmentButton.ForeColor = SystemColors.Desktop;
            ExportDepartmentButton.Location = new Point(475, 64);
            ExportDepartmentButton.Margin = new Padding(3, 4, 3, 4);
            ExportDepartmentButton.Name = "ExportDepartmentButton";
            ExportDepartmentButton.Size = new Size(102, 31);
            ExportDepartmentButton.TabIndex = 3;
            ExportDepartmentButton.Text = "Экспорт";
            ExportDepartmentButton.UseVisualStyleBackColor = true;
            ExportDepartmentButton.Click += ExportDepartmentButton_Click;
            // 
            // ExportMKBButton
            // 
            ExportMKBButton.ForeColor = SystemColors.Desktop;
            ExportMKBButton.Location = new Point(475, 107);
            ExportMKBButton.Margin = new Padding(3, 4, 3, 4);
            ExportMKBButton.Name = "ExportMKBButton";
            ExportMKBButton.Size = new Size(102, 31);
            ExportMKBButton.TabIndex = 6;
            ExportMKBButton.Text = "Экспорт";
            ExportMKBButton.UseVisualStyleBackColor = true;
            ExportMKBButton.Click += ExportMKBButton_Click;
            // 
            // ExportPatientAndRecordButton
            // 
            ExportPatientAndRecordButton.ForeColor = SystemColors.Desktop;
            ExportPatientAndRecordButton.Location = new Point(475, 146);
            ExportPatientAndRecordButton.Margin = new Padding(3, 4, 3, 4);
            ExportPatientAndRecordButton.Name = "ExportPatientAndRecordButton";
            ExportPatientAndRecordButton.Size = new Size(102, 31);
            ExportPatientAndRecordButton.TabIndex = 9;
            ExportPatientAndRecordButton.Text = "Экспорт";
            ExportPatientAndRecordButton.UseVisualStyleBackColor = true;
            ExportPatientAndRecordButton.Click += ExportPatientAndRecordButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(53, 190);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 0;
            label2.Text = "Место хранения";
            // 
            // ExportStorageLocation
            // 
            ExportStorageLocation.ForeColor = SystemColors.Desktop;
            ExportStorageLocation.Location = new Point(475, 185);
            ExportStorageLocation.Margin = new Padding(3, 4, 3, 4);
            ExportStorageLocation.Name = "ExportStorageLocation";
            ExportStorageLocation.Size = new Size(102, 31);
            ExportStorageLocation.TabIndex = 14;
            ExportStorageLocation.Text = "Экспорт";
            ExportStorageLocation.UseVisualStyleBackColor = true;
            ExportStorageLocation.Click += ExportStorageLocation_Click;
            // 
            // ExampleImportStorageLocation
            // 
            ExampleImportStorageLocation.ForeColor = SystemColors.Desktop;
            ExampleImportStorageLocation.Location = new Point(316, 185);
            ExampleImportStorageLocation.Margin = new Padding(3, 4, 3, 4);
            ExampleImportStorageLocation.Name = "ExampleImportStorageLocation";
            ExampleImportStorageLocation.Size = new Size(153, 31);
            ExampleImportStorageLocation.TabIndex = 13;
            ExampleImportStorageLocation.Text = "Пример импорта";
            ExampleImportStorageLocation.UseVisualStyleBackColor = true;
            ExampleImportStorageLocation.Click += ExampleImportStorageLocation_Click;
            // 
            // ImportStorageLocation
            // 
            ImportStorageLocation.ForeColor = SystemColors.Desktop;
            ImportStorageLocation.Location = new Point(208, 185);
            ImportStorageLocation.Margin = new Padding(3, 4, 3, 4);
            ImportStorageLocation.Name = "ImportStorageLocation";
            ImportStorageLocation.Size = new Size(102, 31);
            ImportStorageLocation.TabIndex = 12;
            ImportStorageLocation.Text = "Импорт";
            ImportStorageLocation.UseVisualStyleBackColor = true;
            ImportStorageLocation.Click += ImportStorageLocation_Click;
            // 
            // ImportNewPatientAndRecord
            // 
            ImportNewPatientAndRecord.ForeColor = SystemColors.Desktop;
            ImportNewPatientAndRecord.Location = new Point(208, 146);
            ImportNewPatientAndRecord.Margin = new Padding(3, 4, 3, 4);
            ImportNewPatientAndRecord.Name = "ImportNewPatientAndRecord";
            ImportNewPatientAndRecord.Size = new Size(102, 31);
            ImportNewPatientAndRecord.TabIndex = 7;
            ImportNewPatientAndRecord.Text = "Импорт";
            ImportNewPatientAndRecord.UseVisualStyleBackColor = true;
            ImportNewPatientAndRecord.Click += ImportNewPatientAndRecord_Click;
            // 
            // ExampleImportNewPatientAndRecord
            // 
            ExampleImportNewPatientAndRecord.ForeColor = SystemColors.Desktop;
            ExampleImportNewPatientAndRecord.Location = new Point(316, 146);
            ExampleImportNewPatientAndRecord.Margin = new Padding(3, 4, 3, 4);
            ExampleImportNewPatientAndRecord.Name = "ExampleImportNewPatientAndRecord";
            ExampleImportNewPatientAndRecord.Size = new Size(153, 31);
            ExampleImportNewPatientAndRecord.TabIndex = 8;
            ExampleImportNewPatientAndRecord.Text = "Пример импорта";
            ExampleImportNewPatientAndRecord.UseVisualStyleBackColor = true;
            ExampleImportNewPatientAndRecord.Click += ExampleImportNewPatientAndRecord_Click;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ProgressLabel.ForeColor = SystemColors.Desktop;
            ProgressLabel.Location = new Point(12, 9);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(0, 32);
            ProgressLabel.TabIndex = 0;
            // 
            // ProgressLabel2
            // 
            ProgressLabel2.AutoSize = true;
            ProgressLabel2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ProgressLabel2.ForeColor = SystemColors.Desktop;
            ProgressLabel2.Location = new Point(210, 9);
            ProgressLabel2.Name = "ProgressLabel2";
            ProgressLabel2.Size = new Size(0, 32);
            ProgressLabel2.TabIndex = 0;
            // 
            // FormImportData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
            Controls.Add(ImportStorageLocation);
            Controls.Add(ImportPatientAndRecordButton);
            Controls.Add(ImportNewPatientAndRecord);
            Controls.Add(ImportMKBButton);
            Controls.Add(label2);
            Controls.Add(ExampleImportStorageLocation);
            Controls.Add(label3);
            Controls.Add(ExampleImportPatientAndRecord);
            Controls.Add(ExampleImportNewPatientAndRecord);
            Controls.Add(ExampleImportMKB);
            Controls.Add(ExportStorageLocation);
            Controls.Add(ExampleImportDepartments);
            Controls.Add(ExportPatientAndRecordButton);
            Controls.Add(ExportMKBButton);
            Controls.Add(ExportDepartmentButton);
            Controls.Add(ImportDepartmentsButton);
            Controls.Add(label1);
            Controls.Add(ProgressLabel2);
            Controls.Add(ProgressLabel);
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
        private Label label2;
        private Button ExportStorageLocation;
        private Button ExampleImportStorageLocation;
        private Button ImportStorageLocation;
        private Button ImportNewPatientAndRecord;
        private Button ExampleImportNewPatientAndRecord;
        private Label ProgressLabel;
        private Label ProgressLabel2;
    }
}