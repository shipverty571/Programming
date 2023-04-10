using System;

namespace Contacts.Model
{
    /// <summary>
    ///  Хранит данные о контакте.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        ///  Создаёт экземпляр класса <see cref="Contact"/>.
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
        ///  Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        ///  Возвращает и задаёт имя контакта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Возвращает и задаёт электронную почту контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Возвращает и задаёт номер телефона контакта.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///  Клонирует текущий экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <returns>Возвращает дубликат текущего экземпляра.</returns>
        public object Clone()
        {
            return new Contact(Name, Email, Phone);
        }
    }
}