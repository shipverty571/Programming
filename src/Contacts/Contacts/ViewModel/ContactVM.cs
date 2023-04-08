using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Contacts.Model;

namespace Contacts.ViewModel
{
    public class ContactVM : INotifyPropertyChanged, ICloneable
    {
        /// <summary>
        ///     Создаёт экземпляр класса <see cref="ContactVM" />.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        /// <summary>
        ///     Возвращает и задаёт контакт.
        /// </summary>
        public Contact Contact { get; }

        /// <summary>
        ///     Возвращает и задаёт имя контакта.
        /// </summary>
        public string Name
        {
            get => Contact.Name;
            set
            {
                Contact.Name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Возвращает и задаёт электронную почту контакта.
        /// </summary>
        public string Email
        {
            get => Contact.Email;
            set
            {
                Contact.Email = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string Phone
        {
            get => Contact.Phone;
            set
            {
                Contact.Phone = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Клонирует текущий экземпляр класса <see cref="ContactVM" />.
        /// </summary>
        /// <returns>Возвращает дубликат текущего экземпляра.</returns>
        public object Clone()
        {
            return new ContactVM(new Contact(Contact));
        }

        /// <summary>
        ///     Событие изменения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     При вызове зажигает событие <see cref="PropertyChanged" />.
        /// </summary>
        /// <param name="propertyName">Имя свойства, вызвавшего метод.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}