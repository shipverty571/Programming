using System.Collections.Generic;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о покупателе.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Уникальный идентификатор для всех объектов данного класса.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Адрес покупателя.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Корзина
        /// </summary>
        private Cart _cart;

        /// <summary>
        /// Количество покупателей.
        /// </summary>
        private static int _allCustomersCount;


        /// <summary>
        /// Коллекция заказов.
        /// </summary>
        private List<Order> _orders;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            _allCustomersCount++;
            _id = _allCustomersCount;
            Cart = new Cart();
            Orders = new List<Order>();
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">Полное имя. Должно быть не более 200 символов.</param>
        /// <param name="address">Адрес. Должен быть не более 500 символов.</param>
        public Customer(string fullname, Address address, Cart cart, List<Order> orders)
        {
            Fullname = fullname;
            Address = address;
            Cart = cart;
            Orders = orders;
            _allCustomersCount++;
            _id = _allCustomersCount;
        }

        /// <summary>
        /// Возвращает и задает корзину товаров.
        /// </summary>
        public Cart Cart
        {
            get
            {
                return _cart;
            }
            set
            {
                _cart = value;
            }
        }

        /// <summary>
        /// Возвращает и задает коллекцию заказов.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }

        /// <summary>
        /// Возвращает уникальный идентификатор песни.
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Возвращает и задаёт полное имя покупателя. Должно быть не более 200 символов.
        /// </summary>
        public string Fullname
        {
            get => _fullname;
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Fullname), value, 200);
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт адрес покупателя. Должно быть не более 500 символов.
        /// </summary>
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
    }
}
