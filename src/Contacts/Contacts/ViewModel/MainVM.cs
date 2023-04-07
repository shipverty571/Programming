using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Contacts.Model;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    /// <summary>
    ///     ViewModel для окна MainWindow.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        private bool _isEnabledButtons = true;

        private bool _isReadOnlyTextBoxes = true;

        private bool _isVisibilityApplyButton;

        private ContactVM _selectedContact;

        public ObservableCollection<ContactVM> Contacts { get; set; } =
            new ObservableCollection<ContactVM>();

        public ContactVM SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                IsVisibilityApplyButton = false;
                IsEnabledButtons = true;
                OnPropertyChanged();
            }
        }

        public bool IsReadOnlyTextBoxes
        {
            get => _isReadOnlyTextBoxes;
            set
            {
                _isReadOnlyTextBoxes = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabledButtons
        {
            get => _isEnabledButtons;
            set
            {
                _isEnabledButtons = value;
                OnPropertyChanged();
            }
        }

        public bool IsVisibilityApplyButton
        {
            get => _isVisibilityApplyButton;
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
                    SelectedContact = new ContactVM(new Contact());
                    IsVisibilityApplyButton = true;
                    IsEnabledButtons = false;
                    IsReadOnlyTextBoxes = false;
                });
            }
        }

        public ICommand ApplyCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Contacts.Add(SelectedContact);
                    IsVisibilityApplyButton = false;
                    IsEnabledButtons = true;
                    IsReadOnlyTextBoxes = true;
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