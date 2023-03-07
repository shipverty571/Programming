using Newtonsoft.Json;
using System;
using System.IO;

namespace Contacts.Model.Services
{
    public static class ContactSerializer
    {
        public static string Path { get; } = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Contacts";

        public static void Serialize(Contact contact)
        {
            using (StreamWriter writer = new StreamWriter(Path + @"\contacts.json"))
            {
                //JsonSerializerSettings settings = new JsonSerializerSettings();
                //settings.TypeNameHandling = TypeNameHandling.All;
                writer.Write(JsonConvert.SerializeObject(contact));
            }
        }

        public static Contact Deserialize()
        {
            var contact = new Contact();

            try
            {
                using (StreamReader reader = new StreamReader(Path + @"\contacts.json"))
                {
                    //JsonSerializerSettings settings = new JsonSerializerSettings();
                    //settings.TypeNameHandling = TypeNameHandling.All;
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
