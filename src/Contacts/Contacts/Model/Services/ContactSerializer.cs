using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Contacts.ViewModel;

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
        public static void Serialize(ObservableCollection<ContactVM> contacts, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(JsonConvert.SerializeObject(contacts));
            }
        }

        /// <summary>
        /// Проводит десериализацию данных.
        /// </summary>
        /// <param name="path">Путь десериализации.</param>
        /// <returns>Возвращает экземпляр класса <see cref="Contact"/>.</returns>
        public static ObservableCollection<ContactVM> Deserialize(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            if (!File.Exists(path))
            {
                return new ObservableCollection<ContactVM>();
            }
            using (StreamReader reader = new StreamReader(path))
            {
                var contact = 
                    JsonConvert.DeserializeObject<ObservableCollection<ContactVM>>(reader.ReadToEnd()) ??
                    new ObservableCollection<ContactVM>();
                return contact;
            }
        }
    }
}