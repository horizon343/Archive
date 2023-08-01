using System.Text.RegularExpressions;

namespace Archive.Validation
{
    static class ValidationForm
    {
        #region Formatting data
        /// <summary>
        /// Меняет регистр первой буквы (с прописной на заглавную)
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        static public void FirstLetterToUpperCase(TextBox textField)
        {
            int selectionStart = textField.SelectionStart;
            if (textField.Text.Length >= 1)
                textField.Text = textField.Text.Substring(0, 1).ToUpper() + textField.Text.Substring(1);
            textField.SelectionStart = selectionStart;
        }

        /// <summary>
        /// Приведение даты к формату dd.mm.yyyy
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        static public void DateFormatting(TextBox textField)
        {
            string text = textField.Text;
            text = new string(text.Where(symbol => char.IsDigit(symbol)).ToArray());

            if (text.Length >= 3)
                text = text.Insert(2, ".");
            if (text.Length >= 6)
                text = text.Insert(5, ".");

            textField.Text = text;
            textField.SelectionStart = text.Length;
        }

        /// <summary>
        /// Оставляет в строке только буквы
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        /// <param name="considerGaps">Учитывать ли пробелы в строке</param>
        static public void StringOfLetter(TextBox textField, bool considerGaps = false)
        {
            int selectionStart = textField.SelectionStart;
            string text = textField.Text;
            text = new string(text.Where(symbol => char.IsLetter(symbol) || (symbol == ' ' && considerGaps)).ToArray());

            textField.Text = text;
            textField.SelectionStart = selectionStart;
        }

        /// <summary>
        /// Оставляет в строке только цифры
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        static public void StringOfNumber(TextBox textField)
        {
            int selectionStart = textField.SelectionStart;
            string text = textField.Text;
            text = new string(text.Where(symbol => char.IsDigit(symbol)).ToArray());

            textField.Text = text;
            textField.SelectionStart = selectionStart;
        }
        #endregion

        #region Text validation
        /// <summary>
        /// Проверка, что строка состоит только из букв
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="errorTextLabel">Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        /// <returns></returns>
        static public bool StringConsistsOfLetters(string text, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = @"^\p{L}+$";

            if (Regex.IsMatch(text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }

        /// <summary>
        /// Проверка, что строка состоит только из цифр
        /// </summary>
        /// <param name="textField">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        static public bool ValidationIsNumber(string text, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = "^[0-9]+$";

            if (Regex.IsMatch(text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }

        /// <summary>
        /// Проверка на корректность даты (не прошлый век и не будущее)
        /// </summary>
        /// <param name="text">Строка с датой в формате dd.mm.yyyy</param>
        /// <param name="errorText">Label: Поле ошибки</param>
        static public bool DateIsValid(string text, Label errorText)
        {
            try
            {
                errorText.ForeColor = Color.Red;

                if (text.Length == 10)
                {
                    string[] DateArray = text.Split(".");
                    DateTime todayDate = DateTime.Now;
                    DateTime minDate = new DateTime(1900, 12, 31);
                    DateTime Date = new DateTime(int.Parse(DateArray[2]), int.Parse(DateArray[1]), int.Parse(DateArray[0]));
                    if (Date > todayDate || Date < minDate)
                    {
                        errorText.Text = "Дата выходит за допустимые границы !";
                        return false;
                    }
                    else
                    {
                        errorText.Text = "";
                        return true;
                    }
                }
                else if (text.Length > 10)
                {
                    errorText.Text = "Некорректная дата !";
                    return false;
                }
                return false;
            }
            catch
            {
                errorText.Text = "Некорректная дата !";
                return false;
            }
        }
        /// <summary>
        /// Проверка на корректность даты (не прошлый век и не будущее)
        /// </summary>
        /// <param name="text">Строка с датой в формате dd.mm.yyyy</param>
        static public bool DateIsValid(string text)
        {
            try
            {
                string[] dateArray = text.Split(".");
                DateTime todayDate = DateTime.Now;
                DateTime minDate = new DateTime(1900, 12, 31);
                DateTime date = new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[1]), int.Parse(dateArray[0]));
                if (date > todayDate || date < minDate)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка, что строка начинается с буквы
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        static public bool StringStartsWithLetter(string text, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = @"^\p{L}";

            if (Regex.IsMatch(text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }

        /// <summary>
        /// Проверка длины строки
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="length">Максимальная длина строки</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        static public bool CheckingLengthOfString(string text, int length, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            if (text.Length <= length)
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }
        #endregion


        /// <summary>
        /// Проверка, что строка начинается с буквы
        /// </summary>
        /// <param name="textField">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        static public bool StringStartsWithLetter(TextBox textField, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = @"^\p{L}";

            if (Regex.IsMatch(textField.Text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }

        /// <summary>
        /// Проверка корректности номера пациента (формта А-123)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        /// <returns></returns>
        static public bool PatientNumberFormat(string text, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = @"^\p{L}-\d+$";
            if (Regex.IsMatch(text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
            errorTextLabel.ForeColor = color;
            errorTextLabel.Text = errorText;
            return false;
        }

    }
}
