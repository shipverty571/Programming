using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Contacts.Model;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private string _name;

        private string _email;

        private string _phone;

        public Contact Contact { get; private set; } = new Contact();

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

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    ContactSerializer.Serialize(Contact);
                });
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    var contact = ContactSerializer.Deserialize();
                    Name = contact.Name;
                    Email = contact.Email;
                    PhoneNumber = contact.Phone;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
