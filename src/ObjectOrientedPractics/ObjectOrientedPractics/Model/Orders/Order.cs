using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Orders
{
    /// <summary>
    /// Представляет реализацию по оформлению заказа.
    /// </summary>
    public class Order : IEquatable<Order>
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
        /// Создает экземпляр класса <see cref="Order"/>. 
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес.</param>
        /// <param name="items">Товары.</param>
        public Order(OrderStatus status, Address address, List<Item> items)
        {
            Status = status;
            Address = address;
            Items = items;
            _allOrdersCount++;
            _id = _allOrdersCount;
            _dateOfCreate = DateTime.Today.ToString();
        }

        /// <summary>
        /// Возвращает и задает скидку на товары.
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Возвращает итоговую стоимость заказа.
        /// </summary>
        public double Total
        {
            get
            {
                return Amount - DiscountAmount;
            }
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

        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Status == other.Status &&
                   Address == other.Address &&
                   Items == other.Items &&
                   Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() &&
                   Equals((Order)obj);
        }
    }
}
