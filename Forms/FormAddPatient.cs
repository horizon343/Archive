using Archive.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Archive.Forms
{
    public partial class FormAddPatient : Form
    {
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

            IndexTextField.TextChanged += TextChanged_TextChanged;
            IndexErrorText.ForeColor = Color.Orange;
        }

        /// <summary>
        /// Проверки: 1-Строка начинается с буквы, 2-Заменяет первую строчную букву на заглавную
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="errorText">Текст ошибки</param>
        private void TextFieldValidation_1(TextBox textField, Label errorText)
        {
            string pattern = @"^\p{L}";

            if (Regex.IsMatch(textField.Text, pattern))
            {
                int selectionStart = textField.SelectionStart;
                if (textField.Text.Length >= 1)
                    textField.Text = textField.Text.Substring(0, 1).ToUpper() + textField.Text.Substring(1);
                textField.SelectionStart = selectionStart;

                errorText.Text = "";
            }
            else
                errorText.Text = "Возможно допущена ошибка ?!";
        }

        /// <summary>
        /// Проверка: Строка начинается с буквы
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="errorText">Текст ошибки</param>
        private void TextFieldValidation_2(TextBox textField, Label errorText)
        {
            string pattern = @"^\p{L}";

            if (Regex.IsMatch(textField.Text, pattern))
                errorText.Text = "";
            else
                errorText.Text = "Возможно допущена ошибка ?!";
        }

        /// <summary>
        /// Проверки: 1-Строка состоит только из цифр, 2-Длина строки не больше length
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="errorText">Текст ошибки</param>
        /// <param name="length">Максимальная длина строки</param>
        private void TextFieldValidation_3(TextBox textField, Label errorText, int length)
        {
            string pattern = "^[0-9]+$";
            if (Regex.IsMatch(textField.Text, pattern) && textField.Text.Length <= length)
                errorText.Text = "";
            else
                errorText.Text = "Возможно допущена ошибка ?!";
        }

        /// <summary>
        /// Проверка на корректность даты (не прошлый век и не будущее)
        /// </summary>
        /// <param name="text">Строка с датой в формте dd.mm.yyyy</param>
        private void DateIsValid(string text)
        {
            try
            {
                DateOfBirthErrorText.ForeColor = Color.Orange;

                //Проверка допустимой даты
                if (text.Length == 10)
                {
                    string[] DateOfBirthArray = text.Split(".");
                    DateTime today = DateTime.Now;
                    DateTime minDate = new DateTime(1900, 12, 31);
                    DateTime DateOfBirth = new DateTime(int.Parse(DateOfBirthArray[2]), int.Parse(DateOfBirthArray[1]), int.Parse(DateOfBirthArray[0]));
                    if (DateOfBirth > today || DateOfBirth < minDate)
                    {
                        DateOfBirthErrorText.Text = "Ошибка даты!";
                        DateOfBirthErrorText.ForeColor = Color.Red;
                    }
                    else
                        DateOfBirthErrorText.Text = "";
                }
            }
            catch
            {
                DateOfBirthErrorText.Text = "Ошибка даты!";
                DateOfBirthErrorText.ForeColor = Color.Red;
            }
        }

        #region
        // Валидация полей ввода
        private void LastNameTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_1(LastNameTextField, LastNameErrorText);
        }
        private void FirstNameTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_1(FirstNameTextField, FirstNameErrorText);
        }
        private void MiddleNameTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_1(MiddleNameTextField, MiddleNameErrorText);
        }
        private void DateOfBirthTextField_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                DateOfBirthErrorText.ForeColor = Color.Orange;

                string text = DateOfBirthTextField.Text.Replace(".", "");

                //Проверка, что строка состоит из цифр
                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(text, pattern))
                {
                    if (text.Length > 8)
                        DateOfBirthErrorText.Text = "Возможно допущена ошибка ?!";
                    else
                        DateOfBirthErrorText.Text = "";
                }
                else
                    DateOfBirthErrorText.Text = "Возможно допущена ошибка ?!";

                //Автоматическое разделение
                if (text.Length >= 3)
                    text = text.Insert(2, ".");
                if (text.Length >= 6)
                    text = text.Insert(5, ".");
                DateOfBirthTextField.Text = text;
                DateOfBirthTextField.SelectionStart = text.Length;

                DateIsValid(text);
            }
            catch
            {
                DateOfBirthErrorText.Text = "Ошибка даты!";
                DateOfBirthErrorText.ForeColor = Color.Red;
            }
        }
        private void RegionTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_1(RegionTextField, RegionErrorText);
        }
        private void DistrictTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_1(DistrictTextField, DistrictErrorText);
        }
        private void CityTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_2(CityTextField, CityErrorText);
        }
        private void AddressTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_2(AddressTextField, AddressErrorText);
        }
        private void PhoneTextField_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_3(PhoneTextField, PhoneErrorText, 11);
        }
        private void TextChanged_TextChanged(object? sender, EventArgs e)
        {
            TextFieldValidation_3(IndexTextField, IndexErrorText, 6);
        }
        #endregion

        private void AddPatient_Click(object sender, EventArgs e)
        {
            try
            {
                PatientItem patient = new PatientItem()
                {
                    //PatientID = ???
                    LastName = LastNameTextField.Text,
                    FirstName = FirstNameTextField.Text,
                    MiddleName = MiddleNameTextField.Text,
                    DateOfBirth = DateTime.Parse(DateOfBirthTextField.Text),
                    Region = RegionTextField.Text,
                    District = DistrictTextField.Text,
                    City = CityTextField.Text,
                    Address = AddressTextField.Text,
                    Phone = PhoneTextField.Text,
                    Index = int.Parse(IndexTextField.Text),
                };

                DBase dBase = new DBase();
                dBase.SetDataTable<PatientItem>(patient);
                dBase.CloseDatabaseConnection();

                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка добавления пациента: [{error.Message}]");
            }
        }

    }
}
