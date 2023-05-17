using System.Net;
using Newtonsoft.Json;

namespace Model
{
    /// <summary>
    /// Представляет реализацию по генерации экземпляра класса <see cref="Contact" />.
    /// </summary>
    public static class ContactFactory
    {
        /// <summary>
        /// Возвращает гиперссылку запроса данных.
        /// </summary>
        private static string Url { get; } =
            "https://api.randomdatatools.ru/?count=1&params=LastName,FirstName,Phone,Email";

        /// <summary>
        /// Возвращает экземпляр <see cref="System.Net.WebClient" />.
        /// </summary>
        private static WebClient WebClient { get; } = new WebClient();

        /// <summary>
        /// Получает данные по Api.
        /// </summary>
        /// <returns>Возвращает json строку.</returns>
        private static string GetInfoApi()
        {
            try
            {
                return WebClient.DownloadString(Url);
            }
            catch (WebException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Генерирует экземпляр класса <see cref="Contact" />.
        /// </summary>
        /// <returns>Возвращает сгенерированный контакт.</returns>
        public static Contact Randomize()
        {
            var response = GetInfoApi();
            if (response == null)
                return null;
            var data = JsonConvert.DeserializeObject<ContactDto>(response);
            var contact = new Contact(
                $"{data.LastName} {data.FirstName}",
                data.Email,
                data.Phone);
            return contact;
        }
    }
}