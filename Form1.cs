using Archive.Data;
using Archive.DB;

namespace Archive
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private int tempIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            DisableButton();

            DBase dBase = new DBase();
            dBase.CreateTables();
            dBase.CloseDatabaseConnection();

            StorageLocationSelect.SelectedIndexChanged += StorageLocationSelect_SelectedIndexChanged;

            CyrillicToLatin.GetCyrillicToLatin();
            Task.Run(async () =>
            {
                DataBase dataBase = new DataBase();
                if (DataBase.errorWhenConnection)
                {
                    MessageBox.Show("Ошибка подключения к базе данных. Проверьте настройки.");
                    return;
                }

                await MKB.GetMKB();
                await Departments.GetDepartment();
                await StorageLocation.GetStorageLocation();
                StorageLocation.SetCurrentStorageLocation();

                SetItemStorageLocationSelect();
                InitStorageLocationSelect();

                if (StorageLocation.currentStorageLocation == null)
                {
                    this.Close();
                    return;
                }
            });

        }

        private void SetItemStorageLocationSelect()
        {
            if (StorageLocation.isDataReceived)
            {
                List<string> StorageLocationTitle = new List<string>();
                foreach (StorageLocationItem storageLocation in StorageLocation.StorageLocationList)
                    StorageLocationTitle.Add(storageLocation.Title);
                StorageLocationSelect.Items.AddRange(StorageLocationTitle.ToArray());
            }
        }

        private void InitStorageLocationSelect()
        {
            if (StorageLocation.currentStorageLocation != null)
            {
                StorageLocationItem? currentStorageLocation = StorageLocation.StorageLocationList.Find(sl => sl.StorageLocationID == StorageLocation.currentStorageLocation);
                if (currentStorageLocation != null)
                {
                    var selectedItemStorageLocation = StorageLocationSelect.Items.Cast<string>()
                         .FirstOrDefault(item => item.ToLower().Equals(currentStorageLocation.Title.ToLower()));
                    if (selectedItemStorageLocation != null)
                        StorageLocationSelect.SelectedItem = selectedItemStorageLocation;
                }
            }
        }

        private void StorageLocationSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            foreach (StorageLocationItem sl in StorageLocation.StorageLocationList)
            {
                if (sl.Title.ToLower() == StorageLocationSelect.SelectedItem.ToString().ToLower())
                {
                    StorageLocation.currentStorageLocation = sl.StorageLocationID;
                    StorageLocation.SetNewStorageLocation(sl.StorageLocationID);
                }
            }
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
            if (activeForm != null)
                activeForm.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRecords(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPatients(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormMKB(), sender);
        }

        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormImportData(), sender);
        }

        private void Departments_button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDepartments(), sender);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender);
        }
    }
}