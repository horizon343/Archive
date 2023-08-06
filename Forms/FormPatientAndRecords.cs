using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormPatientAndRecords : Form
    {
        private PatientItem DefaultPatientItem { get; set; }
        private List<RecordItem> Records { get; set; }
        private List<DepartmentItem> Departments { get; set; }
        private List<MKBItem> MKB { get; set; }

        private List<RecordViewItem> recordsDataSource;
        private List<RecordViewItem> recordsDataSourceClone;
        private int columnIndex = -1;
        private bool isVisible = true;

        private bool[] Edited = new bool[10];

        private Color DefaultColor = Color.Black;
        private Color ErrorColor = Color.Red;
        private Color EditColor = Color.Green;

        public FormPatientAndRecords(Guid PatientID)
        {
            InitializeComponent();

            RecordsTable.CellClick += RecordsTable_CellClick;

            InitDefaultValues(PatientID);
            InitTextFieldsDefaultValues();
            InitTextFieldsChanged();
            InitRecordsTable();
        }

        private void InitDefaultValues(Guid PatientID)
        {
            DBase dBase = new DBase();

            // DefaultPatientItem Init
            Dictionary<string, object> fieldAndValuePatientTable = new Dictionary<string, object>()
            {
                { "PatientID", PatientID }
            };
            List<PatientItem> patients = dBase.SearchData<PatientItem>(fieldAndValuePatientTable);
            DefaultPatientItem = patients[0];

            // Departments Init
            (int, List<DepartmentItem>) departments = dBase.GetTable<DepartmentItem>(-1, 50);
            Departments = departments.Item2;

            // MKB Init
            (int, List<MKBItem>) mkb = dBase.GetTable<MKBItem>(-1, 50);
            MKB = mkb.Item2;

            // Records Init
            Dictionary<string, object> fieldAndValueRecordTable = new Dictionary<string, object>()
            {
                { "PatientID", PatientID }
            };
            List<RecordItem> records = dBase.SearchData<RecordItem>(fieldAndValueRecordTable);
            Records = records;

            dBase.CloseDatabaseConnection();
        }

        /// <summary>
        /// Создание таблицы с картами
        /// </summary>
        private void InitRecordsTable()
        {
            recordsDataSource = Records
                 .Join(Departments, record => record.DepartmentID, department => department.DepartmentID, (record, department) => new { Record = record, DepartmentTitle = department.Title })
                 .Join(MKB, record => record.Record.MKBCode, mkb => mkb.MKBCode, (record, mkb) => new RecordViewItem
                 {
                     DepartmentTitle = record.DepartmentTitle,
                     DateOfReceipt = record.Record.DateOfReceipt,
                     DateOfDischarge = record.Record.DateOfDischarge,
                     HistoryNumber = record.Record.HistoryNumber,
                     MKBCodeTitle = mkb.MKBCode
                 })
                 .ToList();
            RecordsTable.DataSource = recordsDataSource;

            //RecordsTable.DataSource = records;
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

        /// <summary>
        /// Заполняет текстовые поля
        /// </summary>
        private void InitTextFieldsDefaultValues()
        {
            PatientNumberLabel.Text = $"{DefaultPatientItem.LastName.Substring(0, 1)}-{DefaultPatientItem.PatientNumber}";
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

        /// <summary>
        /// Создание обработчиков ввода для полей
        /// </summary>
        private void InitTextFieldsChanged()
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
        }

        /// <summary>
        /// Меняет сойство Enable у SaveButton 
        /// </summary>
        private void MakeSaveButtonActive()
        {
            SaveButton.Enabled = false;
            if (ErrorsFormPatientAndRecords.LastName || ErrorsFormPatientAndRecords.FirstName ||
                ErrorsFormPatientAndRecords.MiddleName || ErrorsFormPatientAndRecords.DateOfBirth ||
                ErrorsFormPatientAndRecords.Region || ErrorsFormPatientAndRecords.District ||
                ErrorsFormPatientAndRecords.City || ErrorsFormPatientAndRecords.Address ||
                ErrorsFormPatientAndRecords.Phone || ErrorsFormPatientAndRecords.Index)
                return;

            foreach (bool edited in Edited)
                if (edited)
                {
                    SaveButton.Enabled = true;
                    break;
                }
        }

        #region
        // Валидация полей ввода
        private void LastNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(LastNameTextField.Text, ErrorTextLabel, ErrorColor, "Фамилия состоит только из букв !");
            Edited[0] = false;

            if (!isNotError)
                LastNameTextField.ForeColor = ErrorColor;
            else if (LastNameTextField.Text != DefaultPatientItem.LastName)
            {
                LastNameTextField.ForeColor = EditColor;
                Edited[0] = true;
            }
            else
                LastNameTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.LastName = !isNotError;
            MakeSaveButtonActive();
        }
        private void FirstNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(FirstNameTextField.Text, ErrorTextLabel, ErrorColor, "Имя состоит только из букв !");
            Edited[1] = false;

            if (!isNotError)
                FirstNameTextField.ForeColor = ErrorColor;
            else if (FirstNameTextField.Text != DefaultPatientItem.FirstName)
            {
                FirstNameTextField.ForeColor = EditColor;
                Edited[1] = true;
            }
            else
                FirstNameTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.FirstName = !isNotError;
            MakeSaveButtonActive();
        }
        private void MiddleNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(MiddleNameTextField.Text, ErrorTextLabel, ErrorColor, "Отчество состоит только из букв !");
            Edited[2] = false;

            if (!isNotError)
                MiddleNameTextField.ForeColor = ErrorColor;
            else if (MiddleNameTextField.Text != DefaultPatientItem.MiddleName)
            {
                MiddleNameTextField.ForeColor = EditColor;
                Edited[2] = true;
            }
            else
                MiddleNameTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.MiddleName = !isNotError;
            MakeSaveButtonActive();
        }
        private void DateOfBirthTextField_Changed(object? sender, EventArgs e)
        {
            string text = DateOfBirthTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, ErrorTextLabel, ErrorColor, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfBirthTextField);
                isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text, ErrorTextLabel);
            }
            Edited[3] = false;

            try
            {
                if (!isNotError && DateOfBirthTextField.Text.Length == 10)
                    DateOfBirthTextField.ForeColor = ErrorColor;
                else if (DateOfBirthTextField.Text != DefaultPatientItem.DateOfBirth.ToShortDateString())
                {
                    DateOfBirthTextField.ForeColor = EditColor;
                    Edited[3] = true;
                }
                else
                    DateOfBirthTextField.ForeColor = DefaultColor;
            }
            catch
            {
                MessageBox.Show("Ошибка конвертации DateOfBirthTextField");
            }

            ErrorsFormPatientAndRecords.DateOfBirth = !isNotError;
            MakeSaveButtonActive();
        }
        private void RegionTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(RegionTextField);
            bool isNotError = ValidationForm.StringStartsWithLetter(RegionTextField.Text, ErrorTextLabel, ErrorColor, "Регион должен начинаться с буквы !");
            Edited[4] = false;

            if (!isNotError)
                RegionTextField.ForeColor = ErrorColor;
            else if (RegionTextField.Text != DefaultPatientItem.Region)
            {
                RegionTextField.ForeColor = EditColor;
                Edited[4] = true;
            }
            else
                RegionTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.Region = !isNotError;
            MakeSaveButtonActive();
        }
        private void DistrictTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(DistrictTextField);
            bool isNotError = ValidationForm.StringStartsWithLetter(DistrictTextField.Text, ErrorTextLabel, ErrorColor, "Район должен начинаться с буквы !");
            Edited[5] = false;

            if (!isNotError)
                DistrictTextField.ForeColor = ErrorColor;
            else if (DistrictTextField.Text != DefaultPatientItem.District)
            {
                DistrictTextField.ForeColor = EditColor;
                Edited[5] = true;
            }
            else
                DistrictTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.District = !isNotError;
            MakeSaveButtonActive();
        }
        private void CityTextField_Changed(object? sender, EventArgs e)
        {
            bool isNotError = ValidationForm.StringStartsWithLetter(CityTextField, ErrorTextLabel, ErrorColor, "Город должен начинаться с буквы !");
            Edited[6] = false;

            if (!isNotError)
                CityTextField.ForeColor = ErrorColor;
            else if (CityTextField.Text != DefaultPatientItem.City)
            {
                CityTextField.ForeColor = EditColor;
                Edited[6] = true;
            }
            else
                CityTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.City = !isNotError;
            MakeSaveButtonActive();
        }
        private void AddressTextField_Changed(object? sender, EventArgs e)
        {
            bool isNotError = ValidationForm.StringStartsWithLetter(AddressTextField, ErrorTextLabel, ErrorColor, "Адрес должен начинаться с буквы !");
            Edited[7] = false;

            if (!isNotError)
                AddressTextField.ForeColor = ErrorColor;
            else if (AddressTextField.Text != DefaultPatientItem.Address)
            {
                AddressTextField.ForeColor = EditColor;
                Edited[7] = true;
            }
            else
                AddressTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.Address = !isNotError;
            MakeSaveButtonActive();
        }
        private void PhoneTextField_Changed(object? sender, EventArgs e)
        {
            bool isNotError = ValidationForm.ValidationIsNumber(PhoneTextField.Text, ErrorTextLabel, ErrorColor, "Номер телефона может состоять только из цифр !");
            if (isNotError)
                isNotError = ValidationForm.CheckingLengthOfString(PhoneTextField.Text, 11, ErrorTextLabel, ErrorColor, "Длина номера телефона не может быть больше 11 символов !");
            Edited[8] = false;

            if (!isNotError)
                PhoneTextField.ForeColor = ErrorColor;
            else if (PhoneTextField.Text != DefaultPatientItem.Phone)
            {
                PhoneTextField.ForeColor = EditColor;
                Edited[8] = true;
            }
            else
                PhoneTextField.ForeColor = DefaultColor;

            ErrorsFormPatientAndRecords.Phone = !isNotError;
            MakeSaveButtonActive();
        }
        private void IndexTextField_Changed(object? sender, EventArgs e)
        {
            bool isNotError = ValidationForm.ValidationIsNumber(IndexTextField.Text, ErrorTextLabel, ErrorColor, "Индекс может состоять только из цифр !");
            if (isNotError)
                isNotError = ValidationForm.CheckingLengthOfString(IndexTextField.Text, 6, ErrorTextLabel, ErrorColor, "Длина индекса не может быть больше 6 символов !");
            Edited[9] = false;

            try
            {
                if (!isNotError)
                    IndexTextField.ForeColor = ErrorColor;
                else if (IndexTextField.Text != DefaultPatientItem.IndexAddress)
                {
                    IndexTextField.ForeColor = EditColor;
                    Edited[9] = true;
                }
                else
                    IndexTextField.ForeColor = DefaultColor;
            }
            catch
            {
                MessageBox.Show("Ошибка конвертации IndexTextField");
            }

            ErrorsFormPatientAndRecords.Index = !isNotError;
            MakeSaveButtonActive();
        }
        #endregion

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

        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            var FormAddRecord = new FormAddRecord(DefaultPatientItem.PatientID);
            FormAddRecord.Show();
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, что нет ошибок
                if (ErrorsFormPatientAndRecords.LastName)
                {
                    MessageBox.Show("Ошибка ввода фамилии");
                    return;
                }
                if (ErrorsFormPatientAndRecords.FirstName)
                {
                    MessageBox.Show("Ошибка ввода имени");
                    return;
                }
                if (ErrorsFormPatientAndRecords.MiddleName)
                {
                    MessageBox.Show("Ошибка ввода отчества");
                    return;
                }
                if (ErrorsFormPatientAndRecords.DateOfBirth)
                {
                    MessageBox.Show("Ошибка ввода даты рождения");
                    return;
                }
                if (ErrorsFormPatientAndRecords.Region)
                {
                    MessageBox.Show("Ошибка ввода региона");
                    return;
                }
                if (ErrorsFormPatientAndRecords.District)
                {
                    MessageBox.Show("Ошибка ввода района");
                    return;
                }
                if (ErrorsFormPatientAndRecords.City)
                {
                    MessageBox.Show("Ошибка ввода города");
                    return;
                }
                if (ErrorsFormPatientAndRecords.Address)
                {
                    MessageBox.Show("Ошибка ввода адреса");
                    return;
                }
                if (ErrorsFormPatientAndRecords.Phone)
                {
                    MessageBox.Show("Ошибка ввода телефона");
                    return;
                }
                if (ErrorsFormPatientAndRecords.Index)
                {
                    MessageBox.Show("Ошибка ввода индекса");
                    return;
                }

                // Сохранение в базе данных
                DBase dBase = new DBase();
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

                bool isNotError = dBase.UpdateEntryInDB<PatientItem, Guid>(DefaultPatientItem.PatientID, patient);

                if (!isNotError)
                    MessageBox.Show("Ошибка изменения записи !");
                else
                {
                    // DefaultPatientItem Init
                    Dictionary<string, object> fieldAndValuePatientTable = new Dictionary<string, object>()
                    {
                        { "PatientID", DefaultPatientItem.PatientID }
                    };
                    List<PatientItem> patients = dBase.SearchData<PatientItem>(fieldAndValuePatientTable);
                    DefaultPatientItem = patients[0];

                    InitTextFieldsDefaultValues();
                    for (int i = 0; i < Edited.Length; i++)
                        Edited[i] = false;
                    MakeSaveButtonActive();
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
                dBase.CloseDatabaseConnection();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Непредвиденная ошибка: [{error.Message}]");
            }
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
                ShowOrHideButton.Text = "Показать";
            }
            else
            {
                recordsDataSource = recordsDataSourceClone;
                RecordsTable.DataSource = recordsDataSource;
                ShowOrHideButton.Text = "Скрыть";
            }

            isVisible = !isVisible;
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
        static public bool LastName { get; set; } = false;
        static public bool FirstName { get; set; } = false;
        static public bool MiddleName { get; set; } = false;
        static public bool DateOfBirth { get; set; } = false;
        static public bool Region { get; set; } = false;
        static public bool District { get; set; } = false;
        static public bool City { get; set; } = false;
        static public bool Address { get; set; } = false;
        static public bool Phone { get; set; } = false;
        static public bool Index { get; set; } = false;
    }
}
