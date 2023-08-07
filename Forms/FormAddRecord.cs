using Archive.Data;
using Archive.DB;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormAddRecord : Form
    {
        private Guid PatientID { get; }

        private Color DefaultColor = Color.Black;
        private Color ErrorColor = Color.Red;

        public FormAddRecord(Guid patientID)
        {
            InitializeComponent();

            InitEvent();
            InitMKBItemField();
            InitDepartmentItemField();
            InitErrorsAddRecords();

            PatientID = patientID;
        }

        #region Init
        private void InitEvent()
        {
            DateOfReceiptTextField.TextChanged += DateOfReceiptTextField_Changed;
            DateOfDischargeTextField.TextChanged += DateOfDischargeTextField_Changed;
            HistoryNumberTextField.TextChanged += HistoryNumberTextField_Changed;
            DepartmentSelect.SelectedIndexChanged += DepartmentSelect_SelectedIndexChanged;
            DepartmentTextField.TextChanged += DepartmentTextField_Changed;
            MKBCodeSelect.SelectedIndexChanged += MKBCodeSelect_SelectedIndexChanged;
            MKBCodeTextField.TextChanged += MKBCodeTextField_Changed;
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
            string departmentTextFieldText = DepartmentTextField.Text;

            var selectedItem = DepartmentSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(departmentTextFieldText.ToLower()));

            if (selectedItem != null)
                DepartmentSelect.SelectedItem = selectedItem;

            MakeAddButtonActive();
        }
        private void DateOfReceiptTextField_Changed(object? sender, EventArgs e)
        {
            DateOfReceiptErrorText.Text = "";
            DateOfReceiptTextField.MaxLength = 10;
            DateOfReceiptTextField.ForeColor = DefaultColor;

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
            }
            else
                ErrorsAddRecords.DateOfReceipt = true;

            MakeAddButtonActive();
        }
        private void DateOfDischargeTextField_Changed(object? sender, EventArgs e)
        {
            DateOfDischargeErrorText.Text = "";
            DateOfDischargeTextField.MaxLength = 10;
            DateOfDischargeTextField.ForeColor = DefaultColor;

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
            ValidationForm.StringOfNumber(HistoryNumberTextField);

            MakeAddButtonActive();
        }
        private void MKBCodeSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            MKBCodeTextField.Text = MKBCodeSelect.SelectedItem.ToString();

            MakeAddButtonActive();
        }
        private void MKBCodeTextField_Changed(object? sender, EventArgs e)
        {
            string mkbTextFieldText = MKBCodeTextField.Text;

            var selectedItem = MKBCodeSelect.Items.Cast<string>()
                .FirstOrDefault(item => item.ToLower().Equals(mkbTextFieldText.ToLower()));

            if (selectedItem != null)
                MKBCodeSelect.SelectedItem = selectedItem;

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

            AddRecord.Enabled = false;
            if (ErrorsAddRecords.DateOfReceipt || ErrorsAddRecords.DateOfDischarge ||
                departmentSelect == null || departmentSelect.ToLower() != departmentTextField.ToLower() ||
                mkbCodeSelect == null || mkbCodeSelect.ToLower() != mkbTextFieldText.ToLower())
                return;

            AddRecord.Enabled = true;
        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Устанавливаем значение DepartmentID и MKBCode
                int? DepartmentID = Departments.DepartmentList.Find(department => DepartmentSelect.SelectedItem.ToString() == department.Title)?.DepartmentID;
                string? MKBCode = MKBCodeSelect.SelectedItem?.ToString();

                if (DepartmentID == null || MKBCode == null)
                    return;

                // Сохранение в базе данных
                RecordItem record = new RecordItem()
                {
                    DepartmentID = (int)DepartmentID,
                    PatientID = PatientID,
                    DateOfReceipt = DateTime.Parse(DateOfReceiptTextField.Text),
                    DateOfDischarge = DateTime.Parse(DateOfDischargeTextField.Text),
                    HistoryNumber = int.Parse(HistoryNumberTextField.Text),
                    MKBCode = MKBCode
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
