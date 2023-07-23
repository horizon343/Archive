namespace Archive.Forms
{
    partial class FormMKB
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
            MKBTable = new DataGridView();
            panel1 = new Panel();
            NextPageButton = new Button();
            PrevPageButton = new Button();
            CountPageTextBox = new Label();
            TextError = new Label();
            panel3 = new Panel();
            label1 = new Label();
            MKBCodeTextField = new TextBox();
            SearchButton = new Button();
            DiseaseTextField = new TextBox();
            ((System.ComponentModel.ISupportInitialize)MKBTable).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // MKBTable
            // 
            MKBTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MKBTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MKBTable.Location = new Point(12, 49);
            MKBTable.Name = "MKBTable";
            MKBTable.RowTemplate.Height = 25;
            MKBTable.Size = new Size(935, 352);
            MKBTable.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.Controls.Add(NextPageButton);
            panel1.Controls.Add(PrevPageButton);
            panel1.Controls.Add(CountPageTextBox);
            panel1.Location = new Point(309, 407);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 29);
            panel1.TabIndex = 10;
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
            TextError.Location = new Point(85, -1);
            TextError.Name = "TextError";
            TextError.Size = new Size(0, 15);
            TextError.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(MKBCodeTextField);
            panel3.Controls.Add(SearchButton);
            panel3.Controls.Add(DiseaseTextField);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 31);
            panel3.TabIndex = 12;
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
            // MKBCodeTextField
            // 
            MKBCodeTextField.Location = new Point(47, 5);
            MKBCodeTextField.Name = "MKBCodeTextField";
            MKBCodeTextField.PlaceholderText = "Код";
            MKBCodeTextField.Size = new Size(90, 23);
            MKBCodeTextField.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.Black;
            SearchButton.Location = new Point(269, 5);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // DiseaseTextField
            // 
            DiseaseTextField.Location = new Point(143, 5);
            DiseaseTextField.Name = "DiseaseTextField";
            DiseaseTextField.PlaceholderText = "Болезнь";
            DiseaseTextField.Size = new Size(120, 23);
            DiseaseTextField.TabIndex = 2;
            // 
            // FormMKB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 448);
            Controls.Add(TextError);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(MKBTable);
            Name = "FormMKB";
            Text = "МКБ";
            ((System.ComponentModel.ISupportInitialize)MKBTable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView MKBTable;
        private Panel panel1;
        private Button NextPageButton;
        private Button PrevPageButton;
        private Label CountPageTextBox;
        private Label TextError;
        private Panel panel3;
        private Label label1;
        private TextBox MKBCodeTextField;
        private TextBox DateOfBirthTextField;
        private TextBox MiddleNameTextField;
        private Button SearchButton;
        private TextBox FirstNameTextField;
        private TextBox DiseaseTextField;
    }
}