using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using Contacts.Model;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    /// <summary>
    /// ViewModel для Contact.
    /// </summary>
    public class ContactVM : ObservableValidator, ICloneable
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="ContactVM" />.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        /// <summary>
        /// Возвращает и задаёт контакт.
        /// </summary>
        public Contact Contact { get; }

        /// <summary>
        /// Возвращает и задаёт имя контакта.
        /// </summary>
        [CustomValidation(typeof(ContactVM), nameof(ValidateName))]
        public string Name
        {
            get => Contact.Name;
            set => SetProperty(
                Contact.Name,
                value,
                Contact,
                (contact, name) => Contact.Name = name,
                true);
        }

        /// <summary>
        /// Возвращает и задаёт электронную почту контакта.
        /// </summary>
        [CustomValidation(typeof(ContactVM), nameof(ValidateEmail))]
        public string Email
        {
            get => Contact.Email;
            set => SetProperty(
                Contact.Email,
                value,
                Contact,
                (contact, email) => Contact.Email = email,
                true);
        }

        /// <summary>
        /// Возвращает и задаёт номер телефона контакта.
        /// </summary>
        [CustomValidation(typeof(ContactVM), nameof(ValidatePhone))]
        public string Phone
        {
            get => Contact.Phone;
            set => SetProperty(
                Contact.Phone,
                value,
                Contact,
                (contact, phone) => Contact.Phone = phone,
                true);
        }

        /// <summary>
        /// Клонирует текущий экземпляр класса <see cref="ContactVM" />.
        /// </summary>
        /// <returns>Возвращает дубликат текущего экземпляра.</returns>
        public object Clone()
        {
            return new ContactVM((Contact)Contact.Clone());
        }

        /// <summary>
        /// Валидация номера телефона.
        /// </summary>
        /// <param name="phone">Номер телефона.</param>
        /// <returns>Возвращает результат валидации <see cref="ValidationResult"/>.</returns>
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
        /// <returns>Возвращает результат валидации <see cref="ValidationResult"/>.</returns>
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
        /// <returns>Возвращает результат валидации <see cref="ValidationResult"/>.</returns>
        public static ValidationResult ValidateName(string name)
        {
            if (name.Length > 0 && name.Length <= 100)
                return ValidationResult.Success;

            return new ValidationResult("The name is not correctly.");
        }
    }
}