using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Contacts.Model;

namespace Contacts.ViewModel
{
    public class ContactVM : INotifyPropertyChanged, ICloneable
    {
        /// <summary>
        ///     Событие изменения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        public Contact Contact { get; private set; }

        public string Name
        {
            get => Contact.Name;
            set
            {
                Contact.Name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => Contact.Email;
            set
            {
                Contact.Email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => Contact.Phone;
            set
            {
                Contact.Phone = value;
                OnPropertyChanged();
            }
        }

        public object Clone()
        {
            return new ContactVM(new Contact(Contact));
        }

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