using Archive.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archive.Validation;

namespace Archive.Forms
{
    public partial class FormPatients : Form
    {
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        private int limit = 100;

        public FormPatients()
        {
            InitializeComponent();

            PatientsTableInit(CurrentPage, limit);

            PatientsTable.CellDoubleClick += PatientsTable_CellDoubleClick;
            LastNameTextField.TextChanged += LastNameTextField_Changed;
            FirstNameTextField.TextChanged += FirstNameTextField_Changed;
            MiddleNameTextField.TextChanged += MiddleNameTextField_Changed;
            DateOfBirthTextField.TextChanged += DateOfBirthTextField_Changed;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";

            PrevPageButton.Enabled = false;
            if (CurrentPage >= TotalCount)
                NextPageButton.Enabled = false;

            foreach (DataGridViewColumn column in PatientsTable.Columns)
                column.ReadOnly = true;

            // Задаем названия полям
            PatientsTable.Columns[0].HeaderText = "Фамилия";
            PatientsTable.Columns[1].HeaderText = "Имя";
            PatientsTable.Columns[2].HeaderText = "Отчество";
            PatientsTable.Columns[3].HeaderText = "Дата рождения";

            //Устанавливаем стили для таблицы
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            PatientsTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientsTable.Columns[3].Width = 200;
            PatientsTable.DefaultCellStyle = cellStyle;
        }

        private void PatientsTableInit(int currentPage, int limit)
        {
            // Получение таблицы пациентов из базы данных
            DBase dBase = new DBase();
            (int, List<PatientItem>) patients = dBase.GetTable<PatientItem>(currentPage, limit);
            dBase.CloseDatabaseConnection();
            TotalCount = patients.Item1;

            // Выбираем только необходимые поля и добавляем пациентов втаблицу
            List<PatientViewItem> patientsDataSource = patients.Item2.Select(patient => new PatientViewItem()
            {
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                DateOfBirth = patient.DateOfBirth
            }).ToList();
            PatientsTable.DataSource = patientsDataSource;

            CountPageTextBox.Text = $"{CurrentPage} / {TotalCount}";
        }

        #region
        // Клики по кнопкам
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
                PatientsTableInit(CurrentPage, limit);

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
                PatientsTableInit(CurrentPage, limit);

                if (CurrentPage - 1 < 1)
                    PrevPageButton.Enabled = false;
            }
        }
        #endregion

        #region
        // Валидация полей ввода
        private void LastNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(LastNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(LastNameTextField.Text, TextError, Color.Red, "Фамилия состоит только из букв !");
            ErrorsFormPatients.LastName = !isNotError;
            if (LastNameTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormPatients.LastName = false;
            }
            if (ErrorsFormPatients.LastName)
                LastNameTextField.ForeColor = Color.Red;
            else
                LastNameTextField.ForeColor = Color.Black;
        }

        private void FirstNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(FirstNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(FirstNameTextField.Text, TextError, Color.Red, "Имя состоит только из букв !");
            ErrorsFormPatients.FirstName = !isNotError;
            if (FirstNameTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormPatients.FirstName = false;
            }
            if (ErrorsFormPatients.FirstName)
                FirstNameTextField.ForeColor = Color.Red;
            else
                FirstNameTextField.ForeColor = Color.Black;
        }

        private void MiddleNameTextField_Changed(object? sender, EventArgs e)
        {
            ValidationForm.FirstLetterToUpperCase(MiddleNameTextField);
            bool isNotError = ValidationForm.StringConsistsOfLetters(MiddleNameTextField.Text, TextError, Color.Red, "Отчество состоит только из букв !");
            ErrorsFormPatients.MiddleName = !isNotError;
            if (MiddleNameTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormPatients.MiddleName = false;
            }
            if (ErrorsFormPatients.MiddleName)
                MiddleNameTextField.ForeColor = Color.Red;
            else
                MiddleNameTextField.ForeColor = Color.Black;
        }

        private void DateOfBirthTextField_Changed(object? sender, EventArgs e)
        {
            string text = DateOfBirthTextField.Text.Replace(".", "");
            bool isNotError = ValidationForm.ValidationIsNumber(text, TextError, Color.Red, "Дата может содержать только цифры !");
            if (isNotError)
            {
                ValidationForm.DateFormatting(DateOfBirthTextField);
                isNotError = ValidationForm.DateIsValid(DateOfBirthTextField.Text, TextError);
            }
            ErrorsFormPatients.DateOfBirth = !isNotError;
            if (DateOfBirthTextField.Text == "")
            {
                TextError.Text = "";
                ErrorsFormPatients.DateOfBirth = false;
            }
            if (ErrorsFormPatients.DateOfBirth && TextError.Text != "")
                DateOfBirthTextField.ForeColor = Color.Red;
            else
                DateOfBirthTextField.ForeColor = Color.Black;
        }
        #endregion

        private void PatientsTable_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var FormPatientAndRecords = new FormPatientAndRecords();
                FormPatientAndRecords.Show();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (ErrorsFormPatients.LastName)
            {
                MessageBox.Show("LastName");
                return;
            }
            if (ErrorsFormPatients.FirstName)
            {
                MessageBox.Show("FirstName");
                return;
            }
            if (ErrorsFormPatients.MiddleName)
            {
                MessageBox.Show("MiddleName");
                return;
            }
            if (ErrorsFormPatients.DateOfBirth)
            {
                MessageBox.Show("DateOfBirth");
                return;
            }

            TotalCount = 1;
            CurrentPage = 1;

            Dictionary<string, object> fields = new Dictionary<string, object>();
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
                DBase dBase = new DBase();
                List<PatientItem> patients = dBase.SearchData<PatientItem>(fields);
                dBase.CloseDatabaseConnection();

                // Выбираем только необходимые поля и добавляем пациентов в таблицу
                List<PatientViewItem> patientsDataSource = patients.Select(patient => new PatientViewItem()
                {
                    LastName = patient.LastName,
                    FirstName = patient.FirstName,
                    MiddleName = patient.MiddleName,
                    DateOfBirth = patient.DateOfBirth
                }).ToList();
                PatientsTable.DataSource = patientsDataSource;

                CountPageTextBox.Text = $"1 / 1";
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = false;
            }
            else
            {
                PatientsTableInit(CurrentPage, limit);
                PrevPageButton.Enabled = false;
                NextPageButton.Enabled = true;
            }
        }
    }

    class PatientViewItem
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    static class ErrorsFormPatients
    {
        static public bool LastName { get; set; } = false;
        static public bool FirstName { get; set; } = false;
        static public bool MiddleName { get; set; } = false;
        static public bool DateOfBirth { get; set; } = false;
    }
}
