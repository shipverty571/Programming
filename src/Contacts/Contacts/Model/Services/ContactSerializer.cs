using Newtonsoft.Json;
using System;
using System.IO;

namespace Contacts.Model.Services
{
    /// <summary>
    /// Представляет реализацию по сериализации данных.
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Путь до директории сохранения файла.
        /// </summary>
        public static string Path { get; } = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Contacts";

        /// <summary>
        /// Проводит сериализацию данных.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public static void Serialize(Contact contact)
        {
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            using (StreamWriter writer = new StreamWriter(Path + @"\contacts.json"))
            {
                writer.Write(JsonConvert.SerializeObject(contact));
            }
        }

        /// <summary>
        /// Проводит десериализацию данных.
        /// </summary>
        /// <returns>Возвращает экземпляр класса Contact.</returns>
        public static Contact Deserialize()
        {
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            var contact = new Contact();
            try
            {
                using (StreamReader reader = new StreamReader(Path + @"\contacts.json"))
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
