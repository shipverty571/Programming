using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    public static class CustomerFactory
    {
        /// <summary>
        /// Хранит путь до AppData.
        /// </summary>
        private static string AppDataPath = Application.UserAppDataPath;

        /// <summary>
        /// Случайные значения.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Данные для генерации.
        /// </summary>
        private static dynamic _randomData = RandomDataJson();

        /// <summary>
        /// Считывает данные с файла.
        /// </summary>
        /// <returns>Возвращает объект с данными.</returns>
        private static dynamic RandomDataJson()
        {
            dynamic randomData;

            using (StreamReader reader = new StreamReader(AppDataPath + @"\RandomCustomerSerialize.json"))
            {
                randomData = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }

            return randomData;
        }

        /// <summary>
        /// Генерирует случайное имя из данных.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="key">Часть полного имени.</param>
        /// <param name="gender">Половая принадлежность.</param>
        /// <returns>Возвращает часть имени.</returns>
        private static string BuildingRandomFullName(dynamic data, string key, string gender)
        {
            string name;

            while (true)
            {
                int index = _random.Next(0, 100);
                var item = data[index];
                string itemGender = item["Gender"];

                if (itemGender != gender) continue;

                name = item[key];
                break;
            }

            return name;
        }

        /// <summary>
        /// Создает покупателя.
        /// </summary>
        /// <returns>Возвращает объект Customer.</returns>
        public static Customer Randomize()
        {
            string gender = _random.Next(0, 2) == 1 ? "Мужчина" : "Женщина";
            string fullName = "";
            var addressJson = _randomData[_random.Next(0, 100)].Address.ToString();
            Console.WriteLine(addressJson);
            Address address = JsonConvert.DeserializeObject<Address>(addressJson); ;

            fullName += BuildingRandomFullName(_randomData, "LastName", gender) + " ";
            fullName += BuildingRandomFullName(_randomData, "FirstName", gender) + " ";
            fullName += BuildingRandomFullName(_randomData, "FatherName", gender) + " ";

            Customer customer = new Customer();
            customer.Fullname = fullName;
            customer.Address = address;
            customer.Cart = new Cart();

            return customer;
        }
    }
}
