using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ViewModel
{
    /// <summary>
    /// Хранит реализацию методов, предназначенных для валидации.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Валидация номера телефона.
        /// </summary>
        /// <param name="phone">Номер телефона.</param>
        /// <returns>Возвращает результат валидации <see cref="ValidationResult" />.</returns>
        public static ValidationResult ValidatePhone(string phone)
        {
            var pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            if (Regex.IsMatch(phone, pattern))
                return ValidationResult.Success;

            return new ValidationResult("The phone number is not correctly.");
        }

        /// <summary>
        /// Валидация адреса электронной почты.
        /// </summary>
        /// <param name="email">Электронная почта.</param>
        /// <returns>Возвращает результат валидации <see cref="ValidationResult" />.</returns>
        public static ValidationResult ValidateEmail(string email)
        {
            var pattern = @"^\w+\@{1}\w+\.{1}\w+";
            if (Regex.IsMatch(email, pattern))
                return ValidationResult.Success;

            return new ValidationResult("The email is not correctly.");
        }

        /// <summary>
        /// Валидация имени.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <returns>Возвращает результат валидации <see cref="ValidationResult" />.</returns>
        public static ValidationResult ValidateName(string name)
        {
            if (name.Length > 0 && name.Length <= 100)
                return ValidationResult.Success;

            return new ValidationResult("The name is not correctly.");
        }
    }
}