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
            DepartmentComboBox = new ComboBox();
            HistoryNumberTextBox1 = new TextBox();
            MKBComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            AddRecordButton = new Button();
            DischargeDateTextBox = new TextBox();
            ReceiptDateTextBox = new TextBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // DepartmentComboBox
            // 
            DepartmentComboBox.FormattingEnabled = true;
            DepartmentComboBox.Location = new Point(350, 123);
            DepartmentComboBox.Name = "DepartmentComboBox";
            DepartmentComboBox.Size = new Size(200, 23);
            DepartmentComboBox.TabIndex = 0;
            // 
            // HistoryNumberTextBox1
            // 
            HistoryNumberTextBox1.Location = new Point(350, 210);
            HistoryNumberTextBox1.Name = "HistoryNumberTextBox1";
            HistoryNumberTextBox1.Size = new Size(200, 23);
            HistoryNumberTextBox1.TabIndex = 3;
            // 
            // MKBComboBox
            // 
            MKBComboBox.FormattingEnabled = true;
            MKBComboBox.Location = new Point(350, 239);
            MKBComboBox.Name = "MKBComboBox";
            MKBComboBox.Size = new Size(200, 23);
            MKBComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(238, 126);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 5;
            label1.Text = "Отделение";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(238, 158);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 6;
            label2.Text = "Дата поступления";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(238, 187);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 7;
            label3.Text = "Дата выписки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(238, 213);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 8;
            label4.Text = "Номер истории";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(238, 242);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "Код МКБ";
            // 
            // AddRecordButton
            // 
            AddRecordButton.Location = new Point(475, 268);
            AddRecordButton.Name = "AddRecordButton";
            AddRecordButton.Size = new Size(75, 23);
            AddRecordButton.TabIndex = 10;
            AddRecordButton.Text = "Добавить";
            AddRecordButton.UseVisualStyleBackColor = true;
            // 
            // DischargeDateTextBox
            // 
            DischargeDateTextBox.Location = new Point(350, 181);
            DischargeDateTextBox.Name = "DischargeDateTextBox";
            DischargeDateTextBox.Size = new Size(200, 23);
            DischargeDateTextBox.TabIndex = 3;
            // 
            // ReceiptDateTextBox
            // 
            ReceiptDateTextBox.Location = new Point(350, 152);
            ReceiptDateTextBox.Name = "ReceiptDateTextBox";
            ReceiptDateTextBox.Size = new Size(200, 23);
            ReceiptDateTextBox.TabIndex = 3;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(255, 128, 0);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(800, 80);
            panelTitleBar.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(341, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(137, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Новая карта";
            // 
            // FormAddRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelTitleBar);
            Controls.Add(AddRecordButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MKBComboBox);
            Controls.Add(ReceiptDateTextBox);
            Controls.Add(DischargeDateTextBox);
            Controls.Add(HistoryNumberTextBox1);
            Controls.Add(DepartmentComboBox);
            Name = "FormAddRecord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление карты";
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox DepartmentComboBox;
        private TextBox HistoryNumberTextBox1;
        private ComboBox MKBComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button AddRecordButton;
        private TextBox DischargeDateTextBox;
        private TextBox ReceiptDateTextBox;
        private Panel panelTitleBar;
        private Label lblTitle;
    }
}