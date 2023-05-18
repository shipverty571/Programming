using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace ViewModel.Services
{
    /// <summary>
    /// Представляет реализацию по сериализации данных.
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Проводит сериализацию данных.
        /// </summary>
        /// <param name="contacts">Коллекция контактов.</param>
        /// <param name="path">Путь сериализации.</param>
        public static void Serialize(ObservableCollection<ContactVM> contacts, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (var writer = new StreamWriter(path))
            {
                writer.Write(JsonConvert.SerializeObject(contacts));
            }
        }

        /// <summary>
        /// Проводит десериализацию данных.
        /// </summary>
        /// <param name="path">Путь десериализации.</param>
        /// <returns>Возвращает экземпляр коллекции <see cref="ObservableCollection&lt;ContactVM&gt;" />.</returns>
        public static ObservableCollection<ContactVM> Deserialize(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            if (!File.Exists(path)) return new ObservableCollection<ContactVM>();
            using (var reader = new StreamReader(path))
            {
                var contact =
                    JsonConvert.DeserializeObject<ObservableCollection<ContactVM>>(
                        reader.ReadToEnd()) ??
                    new ObservableCollection<ContactVM>();
                return contact;
            }
        }
    }
}