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
        ///  Гиперссылка запроса данных.
        /// </summary>
        private static readonly string _url =
            "https://api.randomdatatools.ru/?count=1&params=LastName,FirstName,Phone,Email";

        /// <summary>
        ///  Получает данные по API.
        /// </summary>
        /// <returns>Возвращает json строку.</returns>
        private static string GetInfoAPI()
        {
            var webClient = new WebClient();
            return webClient.DownloadString(_url);
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