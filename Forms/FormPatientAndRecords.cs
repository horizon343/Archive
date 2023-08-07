using Archive.Data;
using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormPatientAndRecords : Form
    {
        private PatientItem DefaultPatientItem { get; set; }
        private List<RecordItem> Records { get; set; }

        private List<RecordViewItem> recordsDataSource;
        private List<RecordViewItem> recordsDataSourceClone;
        private int columnIndex = -1;
        private bool isVisible = true;

        private bool[] Edited = new bool[10];

        private readonly Color DefaultColor = Color.Black;
        private readonly Color ErrorColor = Color.Red;
        private readonly Color EditColor = Color.Green;

        public FormPatientAndRecords(Guid PatientID)
        {
            InitializeComponent();

            InitDefaultValues(PatientID);
            InitTextFieldsDefaultValues();
            InitRecordsTable();
            InitEvent();
            InitErrorsFormPatientAndRecords();
        }

        #region Init
        private void InitDefaultColorTextField()
        {
            LastNameTextField.ForeColor = DefaultColor;
            FirstNameTextField.ForeColor = DefaultColor;
            MiddleNameTextField.ForeColor = DefaultColor;
            DateOfBirthTextField.ForeColor = DefaultColor;
            RegionTextField.ForeColor = DefaultColor;
            DistrictTextField.ForeColor = DefaultColor;
            CityTextField.ForeColor = DefaultColor;
            AddressTextField.ForeColor = DefaultColor;
            PhoneTextField.ForeColor = DefaultColor;
            IndexTextField.ForeColor = DefaultColor;
        }
        private void InitDefaultValues(Guid PatientID)
        {
            DataBase dataBase = new DataBase();

            Dictionary<string, object> fieldAndValuePatientID = new Dictionary<string, object>()
            {
                { "PatientID", PatientID }
            };

            // DefaultPatientItem Init
            Task.Run(async () =>
            {
                (List<PatientItem>, int) patients = await dataBase.GetPagedEntries<PatientItem>(1, 100, "PatientID", "*", fieldAndValuePatientID);

                if (patients.Item1.Count < 1)
                {
                    this.Close();
                    return;
                }

                DefaultPatientItem = patients.Item1[0];
            }).Wait();

            // Records Init
            Task.Run(async () =>
            {
                (List<RecordItem>, int) records = await dataBase.GetPagedEntries<RecordItem>(1, 100, "PatientID", "*", fieldAndValuePatientID);
                Records = records.Item1;
            }).Wait();
        }
        private void InitRecordsTable()
        {
            recordsDataSource = Records
                 .Join(Departments.DepartmentList, record => record.DepartmentID, department => department.DepartmentID, (record, department) => new { Record = record, DepartmentTitle = department.Title })
                 .Join(MKB.MKBList, record => record.Record.MKBCode, mkb => mkb.MKBCode, (record, mkb) => new RecordViewItem
                 {
                     DepartmentTitle = record.DepartmentTitle,
                     DateOfReceipt = record.Record.DateOfReceipt,
                     DateOfDischarge = record.Record.DateOfDischarge,
                     HistoryNumber = record.Record.HistoryNumber,
                     MKBCodeTitle = mkb.MKBCode
                 })
                 .ToList();
            RecordsTable.DataSource = recordsDataSource;

            foreach (DataGridViewColumn column in RecordsTable.Columns)
                column.ReadOnly = true;

            // Задаем названия полям
            RecordsTable.Columns[0].HeaderText = "Отделение";
            RecordsTable.Columns[1].HeaderText = "Дата поступления";
            RecordsTable.Columns[2].HeaderText = "Дата выписки";
            RecordsTable.Columns[3].HeaderText = "Номер истории";
            RecordsTable.Columns[4].HeaderText = "МКБ";

            //Устанавливаем стили для таблицы
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            RecordsTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RecordsTable.Columns[1].Width = 100;
            RecordsTable.Columns[2].Width = 100;
            RecordsTable.Columns[3].Width = 100;
            RecordsTable.Columns[4].Width = 100;
            RecordsTable.DefaultCellStyle = cellStyle;
        }
        private void InitTextFieldsDefaultValues()
        {
            PatientNumberLabel.Text = DefaultPatientItem.PatientNumber;
            LastNameTextField.Text = DefaultPatientItem.LastName;
            FirstNameTextField.Text = DefaultPatientItem.FirstName;
            MiddleNameTextField.Text = DefaultPatientItem.MiddleName;
            DateOfBirthTextField.Text = DefaultPatientItem.DateOfBirth.ToShortDateString();
            RegionTextField.Text = DefaultPatientItem.Region;
            DistrictTextField.Text = DefaultPatientItem.District;
            CityTextField.Text = DefaultPatientItem.City;
            AddressTextField.Text = DefaultPatientItem.Address;
            PhoneTextField.Text = DefaultPatientItem.Phone;
            IndexTextField.Text = DefaultPatientItem.IndexAddress.ToString();
        }
        private void InitEvent()
        {
            LastNameTextField.TextChanged += LastNameTextField_Changed;
            FirstNameTextField.TextChanged += FirstNameTextField_Changed;
            MiddleNameTextField.TextChanged += MiddleNameTextField_Changed;
            DateOfBirthTextField.TextChanged += DateOfBirthTextField_Changed;
            RegionTextField.TextChanged += RegionTextField_Changed;
            DistrictTextField.TextChanged += DistrictTextField_Changed;
            CityTextField.TextChanged += CityTextField_Changed;
            AddressTextField.TextChanged += AddressTextField_Changed;
            PhoneTextField.TextChanged += PhoneTextField_Changed;
            IndexTextField.TextChanged += IndexTextField_Changed;
            RecordsTable.CellClick += RecordsTable_CellClick;
        }
        private void InitErrorsFormPatientAndRecords()
        {
            ErrorsFormPatientAndRecords.LastName = false;
            ErrorsFormPatientAndRecords.FirstName = false;
            ErrorsFormPatientAndRecords.DateOfBirth = false;
        }
        #endregion

        #region TextChanged
        private void LastNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            ValidationForm.StringOfLetter(LastNameTextField);
            Edited[0] = false;
            ErrorsFormPatientAndRecords.LastName = false;
            if (LastNameTextField.Text.Length > 0 && LastNameTextField.Text != DefaultPatientItem.LastName)
            {
                LastNameTextField.ForeColor = EditColor;
                Edited[0] = true;
            }
            else if (LastNameTextField.Text.Length > 0 && LastNameTextField.Text == DefaultPatientItem.LastName)
                LastNameTextField.ForeColor = DefaultColor;
            else
                ErrorsFormPatientAndRecords.LastName = true;

            MakeSaveButtonActive();
        }
        private void FirstNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            ValidationForm.StringOfLetter(FirstNameTextField);
            Edited[1] = false;
            ErrorsFormPatientAndRecords.FirstName = false;
            if (FirstNameTextField.Text.Length > 0 && FirstNameTextField.Text != DefaultPatientItem.FirstName)
            {
                FirstNameTextField.ForeColor = EditColor;
                Edited[1] = true;
            }
            else if (FirstNameTextField.Text.Length > 0 && FirstNameTextField.Text == DefaultPatientItem.FirstName)
                FirstNameTextField.ForeColor = DefaultColor;
            else
                ErrorsFormPatientAndRecords.FirstName = true;

            MakeSaveButtonActive();
        }
        private void MiddleNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            ValidationForm.StringOfLetter(MiddleNameTextField);
            Edited[2] = false;
            if (MiddleNameTextField.Text != DefaultPatientItem.MiddleName)
            {
                MiddleNameTextField.ForeColor = EditColor;
                Edited[2] = true;
            }
            else
                MiddleNameTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        private void DateOfBirthTextField_Changed(object? sender, EventArgs e)
        {
            DateOfBirthTextField.MaxLength = 10;

            ValidationForm.DateFormatting(DateOfBirthTextField);
            Edited[3] = false;
            ErrorsFormPatientAndRecords.DateOfBirth = false;
            if (DateOfBirthTextField.Text.Length == 10)
            {
                bool isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text);
                if (isNotError && !DateOfBirthTextField.Text.Equals(DefaultPatientItem.DateOfBirth.ToShortDateString()))
                {
                    Edited[3] = true;
                    DateOfBirthTextField.ForeColor = EditColor;
                }
                else if (isNotError)
                    DateOfBirthTextField.ForeColor = DefaultColor;
                else
                {
                    DateOfBirthTextField.ForeColor = ErrorColor;
                    ErrorsFormPatientAndRecords.DateOfBirth = true;
                }
            }
            else
            {
                DateOfBirthTextField.ForeColor = DefaultColor;
                ErrorsFormPatientAndRecords.DateOfBirth = true;
            }

            MakeSaveButtonActive();
        }
        private void RegionTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(RegionTextField);
            ValidationForm.StringOfLetter(RegionTextField, true);
            Edited[4] = false;
            if (RegionTextField.Text != DefaultPatientItem.Region)
            {
                RegionTextField.ForeColor = EditColor;
                Edited[4] = true;
            }
            else
                RegionTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        private void DistrictTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(DistrictTextField);
            ValidationForm.StringOfLetter(DistrictTextField, true);
            Edited[5] = false;
            if (DistrictTextField.Text != DefaultPatientItem.District)
            {
                DistrictTextField.ForeColor = EditColor;
                Edited[5] = true;
            }
            else
                DistrictTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        private void CityTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(CityTextField);
            ValidationForm.StringOfLetter(CityTextField, true);
            Edited[6] = false;
            if (CityTextField.Text != DefaultPatientItem.City)
            {
                CityTextField.ForeColor = EditColor;
                Edited[6] = true;
            }
            else
                CityTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        private void AddressTextField_Changed(object? sender, EventArgs e)
        {
            Edited[7] = false;
            if (AddressTextField.Text != DefaultPatientItem.Address)
            {
                AddressTextField.ForeColor = EditColor;
                Edited[7] = true;
            }
            else
                AddressTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        private void PhoneTextField_Changed(object? sender, EventArgs e)
        {
            PhoneTextField.MaxLength = 11;

            ValidationForm.StringOfNumber(PhoneTextField);
            Edited[8] = false;
            if (PhoneTextField.Text != DefaultPatientItem.Phone)
            {
                PhoneTextField.ForeColor = EditColor;
                Edited[8] = true;
            }
            else
                PhoneTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();

        }
        private void IndexTextField_Changed(object? sender, EventArgs e)
        {
            IndexTextField.MaxLength = 6;

            ValidationForm.StringOfNumber(IndexTextField);
            Edited[9] = false;
            if (IndexTextField.Text != DefaultPatientItem.IndexAddress)
            {
                IndexTextField.ForeColor = EditColor;
                Edited[9] = true;
            }
            else
                IndexTextField.ForeColor = DefaultColor;

            MakeSaveButtonActive();
        }
        #endregion

        #region ButtonClick
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Сохранение в базе данных
                PatientItem patient = new PatientItem()
                {
                    PatientID = DefaultPatientItem.PatientID,
                    PatientNumber = DefaultPatientItem.PatientNumber,
                    LastName = LastNameTextField.Text,
                    FirstName = FirstNameTextField.Text,
                    MiddleName = MiddleNameTextField.Text,
                    DateOfBirth = DateTime.Parse(DateOfBirthTextField.Text),
                    Region = RegionTextField.Text,
                    District = DistrictTextField.Text,
                    City = CityTextField.Text,
                    Address = AddressTextField.Text,
                    Phone = PhoneTextField.Text,
                    IndexAddress = IndexTextField.Text,
                };

                int countUpdateEntries = 0;
                DataBase dataBase = new DataBase();
                Task.Run(async () =>
                {
                    countUpdateEntries = await dataBase.EntryUpdate<PatientItem>(patient, "PatientID");
                }).Wait();

                if (countUpdateEntries == 0)
                    MessageBox.Show("Ошибка. Ни одна запись не была изменена");
                else
                {
                    InitDefaultValues(DefaultPatientItem.PatientID);
                    InitTextFieldsDefaultValues();
                    Edited = new bool[10];
                    InitDefaultColorTextField();
                    MakeSaveButtonActive();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка: [{ex.Message}]");
            }
        }
        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            var FormAddRecord = new FormAddRecord(DefaultPatientItem.PatientID);
            FormAddRecord.Show();
            this.Close();
        }
        private void ShowOrHideButton_Click(object sender, EventArgs e)
        {
            if (isVisible)
            {
                recordsDataSourceClone = recordsDataSource;
                List<RecordViewItem> recordsViewItems = recordsDataSource
                    .GroupBy(record => record.DepartmentTitle)
                    .Select(group => group.OrderByDescending(record => record.DateOfDischarge).First())
                    .ToList();
                recordsDataSource = recordsViewItems;
                RecordsTable.DataSource = recordsDataSource;
                ShowOrHideButton.Text = "Показать одинаковые отделения";
            }
            else
            {
                recordsDataSource = recordsDataSourceClone;
                RecordsTable.DataSource = recordsDataSource;
                ShowOrHideButton.Text = "Скрыть одинаковые отделения";
            }

            isVisible = !isVisible;
        }
        #endregion

        // Меняет свойство Enable у SaveButton 
        private void MakeSaveButtonActive()
        {
            SaveButton.Enabled = false;
            if (ErrorsFormPatientAndRecords.LastName || ErrorsFormPatientAndRecords.FirstName || ErrorsFormPatientAndRecords.DateOfBirth)
                return;

            foreach (bool edited in Edited)
                if (edited)
                {
                    SaveButton.Enabled = true;
                    break;
                }
        }

        private void RecordsTable_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) return;

            Func<RecordViewItem, object> sortingFunc;

            switch (e.ColumnIndex)
            {
                case 1:
                    sortingFunc = record => record.DateOfReceipt;
                    break;
                case 2:
                    sortingFunc = record => record.DateOfDischarge;
                    break;
                case 3:
                    sortingFunc = record => record.HistoryNumber;
                    break;
                case 4:
                    sortingFunc = record => record.MKBCodeTitle;
                    break;
                default:
                    sortingFunc = record => record.DepartmentTitle;
                    break;
            }

            if (columnIndex != e.ColumnIndex)
            {
                recordsDataSource = recordsDataSource.OrderBy(sortingFunc).ToList();
                columnIndex = e.ColumnIndex;
            }
            else
            {
                List<RecordViewItem> recordsDataSourceNew = recordsDataSource.ToList();
                recordsDataSourceNew.Reverse();
                recordsDataSource = recordsDataSourceNew;
            }

            RecordsTable.DataSource = recordsDataSource;
        }
    }

    class RecordViewItem
    {
        public string DepartmentTitle { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public int HistoryNumber { get; set; }
        public string MKBCodeTitle { get; set; }
    }

    static class ErrorsFormPatientAndRecords
    {
        static public bool LastName { get; set; }
        static public bool FirstName { get; set; }
        static public bool DateOfBirth { get; set; }
    }
}
