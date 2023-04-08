using System.Net;
using Newtonsoft.Json;

namespace Contacts.Model.Services
{
    public static class ContactFactory
    {
        private static readonly string _url =
            "https://api.randomdatatools.ru/?count=1&params=LastName,FirstName,Phone,Email";

        private static string GetInfoAPI()
        {
            var webClient = new WebClient();
            return webClient.DownloadString(_url);
        }

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