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
        private bool _isEnabledAddButton;

        private bool _isEnabledEditButton;

        private bool _isEnabledRandomizeButton;

        private bool _isEnabledRemoveButton;

        private bool _isReadOnlyTextBoxes;

        private bool _isVisibilityApplyButton;

        private ContactVM _selectedContact;

        public MainVM()
        {
            Contacts = new ObservableCollection<ContactVM>();
            IsReadOnlyTextBoxes = true;
            IsVisibilityApplyButton = false;
            SetEnabled(true, false, false, true);
        }

        public ObservableCollection<ContactVM> Contacts { get; set; }

        public ContactVM Buffer { get; set; }

        public ContactVM SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (Buffer != null && Contacts.IndexOf(SelectedContact) != -1)
                {
                    Contacts[Contacts.IndexOf(SelectedContact)] = Buffer;
                    Buffer = null;
                }

                _selectedContact = value;
                IsVisibilityApplyButton = false;
                IsReadOnlyTextBoxes = true;
                if (_selectedContact == null)
                    SetEnabled(true, false, false, true);
                else
                    SetEnabled(true, true, true, true);
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
                    IsReadOnlyTextBoxes = false;
                    SetEnabled(false, false, false, false);
                });
            }
        }

        public ICommand ApplyCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (!Contacts.Contains(SelectedContact)) Contacts.Add(SelectedContact);
                    IsVisibilityApplyButton = false;
                    IsReadOnlyTextBoxes = true;
                    Buffer = null;
                    SetEnabled(true, true, true, true);
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Buffer = (ContactVM)SelectedContact.Clone();
                    IsReadOnlyTextBoxes = false;
                    IsVisibilityApplyButton = true;
                    SetEnabled(false, false, false, false);
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedContact == null) return;
                    var index = Contacts.IndexOf(SelectedContact);
                    Contacts.RemoveAt(index);
                    if (Contacts.Count == 0)
                        SelectedContact = null;
                    else if (index == Contacts.Count)
                        SelectedContact = Contacts[index - 1];
                    else
                        SelectedContact = Contacts[index];
                });
            }
        }

        /// <summary>
        ///     Событие изменения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetEnabled(
            bool addButton,
            bool removeButton,
            bool editButton,
            bool randomizeButton)
        {
            IsEnabledAddButton = addButton;
            IsEnabledRemoveButton = removeButton;
            IsEnabledEditButton = editButton;
            IsEnabledRandomizeButton = randomizeButton;
        }

        /// <summary>
        ///     При вызове зажигает событие <see cref="PropertyChanged" />.
        /// </summary>
        /// <param name="propertyName">Имя свойства, вызвавшего метод.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region BoolProperties

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

        #endregion
    }
}