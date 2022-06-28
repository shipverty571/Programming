namespace Programming.Model
{
    /// <summary>
    /// Хранит данные о контактных данных человека.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Номер.
        /// </summary>
        private string _number;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {

        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="name">Имя. Должно состоять только из букв английского алфавита.</param>
        /// <param name="surname">Фамилия. Должна состоять только из букв английского алфавита.</param>
        /// <param name="number">Номер. Должен состоять только из цифр.
        /// Должен иметь одиннадцать символов.</param>
        public Contact(string name,
                       string surname,
                       string number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        /// <summary>
        /// Возвращает и задаёт имя контакта. Должно состоять только из букв английского алфавита.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                Validator.AssertStringContainsOnlyLetters(nameof(Name), value);
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт фамилию контакта. Должна состоять только из букв английского алфавита.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                Validator.AssertStringContainsOnlyLetters(nameof(Surname), value);
                _surname = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номер контакта. Должен состоять только из цифр.
        /// Должен иметь одиннадцать символов.
        /// </summary>
        public string Number
        {
            get => _number;
            set
            {
                Validator.AssertValueContainsOnlyDigits(nameof(Number), value);
                Validator.AssertNumberContainsElevenDigit(nameof(Number), value);
                _number = value;
            }
        }
    }
}
