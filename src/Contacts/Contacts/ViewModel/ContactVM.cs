using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Contacts.Model;

namespace Contacts.ViewModel
{
    public class ContactVM : ObservableObject, ICloneable
    {
        /// <summary>
        ///  Создаёт экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        /// <summary>
        ///  Возвращает и задаёт контакт.
        /// </summary>
        public Contact Contact { get; }

        /// <summary>
        ///  Возвращает и задаёт имя контакта.
        /// </summary>
        public string Name
        {
            get => Contact.Name;
            set => SetProperty(
                Contact.Name,
                value,
                Contact,
                (contact, name) => Contact.Name = name);
        }

        /// <summary>
        ///  Возвращает и задаёт электронную почту контакта.
        /// </summary>
        public string Email
        {
            get => Contact.Email;
            set => SetProperty(
                Contact.Email,
                value,
                Contact,
                (contact, email) => Contact.Email = email);
        }

        /// <summary>
        ///  Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string Phone
        {
            get => Contact.Phone;
            set => SetProperty(
                Contact.Phone,
                value,
                Contact,
                (contact, phone) => Contact.Phone = phone);
        }

        /// <summary>
        ///  Клонирует текущий экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        /// <returns>Возвращает дубликат текущего экземпляра.</returns>
        public object Clone()
        {
            return new ContactVM((Contact)Contact.Clone());
        }
    }
}