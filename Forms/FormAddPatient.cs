using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormAddPatient : Form
    {
        private Guid PatientID { get; set; }
        private bool AddPatientNotError = false;

        public FormAddPatient()
        {
            InitializeComponent();

            LastNameTextField.TextChanged += LastNameTextField_TextChanged;
            LastNameErrorText.ForeColor = Color.Orange;

            FirstNameTextField.TextChanged += FirstNameTextField_TextChanged;
            FirstNameErrorText.ForeColor = Color.Orange;

            MiddleNameTextField.TextChanged += MiddleNameTextField_TextChanged;
            MiddleNameErrorText.ForeColor = Color.Orange;

            DateOfBirthTextField.TextChanged += DateOfBirthTextField_TextChanged;
            DateOfBirthErrorText.ForeColor = Color.Orange;

            RegionTextField.TextChanged += RegionTextField_TextChanged;
            RegionErrorText.ForeColor = Color.Orange;

            DistrictTextField.TextChanged += DistrictTextField_TextChanged;
            DistrictErrorText.ForeColor = Color.Orange;

            CityTextField.TextChanged += CityTextField_TextChanged;
            CityErrorText.ForeColor = Color.Orange;

            AddressTextField.TextChanged += AddressTextField_TextChanged;
            AddressErrorText.ForeColor = Color.Orange;

            PhoneTextField.TextChanged += PhoneTextField_TextChanged;
            PhoneErrorText.ForeColor = Color.Orange;

            IndexTextField.TextChanged += IndexTextField_TextChanged;
            IndexErrorText.ForeColor = Color.Orange;
        }

        #region
        // ��������� ����� �����
        private void LastNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.LastName = false;
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(LastNameTextField.Text, LastNameErrorText, Color.Red, "������� ������� ������ �� ���� !");
            ErrorsAddPatients.LastName = !isNotError;
        }
        private void FirstNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.FirstName = false;
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(FirstNameTextField.Text, FirstNameErrorText, Color.Red, "��� ������� ������ �� ���� !");
            ErrorsAddPatients.FirstName = !isNotError;
        }
        private void MiddleNameTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(MiddleNameTextField.Text, MiddleNameErrorText, Color.Red, "�������� ������� ������ �� ���� !");
            ErrorsAddPatients.MiddleName = !isNotError;
        }
        private void DateOfBirthTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.DateOfBirth = false;
            string text = DateOfBirthTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, DateOfBirthErrorText, Color.Red, "���� ����� ��������� ������ ����� !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfBirthTextField);
                isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text, DateOfBirthErrorText);
            }
            ErrorsAddPatients.DateOfBirth = !isNotError;
        }
        private void RegionTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(RegionTextField);
            bool isNotError = ValidationForm.StringStartsWithLetter(RegionTextField, RegionErrorText, Color.Red, "������ ������ ���������� � ����� !");
            ErrorsAddPatients.Region = !isNotError;
        }
        private void DistrictTextField_TextChanged(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(DistrictTextField);
            bool isNotError = ValidationForm.StringStartsWithLetter(DistrictTextField, DistrictErrorText, Color.Red, "����� ������ ���������� � ����� !");
            ErrorsAddPatients.District = !isNotError;
        }
        private void CityTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.City = false;
            bool isNotError = ValidationForm.StringStartsWithLetter(CityTextField, CityErrorText, Color.Red, "����� ������ ���������� � ����� !");
            ErrorsAddPatients.City = !isNotError;
        }
        private void AddressTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.Address = false;
            bool isNotError = ValidationForm.StringStartsWithLetter(AddressTextField, AddressErrorText, Color.Red, "����� ������ ���������� � ����� !");
            ErrorsAddPatients.Address = !isNotError;
        }
        private void PhoneTextField_TextChanged(object? sender, EventArgs e)
        {
            ErrorsAddPatients.Phone = false;
            bool isNotError = ValidationForm.ValidationIsNumber(PhoneTextField.Text, PhoneErrorText, Color.Red, "����� �������� ����� �������� ������ �� ���� !");
            if (isNotError)
                isNotError = ValidationForm.CheckingLengthOfString(PhoneTextField.Text, 11, PhoneErrorText, Color.Red, "����� ������ �������� �� ����� ���� ������ 11 �������� !");
            ErrorsAddPatients.Phone = !isNotError;
        }
        private void IndexTextField_TextChanged(object? sender, EventArgs e)
        {
            bool isNotError = ValidationForm.ValidationIsNumber(IndexTextField.Text, IndexErrorText, Color.Red, "������ ����� �������� ������ �� ���� !");
            if (isNotError)
                isNotError = ValidationForm.CheckingLengthOfString(IndexTextField.Text, 6, IndexErrorText, Color.Red, "����� ������� �� ����� ���� ������ 6 �������� !");
            ErrorsAddPatients.Index = !isNotError;
        }
        #endregion

        private void AddPatient_Click(object sender, EventArgs e)
        {
            try
            {
                // ��������, ��� ��� ������
                if (ErrorsAddPatients.LastName)
                {
                    MessageBox.Show("������ ����� �������");
                    return;
                }
                if (ErrorsAddPatients.FirstName)
                {
                    MessageBox.Show("������ ����� �����");
                    return;
                }
                if (ErrorsAddPatients.MiddleName)
                {
                    MessageBox.Show("������ ����� ��������");
                    return;
                }
                if (ErrorsAddPatients.DateOfBirth)
                {
                    MessageBox.Show("������ ����� ���� ��������");
                    return;
                }
                if (ErrorsAddPatients.Region)
                {
                    MessageBox.Show("������ ����� �������");
                    return;
                }
                if (ErrorsAddPatients.District)
                {
                    MessageBox.Show("������ ����� ������");
                    return;
                }
                if (ErrorsAddPatients.City)
                {
                    MessageBox.Show("������ ����� ������");
                    return;
                }
                if (ErrorsAddPatients.Address)
                {
                    MessageBox.Show("������ ����� ������");
                    return;
                }
                if (ErrorsAddPatients.Phone)
                {
                    MessageBox.Show("������ ����� ��������");
                    return;
                }
                if (ErrorsAddPatients.Index)
                {
                    MessageBox.Show("������ ����� �������");
                    return;
                }

                // ������������� �������� Index
                int Index = 0;
                if (IndexTextField.Text != "")
                    Index = int.Parse(IndexTextField.Text);

                DBase dBase = new DBase();
                List<PatientItem> patients = dBase.GetEntriesStartingWithLetter<PatientItem>(LastNameTextField.Text.Substring(0, 1), "LastName");

                // ������������� �������� PatientNumber
                patients.Sort((p1, p2) => p1.PatientNumber.CompareTo(p2.PatientNumber));
                int PatientNumber = 1;
                foreach (PatientItem patientSorted in patients)
                {
                    if (PatientNumber == patientSorted.PatientNumber)
                        PatientNumber += 1;
                    else
                        break;
                }

                // ���������� � ���� ������
                PatientID = Guid.NewGuid();
                PatientItem patient = new PatientItem()
                {
                    PatientID = PatientID,
                    PatientNumber = PatientNumber,
                    LastName = LastNameTextField.Text,
                    FirstName = FirstNameTextField.Text,
                    MiddleName = MiddleNameTextField.Text,
                    DateOfBirth = DateTime.Parse(DateOfBirthTextField.Text),
                    Region = RegionTextField.Text,
                    District = DistrictTextField.Text,
                    City = CityTextField.Text,
                    Address = AddressTextField.Text,
                    Phone = PhoneTextField.Text,
                    Index = Index,
                };

                dBase.SetDataTable<PatientItem>(patient);
                dBase.CloseDatabaseConnection();

                AddPatientNotError = true;
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show($"�������������� ������: [{error.Message}]");
            }
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
        static public bool LastName { get; set; } = true;
        static public bool FirstName { get; set; } = true;
        static public bool MiddleName { get; set; } = false;
        static public bool DateOfBirth { get; set; } = true;
        static public bool Region { get; set; } = false;
        static public bool District { get; set; } = false;
        static public bool City { get; set; } = true;
        static public bool Address { get; set; } = true;
        static public bool Phone { get; set; } = true;
        static public bool Index { get; set; } = false;
    }
}
