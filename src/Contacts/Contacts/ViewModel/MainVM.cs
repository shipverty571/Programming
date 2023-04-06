using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    /// <summary>
    ///     ViewModel для окна MainWindow.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<ContactVM> Contacts { get; set; } =
            new ObservableCollection<ContactVM>();

        private ContactVM _selectedContact;

        private bool _isVisibilityApplyButton;

        public ContactVM SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        public bool IsVisibilityApplyButton
        {
            get
            {
                return _isVisibilityApplyButton;
            }
            set
            {
                _isVisibilityApplyButton = value;
                OnPropertyChanged();
            }
        }

        public ICommand RandomizeCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var contact = ContactFactory.Randomize();
                    Contacts.Add(new ContactVM(contact));
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    SelectedContact = null;
                    IsVisibilityApplyButton = true;
                });
            }
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