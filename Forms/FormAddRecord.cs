using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormAddRecord : Form
    {
        private List<DepartmentItem> DepartmentItemField { get; set; }
        private List<MKBItem> MKBItemField { get; set; }

        private Guid PatientID { get; }

        public FormAddRecord(Guid patientID)
        {
            InitializeComponent();
            PatientID = patientID;

            DateOfReceiptTextField.TextChanged += DateOfReceiptTextField_Changed;
            DateOfReceiptErrorText.ForeColor = Color.Orange;

            DateOfDischargeTextField.TextChanged += DateOfDischargeTextField_Changed;
            DateOfDischargeErrorText.ForeColor = Color.Orange;

            HistoryNumberTextField.TextChanged += HistoryNumberTextField_Changed;
            HistoryNumberErrorText.ForeColor = Color.Orange;

            DepartmentSelect.SelectedIndexChanged += DepartmentSelect_SelectedIndexChanged;
            DepartmentTextField.TextChanged += DepartmentTextField_Changed;

            MKBCodeSelect.SelectedIndexChanged += MKBCodeSelect_SelectedIndexChanged;
            MKBCodeTextField.TextChanged += MKBCodeTextField_Changed;

            // Получение списка МКБ кодов и отделений
            DBase dBase = new DBase();
            (int, List<DepartmentItem>) departments = dBase.GetTable<DepartmentItem>(-1, 50);
            (int, List<MKBItem>) MKBCodes = dBase.GetTable<MKBItem>(-1, 50);
            dBase.CloseDatabaseConnection();
            DepartmentItemField = departments.Item2;
            MKBItemField = MKBCodes.Item2;

            // Установление значений для поля "Отделение"
            List<string> departmentsTitle = new List<string>();
            foreach (DepartmentItem department in DepartmentItemField)
                departmentsTitle.Add(department.Title);

            AutoCompleteStringCollection departmentsSource = new AutoCompleteStringCollection();
            departmentsSource.AddRange(departmentsTitle.ToArray());

            DepartmentTextField.AutoCompleteCustomSource = departmentsSource;
            DepartmentTextField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DepartmentTextField.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DepartmentSelect.Items.AddRange(departmentsTitle.ToArray());

            // Установление значений для поля "МКБ код"
            List<string> MKBTitle = new List<string>();
            foreach (MKBItem MKB in MKBItemField)
                MKBTitle.Add(MKB.Title);

            AutoCompleteStringCollection MKBSource = new AutoCompleteStringCollection();
            MKBSource.AddRange(MKBTitle.ToArray());

            MKBCodeTextField.AutoCompleteCustomSource = MKBSource;
            MKBCodeTextField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MKBCodeTextField.AutoCompleteSource = AutoCompleteSource.CustomSource;

            MKBCodeSelect.Items.AddRange(MKBTitle.ToArray());
        }

        #region
        // Валидация полей ввода
        private void DepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ErrorsAddRecords.Department = false;
            DepartmentTextField.Text = DepartmentSelect.SelectedItem.ToString();
        }
        private void DepartmentTextField_Changed(object? sender, EventArgs e)
        {
            ErrorsAddRecords.Department = false;
        }
        private void DateOfReceiptTextField_Changed(object? sender, EventArgs e)
        {
            ErrorsAddRecords.DateOfReceipt = false;
            string text = DateOfReceiptTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, DateOfReceiptErrorText, Color.Red, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfReceiptTextField);
                isNotError = ValidationForm.DateIsValid(DateOfReceiptTextField.Text, DateOfReceiptErrorText);
            }
            ErrorsAddRecords.DateOfReceipt = !isNotError;
        }
        private void DateOfDischargeTextField_Changed(object? sender, EventArgs e)
        {
            ErrorsAddRecords.DateOfDischarge = false;
            string text = DateOfDischargeTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, DateOfDischargeErrorText, Color.Red, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfDischargeTextField);
                isNotError = ValidationForm.DateIsValid(DateOfDischargeTextField.Text, DateOfDischargeErrorText);
                if (isNotError && !ErrorsAddRecords.DateOfDischarge && !ErrorsAddRecords.DateOfReceipt)
                {
                    string[] DateOfReceiptArray = DateOfReceiptTextField.Text.Split(".");
                    string[] DateOfDischargeArray = DateOfDischargeTextField.Text.Split(".");
                    DateTime DateOfReceipt = new DateTime(int.Parse(DateOfReceiptArray[2]), int.Parse(DateOfReceiptArray[1]), int.Parse(DateOfReceiptArray[0]));
                    DateTime DateOfDischarge = new DateTime(int.Parse(DateOfDischargeArray[2]), int.Parse(DateOfDischargeArray[1]), int.Parse(DateOfDischargeArray[0]));

                    if (DateOfReceipt > DateOfDischarge)
                    {
                        DateOfDischargeErrorText.Text = "Дата поступления не может быть больше даты выписки !";
                        DateOfDischargeErrorText.ForeColor = Color.Red;
                        isNotError = false;
                    }
                }
            }
            ErrorsAddRecords.DateOfDischarge = !isNotError;
        }
        private void HistoryNumberTextField_Changed(object? sender, EventArgs e)
        {
            ErrorsAddRecords.HistoryNumber = false;
            bool isNotError = ValidationForm.ValidationIsNumber(HistoryNumberTextField.Text, HistoryNumberErrorText, Color.Red, "Номер истории может содержать только цифры !");
            ErrorsAddRecords.HistoryNumber = !isNotError;
        }
        private void MKBCodeSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ErrorsAddRecords.MKB = false;
            MKBCodeTextField.Text = MKBCodeSelect.SelectedItem.ToString();
        }
        private void MKBCodeTextField_Changed(object? sender, EventArgs e)
        {
            ErrorsAddRecords.MKB = false;
        }
        #endregion

        private void AddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Устанавливаем значение DepartmentID
                int DepartmentID = -1;
                foreach (DepartmentItem department in DepartmentItemField)
                {
                    if (department.Title.ToLower() == DepartmentTextField.Text.ToLower())
                    {
                        DepartmentID = department.DepartmentID;
                        break;
                    }
                }
                if (DepartmentID == -1)
                    ErrorsAddRecords.Department = true;

                // Устанавливаем значение MKBCode
                string MKBCode = "";
                foreach (MKBItem MKB in MKBItemField)
                {
                    if (MKB.Title.ToLower() == MKBCodeTextField.Text.ToLower())
                    {
                        MKBCode = MKB.MKBCode;
                        break;
                    }
                }
                if (MKBCode == "")
                    ErrorsAddRecords.MKB = true;

                // Проверка, что нет ошибок
                if (ErrorsAddRecords.Department)
                {
                    MessageBox.Show("Ошибка ввода отделения");
                    return;
                }
                if (ErrorsAddRecords.DateOfReceipt)
                {
                    MessageBox.Show("Ошибка ввода даты поступления");
                    return;
                }
                if (ErrorsAddRecords.DateOfDischarge)
                {
                    MessageBox.Show("Ошибка ввода даты выписки");
                    return;
                }
                if (ErrorsAddRecords.HistoryNumber)
                {
                    MessageBox.Show("Ошибка ввода номера истории");
                    return;
                }
                if (ErrorsAddRecords.MKB)
                {
                    MessageBox.Show("Ошибка ввода МКБ кода");
                    return;
                }

                // Сохранение в базе данных
                RecordItem record = new RecordItem()
                {
                    DepartmentID = DepartmentID,
                    PatientID = PatientID,
                    DateOfReceipt = DateTime.Parse(DateOfReceiptTextField.Text),
                    DateOfDischarge = DateTime.Parse(DateOfDischargeTextField.Text),
                    HistoryNumber = int.Parse(HistoryNumberTextField.Text),
                    MKBCode = MKBCode
                };

                DBase dBase = new DBase();
                dBase.SetDataTable<RecordItem>(record);
                dBase.CloseDatabaseConnection();

                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Непредвиденная ошибка: [{error.Message}]");
            }
        }

    }

    static class ErrorsAddRecords
    {
        public static bool Department { get; set; } = true;
        public static bool DateOfReceipt { get; set; } = true;
        public static bool DateOfDischarge { get; set; } = true;
        public static bool HistoryNumber { get; set; } = true;
        public static bool MKB { get; set; } = true;
    }
}
