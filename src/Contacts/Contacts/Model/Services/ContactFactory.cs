using System.Net;
using Newtonsoft.Json;

namespace Contacts.Model.Services
{
    /// <summary>
    ///  Представляет реализацию по генерации экземпляра класса <see cref="Contact"/>.
    /// </summary>
    public static class ContactFactory
    {
        /// <summary>
        ///  Возвращает гиперссылку запроса данных.
        /// </summary>
        private static string Url { get;  } = 
            "https://api.randomdatatools.ru/?count=1&params=LastName,FirstName,Phone,Email";

        /// <summary>
        ///  Возвращает экземпляр <see cref="System.Net.WebClient"/>.
        /// </summary>
        private static WebClient WebClient { get; } = new WebClient();

        /// <summary>
        ///  Получает данные по API.
        /// </summary>
        /// <returns>Возвращает json строку.</returns>
        private static string GetInfoAPI()
        {
            return WebClient.DownloadString(Url);
        }

        /// <summary>
        ///  Генерирует экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <returns>Возвращает сгенерированный контакт.</returns>
        public static Contact Randomize()
        {
            var response = GetInfoAPI();
            var data = JsonConvert.DeserializeObject<DataAPI>(response);
            var contact = new Contact(
                $"{data.LastName} {data.FirstName}",
                data.Email,
                data.Phone);
            return contact;
        }
    }
}