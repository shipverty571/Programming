namespace Contacts.Model
{
    /// <summary>
    /// Хранит данные о контакте.
    /// </summary>
    public class Contact
    {
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

        public Contact(Contact contact)
        {
            Name = contact.Name;
            Email = contact.Email;
            Phone = contact.Phone;
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
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задаёт электронную почту контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string Phone { get; set; }
    }
}