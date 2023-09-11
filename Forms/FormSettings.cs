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

                    ConnectionStringTextField.Text = jsonObject["ConnectionString"]?.ToString();
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
            ConnectionStringTextField.TextChanged += ToggleButtonStatus;
        }
        #endregion

        #region TextChanged
        private void ToggleButtonStatus(object? sender, EventArgs e)
        {
            ConnectButton.Enabled = false;

            if (ConnectionStringTextField.Text.Length != 0)
                ConnectButton.Enabled = true;
        }
        #endregion

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            bool result = RewriteConnectionDBJson(ConnectionStringTextField);
            if (result)
                RestartApp();
        }

        // Перезаписывает настройки файла connectionDB.json
        private bool RewriteConnectionDBJson(TextBox ConnectionStringTextField)
        {
            try
            {
                if (File.Exists(connectionFilePath))
                {
                    string jsonContext = File.ReadAllText(connectionFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    jsonObject["ConnectionString"] = ConnectionStringTextField.Text;

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
