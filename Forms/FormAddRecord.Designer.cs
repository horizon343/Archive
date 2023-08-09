namespace Archive.Forms
{
    partial class FormAddRecord
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
            DepartmentSelect = new ComboBox();
            HistoryNumberTextField = new TextBox();
            MKBCodeSelect = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            AddRecord = new Button();
            DateOfDischargeTextField = new TextBox();
            DateOfReceiptTextField = new TextBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            DateOfReceiptErrorText = new Label();
            DateOfDischargeErrorText = new Label();
            DepartmentTextField = new TextBox();
            MKBCodeTextField = new TextBox();
            label6 = new Label();
            StorageLocationSelect = new ComboBox();
            StorageLocationTextField = new TextBox();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // DepartmentSelect
            // 
            DepartmentSelect.FormattingEnabled = true;
            DepartmentSelect.Location = new Point(353, 279);
            DepartmentSelect.Margin = new Padding(3, 4, 3, 4);
            DepartmentSelect.Name = "DepartmentSelect";
            DepartmentSelect.Size = new Size(449, 28);
            DepartmentSelect.TabIndex = 0;
            DepartmentSelect.TabStop = false;
            // 
            // HistoryNumberTextField
            // 
            HistoryNumberTextField.Location = new Point(353, 395);
            HistoryNumberTextField.Margin = new Padding(3, 4, 3, 4);
            HistoryNumberTextField.Name = "HistoryNumberTextField";
            HistoryNumberTextField.Size = new Size(449, 27);
            HistoryNumberTextField.TabIndex = 4;
            // 
            // MKBCodeSelect
            // 
            MKBCodeSelect.FormattingEnabled = true;
            MKBCodeSelect.Location = new Point(353, 433);
            MKBCodeSelect.Margin = new Padding(3, 4, 3, 4);
            MKBCodeSelect.Name = "MKBCodeSelect";
            MKBCodeSelect.Size = new Size(449, 28);
            MKBCodeSelect.TabIndex = 4;
            MKBCodeSelect.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(213, 278);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 5;
            label1.Text = "Отделение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(213, 320);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 6;
            label2.Text = "Дата поступления";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(213, 359);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 7;
            label3.Text = "Дата выписки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(213, 394);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 8;
            label4.Text = "Номер истории";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(213, 436);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 9;
            label5.Text = "Код МКБ";
            // 
            // AddRecord
            // 
            AddRecord.Enabled = false;
            AddRecord.Location = new Point(716, 510);
            AddRecord.Margin = new Padding(3, 4, 3, 4);
            AddRecord.Name = "AddRecord";
            AddRecord.Size = new Size(86, 31);
            AddRecord.TabIndex = 7;
            AddRecord.Text = "Добавить";
            AddRecord.UseVisualStyleBackColor = true;
            AddRecord.Click += AddRecord_Click;
            // 
            // DateOfDischargeTextField
            // 
            DateOfDischargeTextField.Location = new Point(353, 356);
            DateOfDischargeTextField.Margin = new Padding(3, 4, 3, 4);
            DateOfDischargeTextField.Name = "DateOfDischargeTextField";
            DateOfDischargeTextField.Size = new Size(449, 27);
            DateOfDischargeTextField.TabIndex = 3;
            // 
            // DateOfReceiptTextField
            // 
            DateOfReceiptTextField.Location = new Point(353, 317);
            DateOfReceiptTextField.Margin = new Padding(3, 4, 3, 4);
            DateOfReceiptTextField.Name = "DateOfReceiptTextField";
            DateOfReceiptTextField.Size = new Size(449, 27);
            DateOfReceiptTextField.TabIndex = 2;
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
            panelTitleBar.Size = new Size(1125, 107);
            panelTitleBar.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(466, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(169, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Новая карта";
            // 
            // DateOfReceiptErrorText
            // 
            DateOfReceiptErrorText.AutoSize = true;
            DateOfReceiptErrorText.ForeColor = Color.Red;
            DateOfReceiptErrorText.Location = new Point(809, 325);
            DateOfReceiptErrorText.Name = "DateOfReceiptErrorText";
            DateOfReceiptErrorText.Size = new Size(13, 20);
            DateOfReceiptErrorText.TabIndex = 6;
            DateOfReceiptErrorText.Text = " ";
            // 
            // DateOfDischargeErrorText
            // 
            DateOfDischargeErrorText.AutoSize = true;
            DateOfDischargeErrorText.ForeColor = Color.Red;
            DateOfDischargeErrorText.Location = new Point(809, 360);
            DateOfDischargeErrorText.Name = "DateOfDischargeErrorText";
            DateOfDischargeErrorText.Size = new Size(13, 20);
            DateOfDischargeErrorText.TabIndex = 6;
            DateOfDischargeErrorText.Text = " ";
            // 
            // DepartmentTextField
            // 
            DepartmentTextField.Location = new Point(353, 279);
            DepartmentTextField.Margin = new Padding(3, 4, 3, 4);
            DepartmentTextField.Name = "DepartmentTextField";
            DepartmentTextField.Size = new Size(430, 27);
            DepartmentTextField.TabIndex = 1;
            // 
            // MKBCodeTextField
            // 
            MKBCodeTextField.Location = new Point(353, 433);
            MKBCodeTextField.Margin = new Padding(3, 4, 3, 4);
            MKBCodeTextField.Name = "MKBCodeTextField";
            MKBCodeTextField.Size = new Size(430, 27);
            MKBCodeTextField.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(213, 477);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 9;
            label6.Text = "Место хранения";
            // 
            // StorageLocationSelect
            // 
            StorageLocationSelect.FormattingEnabled = true;
            StorageLocationSelect.Location = new Point(353, 474);
            StorageLocationSelect.Margin = new Padding(3, 4, 3, 4);
            StorageLocationSelect.Name = "StorageLocationSelect";
            StorageLocationSelect.Size = new Size(449, 28);
            StorageLocationSelect.TabIndex = 4;
            StorageLocationSelect.TabStop = false;
            // 
            // StorageLocationTextField
            // 
            StorageLocationTextField.Location = new Point(353, 474);
            StorageLocationTextField.Margin = new Padding(3, 4, 3, 4);
            StorageLocationTextField.Name = "StorageLocationTextField";
            StorageLocationTextField.Size = new Size(430, 27);
            StorageLocationTextField.TabIndex = 6;
            // 
            // FormAddRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
            Controls.Add(panelTitleBar);
            Controls.Add(AddRecord);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(DateOfDischargeErrorText);
            Controls.Add(DateOfReceiptErrorText);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DateOfReceiptTextField);
            Controls.Add(DateOfDischargeTextField);
            Controls.Add(StorageLocationTextField);
            Controls.Add(MKBCodeTextField);
            Controls.Add(DepartmentTextField);
            Controls.Add(HistoryNumberTextField);
            Controls.Add(StorageLocationSelect);
            Controls.Add(DepartmentSelect);
            Controls.Add(MKBCodeSelect);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAddRecord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление карты";
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox DepartmentSelect;
        private TextBox HistoryNumberTextField;
        private ComboBox MKBCodeSelect;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button AddRecord;
        private TextBox DateOfDischargeTextField;
        private TextBox DateOfReceiptTextField;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label DateOfReceiptErrorText;
        private Label DateOfDischargeErrorText;
        private TextBox DepartmentTextField;
        private TextBox MKBCodeTextField;
        private Label label6;
        private ComboBox StorageLocationSelect;
        private TextBox StorageLocationTextField;
    }
}