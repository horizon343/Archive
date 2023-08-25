using Archive.Data;
using Archive.DB;
using Archive.Forms;

namespace Archive
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();

            DisableButton();
            InitEvents();

            // Loader
            FormLoader loader = new FormLoader();
            Thread loadingThread = new Thread(() =>
            {
                loader.ShowDialog();
            });
            loadingThread.Start();

            Task.Run(async () =>
            {
                DataBase dataBase = new DataBase();
                if (DataBase.errorWhenConnection)
                {
                    loader.Close();
                    MessageBox.Show("Ошибка подключения к базе данных. Проверьте настройки подключения.");
                    return;
                }

                if (!CyrillicToLatin.GetCyrillicToLatin())
                    MessageBox.Show($"Ошибка получения данных для мапинга.");
                if (!await MKB.GetMKB(dataBase))
                    MessageBox.Show($"Ошибка при получении МКБ");
                if (!await Departments.GetDepartment(dataBase))
                    MessageBox.Show($"Ошибка при получении отделений");
                if (!await StorageLocation.GetStorageLocation(dataBase))
                    MessageBox.Show($"Ошибка при получении мест хранения");
                if (!StorageLocation.SetCurrentStorageLocation())
                    MessageBox.Show($"Ошибка при установке текущего местоположения");

                SetItemStorageLocationSelect(StorageLocationSelect);
                InitStorageLocationSelect(StorageLocationSelect);

                if (StorageLocation.currentStorageLocation == null)
                {
                    this.Close();
                    return;
                }

                loader.Close();
            });

            // === Delete ===
            DBase dBase = new DBase();
            dBase.CreateTables();
            dBase.CloseDatabaseConnection();
            // === Delete ===
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Orange;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }

        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            // Блокировка меню, если идет импорт или экспорт на форме FormImportData
            if (!Data.Data.IsActiveMenu)
                return;

            activeForm?.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        #region Click
        private void RecordsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRecords(), sender);
        }
        private void PatientsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPatients(), sender);
        }
        private void MKBButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormMKB(), sender);
        }
        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormImportData(), sender);
        }
        private void DepartmentsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDepartments(), sender);
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender);
        }
        #endregion

        #region Init
        private void InitEvents()
        {
            StorageLocationSelect.SelectedIndexChanged += StorageLocationSelect_SelectedIndexChanged;
        }
        private void SetItemStorageLocationSelect(ComboBox StorageLocationComboBox)
        {
            if (StorageLocation.isDataReceived)
            {
                List<string> storageLocationTitles = new List<string>();
                foreach (StorageLocationItem storageLocation in StorageLocation.StorageLocationList)
                    storageLocationTitles.Add(storageLocation.Title);
                StorageLocationComboBox.Items.AddRange(storageLocationTitles.ToArray());
            }
        }
        private void InitStorageLocationSelect(ComboBox StorageLocationComboBox)
        {
            if (StorageLocation.currentStorageLocation != null)
            {
                StorageLocationItem? currentStorageLocation = StorageLocation.StorageLocationList.Find(sl => sl.StorageLocationID == StorageLocation.currentStorageLocation);
                if (currentStorageLocation != null)
                {
                    string? selectedItemStorageLocation = StorageLocationSelect.Items.Cast<string>()
                         .FirstOrDefault(item => item.ToLower().Equals(currentStorageLocation.Title.ToLower()));
                    if (selectedItemStorageLocation != null)
                        StorageLocationComboBox.SelectedItem = selectedItemStorageLocation;
                }
            }
        }
        #endregion

        #region Changed
        private void StorageLocationSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            foreach (StorageLocationItem sl in StorageLocation.StorageLocationList)
            {
                if (sl.Title.ToLower() == StorageLocationSelect.SelectedItem?.ToString()?.ToLower())
                {
                    if (!StorageLocation.SetNewStorageLocation(sl.StorageLocationID))
                        MessageBox.Show($"Ошибка изменения текущего местоположения");
                    else
                        StorageLocation.currentStorageLocation = sl.StorageLocationID;
                }
            }
        }
        #endregion
    }
}