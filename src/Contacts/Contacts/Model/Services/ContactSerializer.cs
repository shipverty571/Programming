using Newtonsoft.Json;
using System.IO;

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
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(JsonConvert.SerializeObject(contact));
            }
        }

        /// <summary>
        /// Проводит десериализацию данных.
        /// </summary>
        /// <param name="path">Путь десериализации.</param>
        /// <returns>Возвращает экземпляр класса <see cref="Contact"/>.</returns>
        public static Contact Deserialize(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) 
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            var contact = new Contact();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    contact = JsonConvert.DeserializeObject<Contact>(reader.ReadToEnd());
                }

                if (contact == null) contact = new Contact();
            }
            catch (FileNotFoundException e)
            {
                return contact;
            }

            return contact;
        }
    }
}
