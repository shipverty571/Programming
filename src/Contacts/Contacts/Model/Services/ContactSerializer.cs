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
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            if (!File.Exists(path))
            {
                return new Contact();
            }
            using (StreamReader reader = new StreamReader(path))
            {
                var contact = JsonConvert.DeserializeObject<Contact>(reader.ReadToEnd()) ?? new Contact();
                return contact;
            }
        }
    }
}