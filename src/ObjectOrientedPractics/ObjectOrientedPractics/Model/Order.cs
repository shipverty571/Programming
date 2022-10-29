using System;
using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет реализацию по оформлению заказа.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор для всех объектов данного класса.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Количество заказов.
        /// </summary>
        private static int _allOrdersCount;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        private readonly string _dateOfCreate;

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Общая стоимость.
        /// </summary>
        private double _amount;

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>. 
        /// </summary>
        public Order()
        {
            _allOrdersCount++;
            _id = _allOrdersCount;
            _dateOfCreate = DateTime.Today.ToString();
        }

        /// <summary>
        /// Возвращает уникальный идентификатор заказа.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public string DateOfCreate
        {
            get
            {
                return _dateOfCreate;
            }
        }

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Возвращает и задает адрес доставки заказа.
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

        /// <summary>
        /// Возвращает и задает коллекцию товаров заказа.
        /// </summary>
        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Возвращает общую стоимость товаров.
        /// </summary>
        public double Amount
        {
            get
            {
                _amount = 0;

                if (_items == null) return _amount;

                foreach (var item in _items)
                {
                    _amount += item.Cost;
                }

                return _amount;
            }
        }
    }
}
