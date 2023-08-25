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
            DatabaseTextField = new TextBox();
            ServerLabel = new Label();
            DatabaseLabel = new Label();
            UserIdLabel = new Label();
            PasswordLabel = new Label();
            ServerTextField = new TextBox();
            UserIdTextField = new TextBox();
            PasswordTextField = new TextBox();
            ConnectButton = new Button();
            TextLabel = new Label();
            SuspendLayout();
            // 
            // DatabaseTextField
            // 
            DatabaseTextField.Location = new Point(377, 271);
            DatabaseTextField.Margin = new Padding(3, 4, 3, 4);
            DatabaseTextField.Name = "DatabaseTextField";
            DatabaseTextField.Size = new Size(449, 27);
            DatabaseTextField.TabIndex = 2;
            // 
            // ServerLabel
            // 
            ServerLabel.AutoSize = true;
            ServerLabel.ForeColor = Color.Black;
            ServerLabel.Location = new Point(295, 241);
            ServerLabel.Name = "ServerLabel";
            ServerLabel.Size = new Size(50, 20);
            ServerLabel.TabIndex = 12;
            ServerLabel.Text = "Server";
            // 
            // DatabaseLabel
            // 
            DatabaseLabel.AutoSize = true;
            DatabaseLabel.ForeColor = Color.Black;
            DatabaseLabel.Location = new Point(295, 274);
            DatabaseLabel.Name = "DatabaseLabel";
            DatabaseLabel.Size = new Size(72, 20);
            DatabaseLabel.TabIndex = 12;
            DatabaseLabel.Text = "Database";
            // 
            // UserIdLabel
            // 
            UserIdLabel.AutoSize = true;
            UserIdLabel.ForeColor = Color.Black;
            UserIdLabel.Location = new Point(295, 309);
            UserIdLabel.Name = "UserIdLabel";
            UserIdLabel.Size = new Size(55, 20);
            UserIdLabel.TabIndex = 12;
            UserIdLabel.Text = "User Id";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.ForeColor = Color.Black;
            PasswordLabel.Location = new Point(295, 344);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(70, 20);
            PasswordLabel.TabIndex = 12;
            PasswordLabel.Text = "Password";
            // 
            // ServerTextField
            // 
            ServerTextField.Location = new Point(377, 238);
            ServerTextField.Margin = new Padding(3, 4, 3, 4);
            ServerTextField.Name = "ServerTextField";
            ServerTextField.Size = new Size(449, 27);
            ServerTextField.TabIndex = 1;
            // 
            // UserIdTextField
            // 
            UserIdTextField.Location = new Point(377, 306);
            UserIdTextField.Margin = new Padding(3, 4, 3, 4);
            UserIdTextField.Name = "UserIdTextField";
            UserIdTextField.Size = new Size(449, 27);
            UserIdTextField.TabIndex = 3;
            // 
            // PasswordTextField
            // 
            PasswordTextField.Location = new Point(377, 341);
            PasswordTextField.Margin = new Padding(3, 4, 3, 4);
            PasswordTextField.Name = "PasswordTextField";
            PasswordTextField.Size = new Size(449, 27);
            PasswordTextField.TabIndex = 4;
            // 
            // ConnectButton
            // 
            ConnectButton.Enabled = false;
            ConnectButton.ForeColor = SystemColors.ActiveCaptionText;
            ConnectButton.Location = new Point(703, 389);
            ConnectButton.Margin = new Padding(3, 4, 3, 4);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(123, 31);
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
            TextLabel.Location = new Point(569, 9);
            TextLabel.Name = "TextLabel";
            TextLabel.Size = new Size(522, 20);
            TextLabel.TabIndex = 12;
            TextLabel.Text = "В случае доверенного подключения оставьте  User Id и Password пустыми.";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 699);
            Controls.Add(ConnectButton);
            Controls.Add(PasswordLabel);
            Controls.Add(UserIdLabel);
            Controls.Add(DatabaseLabel);
            Controls.Add(TextLabel);
            Controls.Add(ServerLabel);
            Controls.Add(ServerTextField);
            Controls.Add(PasswordTextField);
            Controls.Add(UserIdTextField);
            Controls.Add(DatabaseTextField);
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
        private TextBox ServerTextField;
        private TextBox UserIdTextField;
        private TextBox PasswordTextField;
        private Button ConnectButton;
        private Label TextLabel;
    }
}