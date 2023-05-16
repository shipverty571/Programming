using System;
using System.ComponentModel.DataAnnotations;
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
        [CustomValidation(typeof(ValueValidator), nameof(ValueValidator.ValidateName))]
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
        [CustomValidation(typeof(ValueValidator), nameof(ValueValidator.ValidateEmail))]
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
        [CustomValidation(typeof(ValueValidator), nameof(ValueValidator.ValidatePhone))]
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
    }
}