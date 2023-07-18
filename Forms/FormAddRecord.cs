using Archive.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive.Forms
{
    public partial class FormAddRecord : Form
    {


        public FormAddRecord()
        {
            InitializeComponent();

            DateOfReceiptTextField.TextChanged += DateOfReceiptTextField_Changed;
            DateOfReceiptErrorText.ForeColor = Color.Orange;

            DateOfDischargeTextField.TextChanged += DateOfDischargeTextField_Changed;
            DateOfDischargeErrorText.ForeColor = Color.Orange;

            HistoryNumberTextField.TextChanged += HistoryNumberTextField_Changed;
            HistoryNumberErrorText.ForeColor = Color.Orange;

            DBase dBase = new DBase();
            (int, List<DepartmentItem>) departments = dBase.GetTable<DepartmentItem>(-1, 50);
            dBase.CloseDatabaseConnection();

        }

        /// <summary>
        /// Проверка: Строка состоит только из цифр
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="errorText">Текст ошибки</param>
        private void ValidationIsNumber(TextBox textField, Label errorText)
        {
            string pattern = "^[0-9]+$";
            if (Regex.IsMatch(textField.Text, pattern))
                errorText.Text = "";
            else
                errorText.Text = "Возможно допущена ошибка ?!";
        }

        /// <summary>
        /// Проверка на корректность даты (не прошлый век и не будущее)
        /// </summary>
        /// <param name="text">Строка с датой в формте dd.mm.yyyy</param>
        private void DateIsValid(Label errorText, string text)
        {
            try
            {
                errorText.ForeColor = Color.Orange;

                //Проверка допустимой даты
                if (text.Length == 10)
                {
                    string[] DateArray = text.Split(".");
                    DateTime today = DateTime.Now;
                    DateTime minDate = new DateTime(1900, 12, 31);
                    DateTime Date = new DateTime(int.Parse(DateArray[2]), int.Parse(DateArray[1]), int.Parse(DateArray[0]));
                    if (Date > today || Date < minDate)
                    {
                        errorText.Text = "Ошибка даты!";
                        errorText.ForeColor = Color.Red;
                    }
                    else
                        errorText.Text = "";
                }
            }
            catch
            {
                errorText.Text = "Ошибка даты!";
                errorText.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Проверка, что строка состоит из цифр и приведение строки в формат dd.mm.yyyy
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="errorText">Текст ошибки</param>
        private void DateConversion(TextBox textField, Label errorText)
        {
            try
            {
                errorText.ForeColor = Color.Orange;

                string text = textField.Text.Replace(".", "");

                //Проверка, что строка состоит из цифр
                string pattern = "^[0-9]+$";
                if (Regex.IsMatch(text, pattern))
                {
                    if (text.Length > 8)
                        errorText.Text = "Возможно допущена ошибка ?!";
                    else
                        errorText.Text = "";
                }
                else
                    errorText.Text = "Возможно допущена ошибка ?!";

                //Автоматическое разделение
                if (text.Length >= 3)
                    text = text.Insert(2, ".");
                if (text.Length >= 6)
                    text = text.Insert(5, ".");
                textField.Text = text;
                textField.SelectionStart = text.Length;

                DateIsValid(errorText, text);
            }
            catch
            {
                errorText.Text = "Ошибка даты!";
                errorText.ForeColor = Color.Red;
            }
        }

        #region
        // Валидация полей ввода
        private void DateOfReceiptTextField_Changed(object? sender, EventArgs e)
        {
            DateConversion(DateOfReceiptTextField, DateOfReceiptErrorText);
        }
        private void DateOfDischargeTextField_Changed(object? sender, EventArgs e)
        {
            DateOfDischargeErrorText.Text = "";
            DateOfDischargeErrorText.ForeColor = Color.Orange;

            DateConversion(DateOfDischargeTextField, DateOfDischargeErrorText);

            if (DateOfReceiptErrorText.Text == "" && DateOfReceiptTextField.Text.Length == 10 &&
                DateOfDischargeErrorText.Text == "" && DateOfDischargeTextField.Text.Length == 10)
            {
                string[] DateOfReceiptArray = DateOfReceiptTextField.Text.Split(".");
                string[] DateOfDischargeArra = DateOfDischargeTextField.Text.Split(".");
                DateTime DateOfReceipt = new DateTime(int.Parse(DateOfReceiptArray[2]), int.Parse(DateOfReceiptArray[1]), int.Parse(DateOfReceiptArray[0]));
                DateTime DateOfDischarge = new DateTime(int.Parse(DateOfDischargeArra[2]), int.Parse(DateOfDischargeArra[1]), int.Parse(DateOfDischargeArra[0]));

                if (DateOfReceipt > DateOfDischarge)
                {
                    DateOfDischargeErrorText.Text = "Ошибка даты!";
                    DateOfDischargeErrorText.ForeColor = Color.Red;
                }
            }
        }
        private void HistoryNumberTextField_Changed(object? sender, EventArgs e)
        {
            ValidationIsNumber(HistoryNumberTextField, HistoryNumberErrorText);
        }
        #endregion

        private void AddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                RecordItem record = new RecordItem()
                {
                    //DepartmentID = ???
                    //PatientID = ???
                    DateOfReceipt = DateTime.Parse(DateOfReceiptTextField.Text),
                    DateOfDischarge = DateTime.Parse(DateOfDischargeTextField.Text),
                    HistoryNumber = int.Parse(HistoryNumberTextField.Text),
                    MKBCode = MKBCodeSelect.Text
                };

                DBase dBase = new DBase();
                dBase.SetDataTable<RecordItem>(record);
                dBase.CloseDatabaseConnection();

                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Ошибка добавления карты: [{error.Message}]");
            }
        }

    }
}
