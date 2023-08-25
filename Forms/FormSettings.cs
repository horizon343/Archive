using Archive.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Archive.Forms
{
    public partial class FormSettings : Form
    {
        private readonly string connectionFilePath = FilesPaths.connectionDBFilePath;

        public FormSettings()
        {
            InitializeComponent();

            InitEvents();
            SetConnectionParam();
        }

        #region Init
        private void SetConnectionParam()
        {
            try
            {
                if (File.Exists(connectionFilePath))
                {
                    string jsonContext = File.ReadAllText(connectionFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    ServerTextField.Text = jsonObject["Server"]?.ToString();
                    DatabaseTextField.Text = jsonObject["Database"]?.ToString();
                    UserIdTextField.Text = jsonObject["User_Id"]?.ToString();
                    PasswordTextField.Text = jsonObject["Password"]?.ToString();
                }
                else
                    throw new Exception("Отсутствует connectionDB.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при получении данных из connectionDB.json: {ex.Message}");
            }
        }
        private void InitEvents()
        {
            ServerTextField.TextChanged += ToggleButtonStatus;
            DatabaseTextField.TextChanged += ToggleButtonStatus;
            UserIdTextField.TextChanged += ToggleButtonStatus;
            PasswordTextField.TextChanged += ToggleButtonStatus;
        }
        #endregion

        #region TextChanged
        private void ToggleButtonStatus(object? sender, EventArgs e)
        {
            ConnectButton.Enabled = false;

            if (ServerTextField.Text.Length != 0 && DatabaseTextField.Text.Length != 0 && ((PasswordTextField.Text.Length == 0 && UserIdTextField.Text.Length == 0) || (PasswordTextField.Text.Length != 0 && UserIdTextField.Text.Length != 0)))
                ConnectButton.Enabled = true;
        }
        #endregion

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            bool result = RewriteConnectionDBJson(ServerTextField, DatabaseTextField, UserIdTextField, PasswordTextField);
            if (result)
                RestartApp();
        }

        // Перезаписывает настройки файла connectionDB.json
        private bool RewriteConnectionDBJson(TextBox ServerTextBox, TextBox DatabaseTextBox, TextBox UserIdTextBox, TextBox PasswordTextBox)
        {
            try
            {
                if (File.Exists(connectionFilePath))
                {
                    string jsonContext = File.ReadAllText(connectionFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    jsonObject["Server"] = ServerTextBox.Text;
                    jsonObject["Database"] = DatabaseTextBox.Text;

                    if (UserIdTextBox.Text.Length == 0 && PasswordTextBox.Text.Length == 0)
                    {
                        jsonObject["Trusted_Connection"] = true;
                        jsonObject["User_Id"] = null;
                        jsonObject["Password"] = null;
                    }
                    else
                    {
                        jsonObject["Trusted_Connection"] = false;
                        jsonObject["User_Id"] = UserIdTextBox.Text;
                        jsonObject["Password"] = PasswordTextBox.Text;
                    }

                    using (StreamWriter file = File.CreateText(connectionFilePath))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        jsonObject.WriteTo(writer);
                    }
                    return true;
                }
                else
                    throw new Exception("Отсутствует connectionDB.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка: {ex.Message}");
                return false;
            }
        }

        // Перезапуск приложения
        private void RestartApp()
        {
            string appPath = Application.ExecutablePath;

            Process.Start(new ProcessStartInfo
            {
                FileName = appPath,
                UseShellExecute = true,
                Verb = "runas"
            });

            Application.Exit();
        }
    }
}
