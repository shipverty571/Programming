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
        private bool _isEnabledAddButton = true;

        private bool _isEnabledRemoveButton = true;

        private bool _isEnabledEditButton = false;

        private bool _isEnabledRandomizeButton = true;

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
                IsEnabledAddButton = true;
                IsEnabledRemoveButton = true;
                IsEnabledRandomizeButton = true;
                _isEnabledEditButton = SelectedContact != null;
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

        public bool IsEnabledAddButton
        {
            get => _isEnabledAddButton;
            set
            {
                _isEnabledAddButton = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabledRemoveButton
        {
            get => _isEnabledRemoveButton;
            set
            {
                _isEnabledRemoveButton = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabledEditButton
        {
            get => _isEnabledEditButton;
            set
            {
                _isEnabledEditButton = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabledRandomizeButton
        {
            get => _isEnabledRandomizeButton;
            set
            {
                _isEnabledRandomizeButton = value;
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
                    IsEnabledAddButton = false;
                    IsEnabledRemoveButton = false;
                    IsEnabledRandomizeButton = false;
                    IsEnabledEditButton = false;
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
                    IsEnabledAddButton = true;
                    IsEnabledRemoveButton = true;
                    IsEnabledRandomizeButton = true;
                    IsEnabledEditButton = true;
                    IsReadOnlyTextBoxes = true;
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedContact == null) return;

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