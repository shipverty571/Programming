namespace Contacts.Model.Services
{
    /// <summary>
    /// Представляет реализацию по хранению данных, полученных по API.
    /// </summary>
    public class ContactDto
    {
        /// <summary>
        /// Возвращает и задаёт имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Возвращает и задаёт фамилию.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возвращает и задаёт электронную почту.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возвращает и задаёт номер телефона.
        /// </summary>
        public string Phone { get; set; }
    }
}