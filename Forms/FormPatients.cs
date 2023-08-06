using Archive.DB;
using System.Data;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormPatients : Form
    {
        private int TotalCount { get; set; }
        private int CurrentPage { get; set; }
        private int limit = 1;

        private List<PatientItem> PatientItem { get; set; }
        private List<PatientViewItem> patientsDataSource;

        private int columnIndex = -1;

        Dictionary<string, object> fields;
        private bool isSearchByFields = false;

        public FormPatients()
        {
            InitializeComponent();

            InitPatientsTable(1, limit);
            InitEvent();
            InitTable();
            InitErrorsFormPatients();

            PrevPageButton.Enabled = false;
            if (CurrentPage >= TotalCount)
                NextPageButton.Enabled = false;
        }

        #region Init
        private void InitEvent()
        {
            PatientsTable.CellDoubleClick += PatientsTable_CellDoubleClick;
            PatientsTable.CellClick += PatientsTable_CellClick;
            PatientNumberTextField.TextChanged += PatientNumberTextField_Changed;
            LastNameTextField.TextChanged += LastNameTextField_Changed;
            FirstNameTextField.TextChanged += FirstNameTextField_Changed;
            MiddleNameTextField.TextChanged += MiddleNameTextField_Changed;
            DateOfBirthTextField.TextChanged += DateOfBirthTextField_Changed;
            PatientNumberTextField.KeyPress += PressingEnterInTextField;
            LastNameTextField.KeyPress += PressingEnterInTextField;
            FirstNameTextField.KeyPress += PressingEnterInTextField;
            MiddleNameTextField.KeyPress += PressingEnterInTextField;
            DateOfBirthTextField.KeyPress += PressingEnterInTextField;
        }
        private void InitTable()
        {
            // Задаем названия полям
            PatientsTable.Columns[0].HeaderText = "Номер";
            PatientsTable.Columns[1].HeaderText = "Фамилия";
            PatientsTable.Columns[2].HeaderText = "Имя";
            PatientsTable.Columns[3].HeaderText = "Отчество";
            PatientsTable.Columns[4].HeaderText = "Дата рождения";

            // Устанавливаем стили для таблицы
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            PatientsTable.DefaultCellStyle = cellStyle;

            // Устанавливаем размер столбцов
            PatientsTable.Columns[0].Width = 100;
            PatientsTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[4].Width = 200;

            foreach (DataGridViewColumn column in PatientsTable.Columns)
                column.ReadOnly = true;
        }
        private void InitErrorsFormPatients()
        {
            ErrorsFormPatients.PatientNumber = false;
            ErrorsFormPatients.LastName = false;
            ErrorsFormPatients.FirstName = false;
            ErrorsFormPatients.MiddleName = false;
            ErrorsFormPatients.DateOfBirth = false;
        }
        private void InitPatientsTable(int currentPage, int limit)
        {
            Task.Run(async () =>
            {
                DataBase dataBase = new DataBase();
                (List<PatientItem>, int) patients = await dataBase.GetPagedEntries<PatientItem>(currentPage, limit, "PatientID");

                PatientItem = patients.Item1;
                TotalCount = patients.Item2;
            }).Wait();

            CurrentPage = TotalCount == 0 ? 0 : currentPage;

            // Выбираем только необходимые поля и добавляем пациентов в таблицу
            patientsDataSource = PatientItem.Select(patient => new PatientViewItem()
            {
                PatientNumber = patient.PatientNumber,
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                DateOfBirth = patient.DateOfBirth
            }).ToList();
            PatientsTable.DataSource = patientsDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }
        #endregion

        #region ButtonClick
        private void AddPatientButton_Click(object sender, EventArgs e)
        {
            var FormAddPatient = new FormAddPatient();
            FormAddPatient.Show();
        }
        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage + 1 <= TotalCount)
            {
                CurrentPage += 1;
                PrevPageButton.Enabled = true;
                if (isSearchByFields)
                    SearchByFields(fields);
                else
                    InitPatientsTable(CurrentPage, limit);

                if (CurrentPage + 1 > TotalCount)
                    NextPageButton.Enabled = false;
            }
        }
        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            if (CurrentPage - 1 >= 1)
            {
                CurrentPage -= 1;
                NextPageButton.Enabled = true;
                if (isSearchByFields)
                    SearchByFields(fields);
                else
                    InitPatientsTable(CurrentPage, limit);

                if (CurrentPage - 1 < 1)
                    PrevPageButton.Enabled = false;
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                TotalCount = 1;
                CurrentPage = 1;

                // Собираем поля и значения для запроса
                fields = new Dictionary<string, object>();
                if (PatientNumberTextField.Text != "")
                    fields.Add("PatientNumber", PatientNumberTextField.Text);
                if (LastNameTextField.Text != "")
                    fields.Add("LastName", LastNameTextField.Text);
                if (FirstNameTextField.Text != "")
                    fields.Add("FirstName", FirstNameTextField.Text);
                if (MiddleNameTextField.Text != "")
                    fields.Add("MiddleName", MiddleNameTextField.Text);
                if (DateOfBirthTextField.Text != "")
                    fields.Add("DateOfBirth", DateTime.Parse(DateOfBirthTextField.Text));

                if (fields.Count != 0)
                {
                    SearchByFields(fields);
                    isSearchByFields = true;

                    PrevPageButton.Enabled = false;
                    NextPageButton.Enabled = true;
                    if (CurrentPage + 1 > TotalCount)
                        NextPageButton.Enabled = false;
                }
                else
                {
                    InitPatientsTable(CurrentPage, limit);
                    isSearchByFields = false;

                    PrevPageButton.Enabled = false;
                    NextPageButton.Enabled = true;
                    if (CurrentPage + 1 > TotalCount)
                        NextPageButton.Enabled = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Непредвиденная ошибка: [{error.Message}]");
            }
        }
        #endregion

        #region TextChanged
        private void PatientNumberTextField_Changed(object? sender, EventArgs e)
        {
            string text = PatientNumberTextField.Text;
            int selectionStart = PatientNumberTextField.SelectionStart;

            PatientNumberTextField.Text = text.ToUpper();
            PatientNumberTextField.SelectionStart = selectionStart;

            bool isNotError = ValidationForm.ValidationPatientNumber(text);
            if (isNotError || text.Length == 0)
                ErrorsFormPatients.PatientNumber = false;
            else
                ErrorsFormPatients.PatientNumber = true;

            SearchButtonStatusToggle();
        }
        private void LastNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            ValidationForm.StringOfLetter(LastNameTextField);
        }
        private void FirstNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            ValidationForm.StringOfLetter(FirstNameTextField);
        }
        private void MiddleNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            ValidationForm.StringOfLetter(MiddleNameTextField);
        }
        private void DateOfBirthTextField_Changed(object? sender, EventArgs e)
        {
            DateOfBirthTextField.MaxLength = 10;

            ValidationForm.DateFormatting(DateOfBirthTextField);
            if (DateOfBirthTextField.Text.Length < 10 && DateOfBirthTextField.Text.Length > 0)
                ErrorsFormPatients.DateOfBirth = true;
            else if (DateOfBirthTextField.Text.Length == 10)
            {
                bool isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text);
                if (isNotError)
                    ErrorsFormPatients.DateOfBirth = false;
                else
                    ErrorsFormPatients.DateOfBirth = true;
            }
            else
                ErrorsFormPatients.DateOfBirth = false;

            SearchButtonStatusToggle();
        }
        #endregion

        // Button status toggle
        private void SearchButtonStatusToggle()
        {
            if (ErrorsFormPatients.PatientNumber || ErrorsFormPatients.DateOfBirth)
                SearchButton.Enabled = false;
            else
                SearchButton.Enabled = true;
        }

        private void SearchByFields(Dictionary<string, object> fields)
        {
            Task.Run(async () =>
            {
                DataBase dataBase = new DataBase();
                (List<PatientItem>, int) patients = await dataBase.GetPagedEntries<PatientItem>(CurrentPage, limit, "PatientID", "*", fields);

                PatientItem = patients.Item1;
                TotalCount = patients.Item2;
            }).Wait();

            // Выбираем только необходимые поля и добавляем пациентов в таблицу
            patientsDataSource = PatientItem.Select(patient => new PatientViewItem()
            {
                PatientNumber = patient.PatientNumber,
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                DateOfBirth = patient.DateOfBirth

            }).ToList();
            PatientsTable.DataSource = patientsDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }

        private void PressingEnterInTextField(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && SearchButton.Enabled == true)
            {
                SearchButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void PatientsTable_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) return;

            Func<PatientViewItem, object> sortingFunc;
            bool sortingFuncPatientNumber = false;

            switch (e.ColumnIndex)
            {
                case 1:
                    sortingFunc = patient => patient.LastName;
                    break;
                case 2:
                    sortingFunc = patient => patient.FirstName;
                    break;
                case 3:
                    sortingFunc = patient => patient.MiddleName;
                    break;
                case 4:
                    sortingFunc = patient => patient.DateOfBirth;
                    break;
                default:
                    sortingFuncPatientNumber = true;
                    sortingFunc = patient => patient.PatientNumber;
                    break;
            }

            if (columnIndex != e.ColumnIndex && !sortingFuncPatientNumber)
                patientsDataSource = patientsDataSource.OrderBy(sortingFunc).ToList();
            else if (columnIndex != e.ColumnIndex && sortingFuncPatientNumber)
            {
                PatientNumberComparer patientNumberComparer = new PatientNumberComparer();
                patientsDataSource = patientsDataSource.OrderBy(patient => patient.PatientNumber, patientNumberComparer).ToList();
            }
            else
            {
                List<PatientViewItem> patientsDataSourceReverse = patientsDataSource.ToList();
                patientsDataSourceReverse.Reverse();
                patientsDataSource = patientsDataSourceReverse;
            }

            PatientsTable.DataSource = patientsDataSource;
            columnIndex = e.ColumnIndex;
        }

        private void PatientsTable_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var FormPatientAndRecords = new FormPatientAndRecords(PatientItem[e.RowIndex].PatientID);
                FormPatientAndRecords.Show();
            }
        }
    }

    class PatientViewItem
    {
        public string PatientNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    static class ErrorsFormPatients
    {
        static public bool PatientNumber { get; set; }
        static public bool LastName { get; set; }
        static public bool FirstName { get; set; }
        static public bool MiddleName { get; set; }
        static public bool DateOfBirth { get; set; }
    }

    public class PatientNumberComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            try
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                string[] xParts = x.Split('-');
                string[] yParts = y.Split('-');

                int prefixComparison = string.Compare(xParts[0], yParts[0]);

                if (prefixComparison != 0)
                    return prefixComparison;

                int xNumber = int.Parse(xParts[1]);
                int yNumber = int.Parse(yParts[1]);

                return xNumber.CompareTo(yNumber);
            }
            catch
            {
                return -1;
            }
        }
    }
}
