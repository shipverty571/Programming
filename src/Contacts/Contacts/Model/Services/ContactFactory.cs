using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Contacts.Model.Services
{
    public static class ContactFactory
    {
        private static readonly string _url = 
            "https://api.randomdatatools.ru/?count=1&params=LastName,FirstName,Phone,Email";

        private static string GetInfoAPI()
        {
            string response = "";
            WebClient webClient = new WebClient();
            response = webClient.DownloadString(_url);
            return response;
        }

        public static Contact Randomize()
        {
            string response = GetInfoAPI();
            var data = JsonConvert.DeserializeObject<DataAPI>(response);
            var contact = new Contact(
                $"{data.LastName} {data.FirstName}",
                data.Email,
                data.Phone);
            return contact;
        }
    }
}