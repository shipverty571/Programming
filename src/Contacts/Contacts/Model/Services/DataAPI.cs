using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Model.Services
{
    public class DataAPI
    {
        /// <summary>
        /// Возвращает и задаёт имя контакта.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Возвращает и задаёт имя контакта.
        /// </summary>
        public string LastName { get; set; }

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
