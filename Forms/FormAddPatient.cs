using Archive.Data;
using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormAddPatient : Form
    {
        private Guid PatientID { get; set; }
        private bool AddPatientNotError = true;

        private string EndSymbol = StorageLocation.currentStorageLocation ?? "Б";

        public FormAddPatient()
        {
            InitializeComponent();

            InitTextField();
            InitErrorsAddPatients();
            InitButton();
        }

        #region Init
        public void InitTextField()
        {
            LastNameErrorText.ForeColor = Color.Red;
            FirstNameErrorText.ForeColor = Color.Red;
            DateOfBirthErrorText.ForeColor = Color.Red;

            LastNameTextField.TextChanged += LastNameTextField_TextChanged;
            FirstNameTextField.TextChanged += FirstNameTextField_TextChanged;
            MiddleNameTextField.TextChanged += MiddleNameTextField_TextChanged;
            DateOfBirthTextField.TextChanged += DateOfBirthTextField_TextChanged;
            RegionTextField.TextChanged += RegionTextField_TextChanged;
            DistrictTextField.TextChanged += DistrictTextField_TextChanged;
            CityTextField.TextChanged += CityTextField_TextChanged;
            PhoneTextField.TextChanged += PhoneTextField_TextChanged;
            IndexTextField.TextChanged += IndexTextField_TextChanged;
        }
        public void InitErrorsAddPatients()
        {
            ErrorsAddPatients.LastName = true;
            ErrorsAddPatients.FirstName = true;
            ErrorsAddPatients.MiddleName = false;
            ErrorsAddPatients.DateOfBirth = true;
            ErrorsAddPatients.Region = false;
            ErrorsAddPatients.District = false;
            ErrorsAddPatients.City = false;
            ErrorsAddPatients.Address = false;
            ErrorsAddPatients.Phone = false;
            ErrorsAddPatients.Index = false;
        }
        public void InitButton()
        {
            AddPatient.Enabled = false;
            AddPatientAndRecords.Enabled = false;
        }
        #endregion

        #region TextChanged
        private void LastNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            ValidationForm.StringOfLetter(LastNameTextField);
            if (LastNameTextField.Text.Length > 0)
            {
                LastNameErrorText.Text = "";
                ErrorsAddPatients.LastName = false;
            }
            else
            {
                LastNameErrorText.Text = "Заполните поле";
                ErrorsAddPatients.LastName = true;
            }

            ButtonStatusToggle();
        }
        private void FirstNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            ValidationForm.StringOfLetter(FirstNameTextField);
            if (FirstNameTextField.Text.Length > 0)
            {
                FirstNameErrorText.Text = "";
                ErrorsAddPatients.FirstName = false;
            }
            else
            {
                FirstNameErrorText.Text = "Заполните поле";
                ErrorsAddPatients.FirstName = true;
            }

            ButtonStatusToggle();
        }
        private void MiddleNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            ValidationForm.StringOfLetter(MiddleNameTextField);
        }
        private void DateOfBirthTextField_TextChanged(object? sender, EventArgs e)
        {
            DateOfBirthTextField.MaxLength = 10;

            ValidationForm.DateFormatting(DateOfBirthTextField);
            if (DateOfBirthTextField.Text.Length <= 0)
            {
                DateOfBirthErrorText.Text = "Заполните поле";
                ErrorsAddPatients.DateOfBirth = true;
            }
            else if (DateOfBirthTextField.Text.Length == 10)
            {
                bool isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text);
                if (isNotError)
                {
                    DateOfBirthErrorText.Text = "";
                    ErrorsAddPatients.DateOfBirth = false;
                }
                else
                {
                    DateOfBirthErrorText.Text = "Некорректная дата";
                    ErrorsAddPatients.DateOfBirth = true;
                }
            }
            else
            {
                DateOfBirthErrorText.Text = "";
                ErrorsAddPatients.DateOfBirth = true;
            }

            ButtonStatusToggle();
        }
        private void RegionTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(RegionTextField);
            ValidationForm.StringOfLetter(RegionTextField, true);
        }
        private void DistrictTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(DistrictTextField);
            ValidationForm.StringOfLetter(DistrictTextField, true);
        }
        private void CityTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(CityTextField);
            ValidationForm.StringOfLetter(CityTextField, true);
        }
        private void PhoneTextField_TextChanged(object? sender, EventArgs e)
        {
            PhoneTextField.MaxLength = 11;
            ValidationForm.StringOfNumber(PhoneTextField);
        }
        private void IndexTextField_TextChanged(object? sender, EventArgs e)
        {
            IndexTextField.MaxLength = 6;
            ValidationForm.StringOfNumber(IndexTextField);
        }
        #endregion

        // Button status toggle
        private void ButtonStatusToggle()
        {
            if (ErrorsAddPatients.LastName || ErrorsAddPatients.FirstName || ErrorsAddPatients.DateOfBirth)
            {
                AddPatient.Enabled = false;
                AddPatientAndRecords.Enabled = false;
            }
            else
            {
                AddPatient.Enabled = true;
                AddPatientAndRecords.Enabled = true;
            }
        }

        private void AddPatient_Click(object sender, EventArgs e)
        {
            AddPatient.Enabled = false;
            AddPatientAndRecords.Enabled = false;

            try
            {
                DataBase dataBase = new DataBase();

                // Устанавливаем PatientNumber
                List<PatientItem> patients;
                int PatientNumber = 1;
                List<int> patientNumbers = new List<int>();
                Task.Run(async () =>
                {
                    patients = await dataBase.GetEntriesStartAndEndCharacter<PatientItem>(LastNameTextField.Text.Substring(0, 1), EndSymbol, "PatientNumber", "PatientNumber");
                    foreach (PatientItem patientItem in patients)
                    {
                        string[] patientNumberParse = patientItem.PatientNumber.Split("-");
                        patientNumbers.Add(int.Parse(patientNumberParse[1]));
                    }
                }).Wait();
                patientNumbers.Sort();
                foreach (int number in patientNumbers)
                {
                    if (PatientNumber == number)
                        PatientNumber += 1;
                    else
                        break;
                }

                // Сохранение в базе данных
                PatientID = Guid.NewGuid();
                PatientItem newPatient = new PatientItem()
                {
                    PatientID = PatientID,
                    PatientNumber = $"{LastNameTextField.Text.Substring(0, 1)}-{PatientNumber}-{EndSymbol}",
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

                Task.Run(async () =>
                {
                    await dataBase.InsertEntry<PatientItem>(newPatient);
                }).Wait();

                this.Close();
            }
            catch (Exception error)
            {
                AddPatientNotError = false;
                MessageBox.Show($"Непредвиденная ошибка: [{error.Message}]");
            }

            AddPatient.Enabled = true;
            AddPatientAndRecords.Enabled = true;
        }

        private void AddPatientAndRecords_Click(object sender, EventArgs e)
        {
            AddPatient_Click(sender, e);

            if (AddPatientNotError)
            {
                var FormAddRecord = new FormAddRecord(PatientID);
                FormAddRecord.Show();
            }
        }
    }

    static class ErrorsAddPatients
    {
        static public bool LastName { get; set; }
        static public bool FirstName { get; set; }
        static public bool MiddleName { get; set; }
        static public bool DateOfBirth { get; set; }
        static public bool Region { get; set; }
        static public bool District { get; set; }
        static public bool City { get; set; }
        static public bool Address { get; set; }
        static public bool Phone { get; set; }
        static public bool Index { get; set; }
    }
}
