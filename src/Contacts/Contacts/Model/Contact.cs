namespace Contacts.Model
{
    /// <summary>
    /// Хранит данные о контакте.
    /// </summary>
    public class Contact
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
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="email">Электронная почта.</param>
        /// <param name="phone">Номер телефона.</param>
        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {

        }

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
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
    }
}
