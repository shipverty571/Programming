using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Shapes;

namespace Contacts.Model.Services
{
    /// <summary>
    /// Представляет реализацию по сериализации данных.
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Проводит сериализацию данных.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        /// <param name="path">Путь сериализации.</param>
        public static void Serialize(Contact contact, string path)
        {
            if (!Directory.Exists(path + @"\Contacts")) Directory.CreateDirectory(path + @"\Contacts");
            using (StreamWriter writer = new StreamWriter(path + @"\Contacts\contacts.json"))
            {
                writer.Write(JsonConvert.SerializeObject(contact));
            }
        }

        /// <summary>
        /// Проводит десериализацию данных.
        /// </summary>
        /// <param name="path">Путь десериализации.</param>
        /// <returns>Возвращает экземпляр класса Contact.</returns>
        public static Contact Deserialize(string path)
        {
            if (!Directory.Exists(path + @"\Contacts")) Directory.CreateDirectory(path + @"\Contacts");
            var contact = new Contact();
            try
            {
                using (StreamReader reader = new StreamReader(path + @"\Contacts\contacts.json"))
                {
                    contact = JsonConvert.DeserializeObject<Contact>(reader.ReadToEnd());
                }

                if (contact == null) contact = new Contact();
            }
            catch
            {
                return contact;
            }

            return contact;
        }
    }
}
