namespace Archive.Forms
{
    partial class FormRecords
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
            RecordsTable = new DataGridView();
            panel3 = new Panel();
            label1 = new Label();
            HistoryNumberTextField = new TextBox();
            MKBCodeTextField = new TextBox();
            DateOfDischargeTextField = new TextBox();
            SearchButton = new Button();
            DateOfReceiptTextField = new TextBox();
            DepartmentTextField = new TextBox();
            panel1 = new Panel();
            NextPageButton = new Button();
            PrevPageButton = new Button();
            CountPageTextBox = new Label();
            TextError = new Label();
            ((System.ComponentModel.ISupportInitialize)RecordsTable).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // RecordsTable
            // 
            RecordsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RecordsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RecordsTable.Location = new Point(12, 50);
            RecordsTable.Name = "RecordsTable";
            RecordsTable.RowTemplate.Height = 25;
            RecordsTable.Size = new Size(935, 352);
            RecordsTable.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(HistoryNumberTextField);
            panel3.Controls.Add(MKBCodeTextField);
            panel3.Controls.Add(DateOfDischargeTextField);
            panel3.Controls.Add(SearchButton);
            panel3.Controls.Add(DateOfReceiptTextField);
            panel3.Controls.Add(DepartmentTextField);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(701, 31);
            panel3.TabIndex = 10;
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
            // HistoryNumberTextField
            // 
            HistoryNumberTextField.Location = new Point(47, 5);
            HistoryNumberTextField.Name = "HistoryNumberTextField";
            HistoryNumberTextField.PlaceholderText = "Номер";
            HistoryNumberTextField.Size = new Size(90, 23);
            HistoryNumberTextField.TabIndex = 1;
            // 
            // MKBCodeTextField
            // 
            MKBCodeTextField.Location = new Point(523, 5);
            MKBCodeTextField.Name = "MKBCodeTextField";
            MKBCodeTextField.PlaceholderText = "МКБ";
            MKBCodeTextField.Size = new Size(90, 23);
            MKBCodeTextField.TabIndex = 5;
            // 
            // DateOfDischargeTextField
            // 
            DateOfDischargeTextField.Location = new Point(397, 5);
            DateOfDischargeTextField.Name = "DateOfDischargeTextField";
            DateOfDischargeTextField.PlaceholderText = "Дата выписки";
            DateOfDischargeTextField.Size = new Size(120, 23);
            DateOfDischargeTextField.TabIndex = 4;
            DateOfDischargeTextField.TextChanged += DateOfDischargeTextField_TextChanged;
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
            // DateOfReceiptTextField
            // 
            DateOfReceiptTextField.Location = new Point(271, 5);
            DateOfReceiptTextField.Name = "DateOfReceiptTextField";
            DateOfReceiptTextField.PlaceholderText = "Дата поступления";
            DateOfReceiptTextField.Size = new Size(120, 23);
            DateOfReceiptTextField.TabIndex = 3;
            DateOfReceiptTextField.TextChanged += DateOfReceiptTextField_TextChanged;
            // 
            // DepartmentTextField
            // 
            DepartmentTextField.Location = new Point(143, 5);
            DepartmentTextField.Name = "DepartmentTextField";
            DepartmentTextField.PlaceholderText = "Отделение";
            DepartmentTextField.Size = new Size(120, 23);
            DepartmentTextField.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.Controls.Add(NextPageButton);
            panel1.Controls.Add(PrevPageButton);
            panel1.Controls.Add(CountPageTextBox);
            panel1.Location = new Point(309, 408);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 29);
            panel1.TabIndex = 11;
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
            // FormRecords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 448);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(RecordsTable);
            Controls.Add(TextError);
            Name = "FormRecords";
            Text = "Карты";
            ((System.ComponentModel.ISupportInitialize)RecordsTable).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView RecordsTable;
        private Panel panel3;
        private Label label1;
        private TextBox HistoryNumberTextField;
        private TextBox MKBCodeTextField;
        private TextBox DateOfDischargeTextField;
        private Button SearchButton;
        private TextBox DateOfReceiptTextField;
        private TextBox DepartmentTextField;
        private Panel panel1;
        private Button NextPageButton;
        private Button PrevPageButton;
        private Label TextError;
        private Label CountPageTextBox;
    }
}