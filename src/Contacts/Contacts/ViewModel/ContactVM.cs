using System.ComponentModel;
using System.Runtime.CompilerServices;
using Contacts.Model;

namespace Contacts.ViewModel
{
    public class ContactVM : INotifyPropertyChanged
    {
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        public Contact Contact { get; set; }

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

        public void Clear()
        {
            Name = null;
            Email = null;
            Phone = null;
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