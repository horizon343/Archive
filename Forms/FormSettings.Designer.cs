namespace Archive.Forms
{
    partial class FormSettings
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
            ServerLabel = new Label();
            ConnectionStringTextField = new TextBox();
            ConnectButton = new Button();
            TextLabel = new Label();
            SuspendLayout();
            // 
            // ServerLabel
            // 
            ServerLabel.AutoSize = true;
            ServerLabel.ForeColor = Color.Black;
            ServerLabel.Location = new Point(168, 229);
            ServerLabel.Name = "ServerLabel";
            ServerLabel.Size = new Size(102, 15);
            ServerLabel.TabIndex = 12;
            ServerLabel.Text = "Connection string";
            // 
            // ConnectionStringTextField
            // 
            ConnectionStringTextField.Location = new Point(276, 226);
            ConnectionStringTextField.Name = "ConnectionStringTextField";
            ConnectionStringTextField.Size = new Size(538, 23);
            ConnectionStringTextField.TabIndex = 1;
            // 
            // ConnectButton
            // 
            ConnectButton.Enabled = false;
            ConnectButton.ForeColor = SystemColors.ActiveCaptionText;
            ConnectButton.Location = new Point(706, 255);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(108, 23);
            ConnectButton.TabIndex = 5;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // TextLabel
            // 
            TextLabel.AutoSize = true;
            TextLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            TextLabel.ForeColor = Color.Black;
            TextLabel.Location = new Point(520, 9);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(421, 15);
            TextLabel.TabIndex = 12;
            TextLabel.Text = "Строка подключения храниться в файле по пути: JSON/connectionDB.json";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 524);
            Controls.Add(ConnectButton);
            Controls.Add(TextLabel);
            Controls.Add(ServerLabel);
            Controls.Add(ConnectionStringTextField);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSettings";
            Text = "Настройки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DatabaseTextField;
        private Label ServerLabel;
        private Label DatabaseLabel;
        private Label UserIdLabel;
        private Label PasswordLabel;
        private TextBox ConnectionStringTextField;
        private TextBox UserIdTextField;
        private TextBox PasswordTextField;
        private Button ConnectButton;
        private Label TextLabel;
    }
}