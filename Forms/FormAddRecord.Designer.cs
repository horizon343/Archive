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
            HistoryNumberErrorText = new Label();
            DepartmentTextField = new TextBox();
            MKBCodeTextField = new TextBox();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // DepartmentSelect
            // 
            DepartmentSelect.FormattingEnabled = true;
            DepartmentSelect.Location = new Point(298, 194);
            DepartmentSelect.Name = "DepartmentSelect";
            DepartmentSelect.Size = new Size(393, 23);
            DepartmentSelect.TabIndex = 0;
            DepartmentSelect.TabStop = false;
            // 
            // HistoryNumberTextField
            // 
            HistoryNumberTextField.Location = new Point(298, 281);
            HistoryNumberTextField.Name = "HistoryNumberTextField";
            HistoryNumberTextField.Size = new Size(393, 23);
            HistoryNumberTextField.TabIndex = 4;
            // 
            // MKBCodeSelect
            // 
            MKBCodeSelect.FormattingEnabled = true;
            MKBCodeSelect.Location = new Point(298, 310);
            MKBCodeSelect.Name = "MKBCodeSelect";
            MKBCodeSelect.Size = new Size(393, 23);
            MKBCodeSelect.TabIndex = 4;
            MKBCodeSelect.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(186, 197);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 5;
            label1.Text = "Отделение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(186, 229);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 6;
            label2.Text = "Дата поступления";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(186, 258);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 7;
            label3.Text = "Дата выписки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(186, 284);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 8;
            label4.Text = "Номер истории";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(186, 313);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "Код МКБ";
            // 
            // AddRecord
            // 
            AddRecord.Location = new Point(616, 339);
            AddRecord.Name = "AddRecord";
            AddRecord.Size = new Size(75, 23);
            AddRecord.TabIndex = 6;
            AddRecord.Text = "Добавить";
            AddRecord.UseVisualStyleBackColor = true;
            AddRecord.Click += AddRecord_Click;
            // 
            // DateOfDischargeTextField
            // 
            DateOfDischargeTextField.Location = new Point(298, 252);
            DateOfDischargeTextField.Name = "DateOfDischargeTextField";
            DateOfDischargeTextField.Size = new Size(393, 23);
            DateOfDischargeTextField.TabIndex = 3;
            // 
            // DateOfReceiptTextField
            // 
            DateOfReceiptTextField.Location = new Point(298, 223);
            DateOfReceiptTextField.Name = "DateOfReceiptTextField";
            DateOfReceiptTextField.Size = new Size(393, 23);
            DateOfReceiptTextField.TabIndex = 2;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(255, 128, 0);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(984, 80);
            panelTitleBar.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(433, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(137, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Новая карта";
            // 
            // DateOfReceiptErrorText
            // 
            DateOfReceiptErrorText.AutoSize = true;
            DateOfReceiptErrorText.ForeColor = Color.Black;
            DateOfReceiptErrorText.Location = new Point(697, 229);
            DateOfReceiptErrorText.Name = "DateOfReceiptErrorText";
            DateOfReceiptErrorText.Size = new Size(10, 15);
            DateOfReceiptErrorText.TabIndex = 6;
            DateOfReceiptErrorText.Text = " ";
            // 
            // DateOfDischargeErrorText
            // 
            DateOfDischargeErrorText.AutoSize = true;
            DateOfDischargeErrorText.ForeColor = Color.Black;
            DateOfDischargeErrorText.Location = new Point(697, 255);
            DateOfDischargeErrorText.Name = "DateOfDischargeErrorText";
            DateOfDischargeErrorText.Size = new Size(10, 15);
            DateOfDischargeErrorText.TabIndex = 6;
            DateOfDischargeErrorText.Text = " ";
            // 
            // HistoryNumberErrorText
            // 
            HistoryNumberErrorText.AutoSize = true;
            HistoryNumberErrorText.ForeColor = Color.Black;
            HistoryNumberErrorText.Location = new Point(697, 289);
            HistoryNumberErrorText.Name = "HistoryNumberErrorText";
            HistoryNumberErrorText.Size = new Size(10, 15);
            HistoryNumberErrorText.TabIndex = 6;
            HistoryNumberErrorText.Text = " ";
            // 
            // DepartmentTextField
            // 
            DepartmentTextField.Location = new Point(298, 194);
            DepartmentTextField.Name = "DepartmentTextField";
            DepartmentTextField.Size = new Size(377, 23);
            DepartmentTextField.TabIndex = 1;
            // 
            // MKBCodeTextField
            // 
            MKBCodeTextField.Location = new Point(298, 310);
            MKBCodeTextField.Name = "MKBCodeTextField";
            MKBCodeTextField.Size = new Size(377, 23);
            MKBCodeTextField.TabIndex = 5;
            // 
            // FormAddRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 524);
            Controls.Add(panelTitleBar);
            Controls.Add(AddRecord);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(HistoryNumberErrorText);
            Controls.Add(DateOfDischargeErrorText);
            Controls.Add(DateOfReceiptErrorText);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DateOfReceiptTextField);
            Controls.Add(DateOfDischargeTextField);
            Controls.Add(MKBCodeTextField);
            Controls.Add(DepartmentTextField);
            Controls.Add(HistoryNumberTextField);
            Controls.Add(DepartmentSelect);
            Controls.Add(MKBCodeSelect);
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
        private Label HistoryNumberErrorText;
        private TextBox DepartmentTextField;
        private TextBox MKBCodeTextField;
    }
}