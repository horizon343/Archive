using Archive.Data;
using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormAddRecord : Form
    {
        private RecordItem? DefaultRecordItem { get; set; }
        private string? defaultDepartment = null;
        private string? defaultStorageLocation = null;
        private Guid? RecordID { get; }
        private Guid PatientID { get; }

        private bool[] Edited = new bool[6];

        private readonly Color DefaultColor = Color.Black;
        private readonly Color ErrorColor = Color.Red;
        private readonly Color EditColor = Color.Green;

        public FormAddRecord(Guid patientID, Guid? recordID = null)
        {
            InitializeComponent();

            PatientID = patientID;
            RecordID = recordID;
            if (recordID != null)
                AddRecord.Text = "Сохранить";

            InitEvent();
            InitMKBItemField();
            InitDepartmentItemField();
            InitStorageLocationItemField();
            InitErrorsAddRecords();

            InitDefaultColorTextField();
            InitDefaultValues();
            InitTextFieldsDefaultValues();
        }

        #region Init
        private void InitDefaultColorTextField()
        {
            DateOfReceiptTextField.ForeColor = DefaultColor;
            DateOfDischargeTextField.ForeColor = DefaultColor;
            HistoryNumberTextField.ForeColor = DefaultColor;
            DepartmentTextField.ForeColor = DefaultColor;
            MKBCodeTextField.ForeColor = DefaultColor;
            StorageLocationTextField.ForeColor = DefaultColor;
        }
        private void InitDefaultValues()
        {
            if (RecordID == null) return;

            DataBase dataBase = new DataBase();

            Dictionary<string, object> fieldAndValueRecordID = new Dictionary<string, object>()
            {
                { "RecordID", RecordID }
            };

            // DefaultRecordItem Init
            Task.Run(async () =>
            {
                (List<RecordItem>, int) records = await dataBase.GetPagedEntries<RecordItem>(1, 100, "RecordID", "*", fieldAndValueRecordID);

                if (records.Item1.Count < 1)
                {
                    this.Close();
                    return;
                }

                DefaultRecordItem = records.Item1[0];
            }).Wait();

        }
        private void InitTextFieldsDefaultValues()
        {
            DateOfReceiptTextField.MaxLength = 10;
            DateOfDischargeTextField.MaxLength = 10;

            if (RecordID == null || DefaultRecordItem == null) return;

            string? departmentTitle = Departments.DepartmentList.Find(department => department.DepartmentID.Equals(DefaultRecordItem.DepartmentID))?.Title;
            if (departmentTitle != null)
            {
                var selectedItemDepartment = DepartmentSelect.Items.Cast<string>()
                    .FirstOrDefault(item => item.ToLower().Equals(departmentTitle.ToLower()));
                if (selectedItemDepartment != null)
                {
                    DepartmentSelect.SelectedItem = selectedItemDepartment;
                    defaultDepartment = selectedItemDepartment;
                }
            }
            var selectedItemMKB = MKBCodeSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(DefaultRecordItem.MKBCode.ToLower()));
            if (selectedItemMKB != null)
                MKBCodeSelect.SelectedItem = selectedItemMKB;
            string? storageLocationTitle = StorageLocation.StorageLocationList.Find(storageLocation => storageLocation.StorageLocationID.Equals(DefaultRecordItem.StorageLocationID))?.Title;
            if (storageLocationTitle != null)
            {
                var selectedItemStorageLocation = StorageLocationSelect.Items.Cast<string>()
                    .FirstOrDefault(item => item.ToLower().Equals(storageLocationTitle.ToLower()));

                if (selectedItemStorageLocation != null)
                {
                    StorageLocationSelect.SelectedItem = selectedItemStorageLocation;
                    defaultStorageLocation = selectedItemStorageLocation;
                }
                DateOfReceiptTextField.Text = DefaultRecordItem.DateOfReceipt.ToShortDateString();
                DateOfDischargeTextField.Text = DefaultRecordItem.DateOfDischarge.ToShortDateString();
                HistoryNumberTextField.Text = DefaultRecordItem.HistoryNumber.ToString();
            }
        }
        private void InitEvent()
        {
            DateOfReceiptTextField.TextChanged += DateOfReceiptTextField_Changed;
            DateOfDischargeTextField.TextChanged += DateOfDischargeTextField_Changed;
            HistoryNumberTextField.TextChanged += HistoryNumberTextField_Changed;
            DepartmentSelect.SelectedIndexChanged += DepartmentSelect_SelectedIndexChanged;
            DepartmentTextField.TextChanged += DepartmentTextField_Changed;
            MKBCodeSelect.SelectedIndexChanged += MKBCodeSelect_SelectedIndexChanged;
            MKBCodeTextField.TextChanged += MKBCodeTextField_Changed;
            StorageLocationTextField.TextChanged += StorageLocationTextField_Changed;
            StorageLocationSelect.SelectedIndexChanged += StorageLocationSelect_SelectedIndexChanged;
        }
        private void InitMKBItemField()
        {
            List<string> MKBCode = new List<string>();
            foreach (MKBItem mkbItem in MKB.MKBList)
                MKBCode.Add(mkbItem.MKBCode);

            AutoCompleteStringCollection MKBSource = new AutoCompleteStringCollection();
            MKBSource.AddRange(MKBCode.ToArray());

            MKBCodeTextField.AutoCompleteCustomSource = MKBSource;
            MKBCodeTextField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MKBCodeTextField.AutoCompleteSource = AutoCompleteSource.CustomSource;

            MKBCodeSelect.Items.AddRange(MKBCode.ToArray());
        }
        private void InitDepartmentItemField()
        {
            List<string> departmentsTitle = new List<string>();
            foreach (DepartmentItem departmentItem in Departments.DepartmentList)
                departmentsTitle.Add(departmentItem.Title);

            AutoCompleteStringCollection departmentsSource = new AutoCompleteStringCollection();
            departmentsSource.AddRange(departmentsTitle.ToArray());

            DepartmentTextField.AutoCompleteCustomSource = departmentsSource;
            DepartmentTextField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DepartmentTextField.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DepartmentSelect.Items.AddRange(departmentsTitle.ToArray());
        }
        private void InitStorageLocationItemField()
        {
            List<string> storageLocationTitle = new List<string>();
            foreach (StorageLocationItem storageLocationItem in StorageLocation.StorageLocationList)
                storageLocationTitle.Add(storageLocationItem.Title);

            AutoCompleteStringCollection storageLocationsSource = new AutoCompleteStringCollection();
            storageLocationsSource.AddRange(storageLocationTitle.ToArray());

            StorageLocationTextField.AutoCompleteCustomSource = storageLocationsSource;
            StorageLocationTextField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StorageLocationTextField.AutoCompleteSource = AutoCompleteSource.CustomSource;

            StorageLocationSelect.Items.AddRange(storageLocationTitle.ToArray());
        }
        private void InitErrorsAddRecords()
        {
            ErrorsAddRecords.Department = false;
            ErrorsAddRecords.DateOfReceipt = true;
            ErrorsAddRecords.DateOfDischarge = true;
            ErrorsAddRecords.HistoryNumber = false;
            ErrorsAddRecords.MKB = false;
        }
        #endregion

        #region TextChanged
        private void DepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            DepartmentTextField.Text = DepartmentSelect.SelectedItem.ToString();

            MakeAddButtonActive();
        }
        private void DepartmentTextField_Changed(object? sender, EventArgs e)
        {
            Edited[0] = false;
            DepartmentTextField.ForeColor = DefaultColor;

            string departmentTextFieldText = DepartmentTextField.Text;
            var selectedItem = DepartmentSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(departmentTextFieldText.ToLower()));

            if (selectedItem != null)
            {
                DepartmentSelect.SelectedItem = selectedItem;

                if (DefaultRecordItem != null && defaultDepartment != null && !DepartmentTextField.Text.ToLower().Equals(defaultDepartment.ToLower()))
                {
                    DepartmentTextField.ForeColor = EditColor;
                    Edited[0] = true;
                }
            }

            MakeAddButtonActive();
        }
        private void DateOfReceiptTextField_Changed(object? sender, EventArgs e)
        {
            DateOfReceiptErrorText.Text = "";
            DateOfReceiptTextField.ForeColor = DefaultColor;
            Edited[1] = false;

            ValidationForm.DateFormatting(DateOfReceiptTextField);
            ErrorsAddRecords.DateOfReceipt = false;
            if (DateOfReceiptTextField.Text.Length == 10)
            {
                bool isNotError = ValidationForm.DateIsValid(DateOfReceiptTextField.Text);
                if (!isNotError)
                {
                    DateOfReceiptTextField.ForeColor = ErrorColor;
                    ErrorsAddRecords.DateOfReceipt = true;
                    DateOfReceiptErrorText.Text = "Некорректная дата";
                }
                else if (DefaultRecordItem != null && !DateOfReceiptTextField.Text.Equals(DefaultRecordItem.DateOfReceipt.ToShortDateString()))
                {
                    DateOfReceiptTextField.ForeColor = EditColor;
                    Edited[1] = true;
                }
            }
            else
                ErrorsAddRecords.DateOfReceipt = true;

            MakeAddButtonActive();
        }
        private void DateOfDischargeTextField_Changed(object? sender, EventArgs e)
        {
            DateOfDischargeErrorText.Text = "";
            DateOfDischargeTextField.ForeColor = DefaultColor;
            Edited[2] = false;

            ValidationForm.DateFormatting(DateOfDischargeTextField);
            ErrorsAddRecords.DateOfDischarge = false;
            if (DateOfDischargeTextField.Text.Length == 10)
            {
                bool isNotError = ValidationForm.DateIsValid(DateOfDischargeTextField.Text);
                if (isNotError && !ErrorsAddRecords.DateOfReceipt)
                {
                    string[] DateOfReceiptArray = DateOfReceiptTextField.Text.Split(".");
                    string[] DateOfDischargeArray = DateOfDischargeTextField.Text.Split(".");
                    DateTime DateOfReceipt = new DateTime(int.Parse(DateOfReceiptArray[2]), int.Parse(DateOfReceiptArray[1]), int.Parse(DateOfReceiptArray[0]));
                    DateTime DateOfDischarge = new DateTime(int.Parse(DateOfDischargeArray[2]), int.Parse(DateOfDischargeArray[1]), int.Parse(DateOfDischargeArray[0]));

                    if (DateOfReceipt > DateOfDischarge)
                    {
                        DateOfDischargeTextField.ForeColor = ErrorColor;
                        ErrorsAddRecords.DateOfDischarge = true;
                        DateOfDischargeErrorText.Text = "Дата поступления не может быть больше даты выписки";
                    }
                    else if (DefaultRecordItem != null && !DateOfDischargeTextField.Text.Equals(DefaultRecordItem.DateOfDischarge.ToShortDateString()))
                    {
                        DateOfDischargeTextField.ForeColor = EditColor;
                        Edited[2] = true;
                    }
                }
                else
                {
                    DateOfDischargeTextField.ForeColor = ErrorColor;
                    ErrorsAddRecords.DateOfDischarge = true;
                    DateOfDischargeErrorText.Text = "Некорректная дата";
                }
            }
            else
                ErrorsAddRecords.DateOfDischarge = true;

            MakeAddButtonActive();
        }
        private void HistoryNumberTextField_Changed(object? sender, EventArgs e)
        {
            Edited[3] = false;
            HistoryNumberTextField.ForeColor = DefaultColor;

            ValidationForm.StringOfNumber(HistoryNumberTextField);
            if (DefaultRecordItem != null && !HistoryNumberTextField.Text.Equals(DefaultRecordItem.HistoryNumber.ToString()))
            {
                Edited[3] = true;
                HistoryNumberTextField.ForeColor = EditColor;
            }

            MakeAddButtonActive();
        }
        private void MKBCodeSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            MKBCodeTextField.Text = MKBCodeSelect.SelectedItem.ToString();

            MakeAddButtonActive();
        }
        private void MKBCodeTextField_Changed(object? sender, EventArgs e)
        {
            Edited[4] = false;
            MKBCodeTextField.ForeColor = DefaultColor;

            string mkbTextFieldText = MKBCodeTextField.Text;
            var selectedItem = MKBCodeSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(mkbTextFieldText.ToLower()));

            if (selectedItem != null)
            {
                MKBCodeSelect.SelectedItem = selectedItem;

                if (DefaultRecordItem != null && !MKBCodeTextField.Text.ToLower().Equals(DefaultRecordItem.MKBCode.ToLower()))
                {
                    MKBCodeTextField.ForeColor = EditColor;
                    Edited[4] = true;
                }
            }

            MakeAddButtonActive();
        }
        private void StorageLocationSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            StorageLocationTextField.Text = StorageLocationSelect.SelectedItem.ToString();

            MakeAddButtonActive();
        }
        private void StorageLocationTextField_Changed(object? sender, EventArgs e)
        {
            Edited[5] = false;
            StorageLocationTextField.ForeColor = DefaultColor;

            string storageLocationTextFieldText = StorageLocationTextField.Text;
            var selectedItem = StorageLocationSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(storageLocationTextFieldText.ToLower()));

            if (selectedItem != null)
            {
                StorageLocationSelect.SelectedItem = selectedItem;

                if (DefaultRecordItem != null && defaultStorageLocation != null && !StorageLocationTextField.Text.ToLower().Equals(defaultStorageLocation.ToLower()))
                {
                    StorageLocationTextField.ForeColor = EditColor;
                    Edited[5] = true;
                }
            }

            MakeAddButtonActive();
        }
        #endregion

        // Меняет свойство Enable у AddButton 
        private void MakeAddButtonActive()
        {
            string? departmentSelect = DepartmentSelect.SelectedItem?.ToString();
            string departmentTextField = DepartmentTextField.Text;

            string? mkbCodeSelect = MKBCodeSelect.SelectedItem?.ToString();
            string mkbTextFieldText = MKBCodeTextField.Text;

            string? storageLocationSelect = StorageLocationSelect.SelectedItem?.ToString();
            string storageLocationTextField = StorageLocationTextField.Text;

            AddRecord.Enabled = false;
            if (ErrorsAddRecords.DateOfReceipt || ErrorsAddRecords.DateOfDischarge ||
                departmentSelect == null || departmentSelect.ToLower() != departmentTextField.ToLower() ||
                mkbCodeSelect == null || mkbCodeSelect.ToLower() != mkbTextFieldText.ToLower() ||
                storageLocationSelect == null || storageLocationSelect.ToLower() != storageLocationTextField.ToLower())
                return;
            else if (RecordID == null)
            {
                AddRecord.Enabled = true;
                return;
            }

            foreach (bool edited in Edited)
                if (edited)
                {
                    AddRecord.Enabled = true;
                    break;
                }
        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            AddRecord.Enabled = false;

            if (RecordID == null)
                AddNewRecord();
            else
                SaveEditedRecord();

            AddRecord.Enabled = true;
        }

        private void SaveEditedRecord()
        {
            try
            {
                // Устанавливаем значение DepartmentID и MKBCode
                int? DepartmentID = Departments.DepartmentList.Find(department => DepartmentSelect.SelectedItem.ToString() == department.Title)?.DepartmentID;
                string? MKBCode = MKBCodeSelect.SelectedItem?.ToString();
                string? StorageLocationID = StorageLocation.StorageLocationList.Find(storageLocation => StorageLocationSelect.SelectedItem.ToString() == storageLocation.Title)?.StorageLocationID;

                if (DepartmentID == null || MKBCode == null || StorageLocationID == null)
                {
                    MessageBox.Show($"Ошибка добавления записи [DepartmentID:{DepartmentID} MKBCode:{MKBCode} StorageLocationID:{StorageLocationID}]");
                    return;
                }

                // Сохранение в базе данных
                RecordItem record = new RecordItem()
                {
                    RecordID = (Guid)RecordID,
                    DepartmentID = (int)DepartmentID,
                    PatientID = PatientID,
                    DateOfReceipt = DateTime.Parse(DateOfReceiptTextField.Text),
                    DateOfDischarge = DateTime.Parse(DateOfDischargeTextField.Text),
                    HistoryNumber = int.Parse(HistoryNumberTextField.Text),
                    MKBCode = MKBCode,
                    StorageLocationID = StorageLocationID
                };

                Task.Run(async () =>
                {
                    DataBase dataBase = new DataBase();
                    await dataBase.EntryUpdate<RecordItem>(record, "RecordID");
                }).Wait();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при обновлении записи: [{ex.Message}]");
            }
        }
        private void AddNewRecord()
        {
            try
            {
                // Устанавливаем значение DepartmentID и MKBCode
                int? DepartmentID = Departments.DepartmentList.Find(department => DepartmentSelect.SelectedItem.ToString() == department.Title)?.DepartmentID;
                string? MKBCode = MKBCodeSelect.SelectedItem?.ToString();
                string? StorageLocationID = StorageLocation.StorageLocationList.Find(storageLocation => StorageLocationSelect.SelectedItem.ToString() == storageLocation.Title)?.StorageLocationID;

                if (DepartmentID == null || MKBCode == null || StorageLocationID == null)
                {
                    MessageBox.Show($"Ошибка добавления записи [DepartmentID:{DepartmentID} MKBCode:{MKBCode} StorageLocationID:{StorageLocationID}]");
                    return;
                }

                // Сохранение в базе данных
                Guid RecordID = Guid.NewGuid();
                RecordItem record = new RecordItem()
                {
                    RecordID = RecordID,
                    DepartmentID = (int)DepartmentID,
                    PatientID = PatientID,
                    DateOfReceipt = DateTime.Parse(DateOfReceiptTextField.Text),
                    DateOfDischarge = DateTime.Parse(DateOfDischargeTextField.Text),
                    HistoryNumber = int.Parse(HistoryNumberTextField.Text),
                    MKBCode = MKBCode,
                    StorageLocationID = StorageLocationID
                };

                Task.Run(async () =>
                {
                    DataBase dataBase = new DataBase();
                    await dataBase.InsertEntry<RecordItem>(record);
                }).Wait();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при добавлении записи: [{ex.Message}]");
            }
        }
    }

    static class ErrorsAddRecords
    {
        public static bool Department { get; set; }
        public static bool DateOfReceipt { get; set; }
        public static bool DateOfDischarge { get; set; }
        public static bool HistoryNumber { get; set; }
        public static bool MKB { get; set; }
    }
}
