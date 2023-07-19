using System.Text.RegularExpressions;

namespace Archive.Validation
{
    static class ValidationForm
    {

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
        /// Проверка, что строка состоит только из букв
        /// </summary>
        /// <param name="textField">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
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
            errorTextLabel.Text = errorText;
            errorTextLabel.ForeColor = color;
            return false;
        }

        /// <summary>
        /// Проверка: Строка состоит только из цифр
        /// </summary>
        /// <param name="textField">Текст</param>
        /// <param name="errorTextLabel">Label: Поле ошибки</param>
        /// <param name="color">Цвет ошибки</param>
        /// <param name="errorText">Текст ошибки</param>
        static public bool ValidationIsNumber(string text, Label errorTextLabel, Color color, string errorText = "Возможно допущена ошибка ?!")
        {
            string pattern = "^[0-9]+$";
            errorTextLabel.ForeColor = color;

            if (Regex.IsMatch(text, pattern))
            {
                errorTextLabel.Text = "";
                return true;
            }
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
            if (text.Length > length)
            {
                errorTextLabel.Text = errorText;
                errorTextLabel.ForeColor = color;
                return false;
            }
            errorTextLabel.Text = "";
            return true;
        }

        /// <summary>
        /// Приведение даты к формату dd.mm.yyyy
        /// </summary>
        /// <param name="textField">Текстовое поле</param>
        static public void DateFormatting(TextBox textField)
        {
            string text = textField.Text.Replace(".", "");

            if (text.Length >= 3)
                text = text.Insert(2, ".");
            if (text.Length >= 6)
                text = text.Insert(5, ".");
            textField.Text = text;
            textField.SelectionStart = text.Length;
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

    }
}
