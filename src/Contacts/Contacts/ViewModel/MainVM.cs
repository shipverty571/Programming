using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Model;
using Contacts.Model.Services;

namespace Contacts.ViewModel
{
    /// <summary>
    /// ViewModel для окна MainWindow.
    /// </summary>
    public class MainVM : ObservableObject
    {
        /// <summary>
        /// Режим добавления.
        /// </summary>
        private bool _isAddMode;

        /// <summary>
        /// Режим редактирования.
        /// </summary>
        private bool _isEditMode;

        /// <summary>
        /// Текущий контакт.
        /// </summary>
        private ContactVM _selectedContact;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MainVM" />.
        /// </summary>
        public MainVM()
        {
            Contacts = ContactSerializer.Deserialize(Path);
            EditCommand = new RelayCommand(EditContact);
            AddCommand = new RelayCommand(AddContact);
            RemoveCommand = new RelayCommand(RemoveContact);
            RandomizeCommand = new RelayCommand(RandomizeContact);
            ApplyCommand = new RelayCommand(ApplyChangesContact);
            IsAddMode = true;
            IsEditMode = false;
        }

        /// <summary>
        /// Возвращает и задаёт путь сериализации. По умолчанию - папка "Мои документы".
        /// </summary>
        public string Path { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + @"\Contacts\contacts.json";

        /// <summary>
        /// Возвращает и задаёт коллекцию контактов.
        /// </summary>
        public ObservableCollection<ContactVM> Contacts { get; set; }

        /// <summary>
        /// Возвращает и задает исходную версию редактируемого контакта.
        /// </summary>
        public ContactVM Buffer { get; set; }

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public ContactVM SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                IsAddMode = true;
                if (SelectedContact == null)
                    IsEditMode = false;
                else
                    IsEditMode = true;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Возвращает команду генерации контакта.
        /// </summary>
        public ICommand RandomizeCommand { get; }

        /// <summary>
        /// Возвращает команду добавления контакта.
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// Возвращает команду принятия изменений.
        /// </summary>
        public ICommand ApplyCommand { get; }

        /// <summary>
        /// Возвращает команду редактирования контакта.
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Возвращает команду удаления контакта.
        /// </summary>
        public ICommand RemoveCommand { get; }

        /// <summary>
        /// Возвращает и задаёт значение активности режима добавления.
        /// </summary>
        public bool IsAddMode
        {
            get => _isAddMode;
            set => SetProperty(ref _isAddMode, value);
        }

        /// <summary>
        /// Возвращает и задаёт значение активности режима редактирования.
        /// </summary>
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        /// <summary>
        /// Возвращает и задаёт значение доступности кнопки добавления.
        /// </summary>
        /// <summary>
        /// Вызывает редактирование нового экземпляра класса <see cref="ContactVM" />.
        /// </summary>
        private void AddContact()
        {
            SelectedContact = null;
            Buffer = new ContactVM(new Contact());
            Buffer.Name = "";
            Buffer.Phone = "";
            Buffer.Email = "";
            SelectedContact = Buffer;
            IsAddMode = false;
            IsEditMode = true;
        }

        /// <summary>
        /// Генерирует случайный контакт.
        /// </summary>
        private void RandomizeContact()
        {
            var contact = ContactFactory.Randomize();
            if (contact == null)
                return;
            Contacts.Add(new ContactVM(contact));
            ContactSerializer.Serialize(Contacts, Path);
        }

        /// <summary>
        /// Вызывает редактирования текущего контакта.
        /// </summary>
        private void EditContact()
        {
            Buffer = SelectedContact;
            SelectedContact = (ContactVM)SelectedContact.Clone();
            IsAddMode = false;
            IsEditMode = false;
        }

        /// <summary>
        /// Удаляет текущий контакт.
        /// </summary>
        private void RemoveContact()
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
            ContactSerializer.Serialize(Contacts, Path);
        }

        /// <summary>
        /// Принимает изменения редактирования контакта.
        /// </summary>
        private void ApplyChangesContact()
        {
            if (!Contacts.Contains(Buffer))
                Contacts.Add(Buffer);
            IsAddMode = true;
            IsEditMode = true;
            var index = Contacts.IndexOf(Buffer);
            Contacts[index] = SelectedContact;
            SelectedContact = Contacts[index];
            ContactSerializer.Serialize(Contacts, Path);
        }
    }
}