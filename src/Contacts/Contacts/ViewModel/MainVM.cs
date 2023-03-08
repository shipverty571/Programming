using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Contacts.Model;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    /// <summary>
    /// ViewModel для окна MainWindow.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Электронная почта.
        /// </summary>
        private string _email;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        private string _phone;

        /// <summary>
        /// Контакт.
        /// </summary>
        public Contact Contact { get; private set; } = new Contact();

        /// <summary>
        /// Возвращает и задаёт путь сериализации. По умолчанию - папка "Мои документы".
        /// </summary>
        public string Path { get; set; } = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Возвращает и задаёт имя контакта.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Contact.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Возвращает и задаёт электронную почту контакта.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                Contact.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                Contact.Phone = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        /// <summary>
        /// Команда сериализации контакта.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ContactSerializer.Serialize(Contact, Path);
                });
            }
        }

        /// <summary>
        /// Команда десериализации контакта.
        /// </summary>
        public ICommand LoadCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var contact = ContactSerializer.Deserialize(Path);
                    Name = contact.Name;
                    Email = contact.Email;
                    PhoneNumber = contact.Phone;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
