namespace Archive.Forms
{
    partial class FormDepartments
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
            TextError = new Label();
            panel3 = new Panel();
            label1 = new Label();
            DepartmentIDTextField = new TextBox();
            SearchButton = new Button();
            DepartmentTitleTextField = new TextBox();
            DepartmentsTable = new DataGridView();
            panel1 = new Panel();
            NextPageButton = new Button();
            PrevPageButton = new Button();
            CountPageTextBox = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DepartmentsTable).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TextError
            // 
            TextError.AutoSize = true;
            TextError.BackColor = Color.Transparent;
            TextError.ForeColor = Color.Black;
            TextError.Location = new Point(12, 12);
            TextError.Name = "TextError";
            TextError.Size = new Size(0, 15);
            TextError.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(DepartmentIDTextField);
            panel3.Controls.Add(SearchButton);
            panel3.Controls.Add(DepartmentTitleTextField);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 31);
            panel3.TabIndex = 15;
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
            // DepartmentIDTextField
            // 
            DepartmentIDTextField.Location = new Point(47, 5);
            DepartmentIDTextField.Name = "DepartmentIDTextField";
            DepartmentIDTextField.PlaceholderText = "ID";
            DepartmentIDTextField.Size = new Size(90, 23);
            DepartmentIDTextField.TabIndex = 1;
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
            // DepartmentTitleTextField
            // 
            DepartmentTitleTextField.Location = new Point(143, 5);
            DepartmentTitleTextField.Name = "DepartmentTitleTextField";
            DepartmentTitleTextField.PlaceholderText = "Отделение";
            DepartmentTitleTextField.Size = new Size(120, 23);
            DepartmentTitleTextField.TabIndex = 2;
            // 
            // DepartmentsTable
            // 
            DepartmentsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DepartmentsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DepartmentsTable.Location = new Point(12, 49);
            DepartmentsTable.Name = "DepartmentsTable";
            DepartmentsTable.RowTemplate.Height = 25;
            DepartmentsTable.Size = new Size(960, 428);
            DepartmentsTable.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.Controls.Add(NextPageButton);
            panel1.Controls.Add(PrevPageButton);
            panel1.Controls.Add(CountPageTextBox);
            panel1.Location = new Point(322, 483);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 29);
            panel1.TabIndex = 16;
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
            // FormDepartments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 524);
            Controls.Add(panel1);
            Controls.Add(TextError);
            Controls.Add(panel3);
            Controls.Add(DepartmentsTable);
            Name = "FormDepartments";
            Text = "Отделения";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DepartmentsTable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TextError;
        private Panel panel3;
        private Label label1;
        private TextBox DepartmentIDTextField;
        private Button SearchButton;
        private TextBox DepartmentTitleTextField;
        private DataGridView DepartmentsTable;
        private Panel panel1;
        private Button NextPageButton;
        private Button PrevPageButton;
        private Label CountPageTextBox;
    }
}