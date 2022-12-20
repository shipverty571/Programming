using System;
using System.Collections.Generic;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товаре.
    /// </summary>
    public class Item : ICloneable, IEquatable<Item>, IComparable, IComparable<Item>
    {
        public event EventHandler<EventArgs> NameChanged;

        public event EventHandler<EventArgs> CostChanged;

        public event EventHandler<EventArgs> InfoChanged; 

        /// <summary>
        /// Уникальный идентификатор для всех объектов данного класса.
        /// </summary>
        private int _id;

        /// <summary>
        /// Название товара.
        /// </summary>
        private string _name;

        /// <summary>
        /// Описание товара.
        /// </summary>
        private string _info;

        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private double _cost;

        /// <summary>
        /// Все товары.
        /// </summary>
        private static int _allItemsCount;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>
        /// </summary>
        public Item()
        {
            _allItemsCount++;
            _id = _allItemsCount;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Item"/>
        /// </summary>
        /// <param name="name">Название товара. Должно быть не более 200 символов.</param>
        /// <param name="info">Описание товара. Должно быть не более 1000 символов.</param>
        /// <param name="cost">Стоимость товара. Должна быть в пределах от 0 до 100000.</param>
        /// <param name="category">Категория товара.</param>
        public Item(string name, string info, double cost, Category category)
        {
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
            _allItemsCount++;
            _id = _allItemsCount;
        }

        /// <summary>
        /// Возвращает и задает категорию товара.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает уникальный идентификатор песни.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт название товара. Должно быть не более 200 символов.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Name), value, 200);
                if (_name != value)
                {
                    _name = value;
                    NameChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт описание товара. Должно быть не более 1000 символов.
        /// </summary>
        public string Info
        {
            get => _info;
            set
            {
                ValueValidator.AssertStringOnLength(nameof(Info), value, 1000);
                if (_info != value)
                {
                    _info = value;
                    InfoChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задает стоимость товара. Должно быть в пределах от 0 до 100000.
        /// </summary>
        public double Cost
        {
            get => _cost;
            set
            {
                ValueValidator.AssertValueInRange(nameof(Cost), value, 0, 100000);
                if (_cost != value)
                {
                    _cost = value;
                    CostChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public object Clone()
        {
            Item newItem = new Item();
            newItem.Name = Name;
            newItem.Info = Info;
            newItem.Cost = Cost;
            newItem.Category = Category;
            newItem.Id = Id;
            return newItem;
        }

        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Info == other.Info &&
                   Cost == other.Cost &&
                   Category == other.Category &&
                   Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() &&
                   Equals((Item) obj);
        }

        public int CompareTo(Item obj)
        {
            if (ReferenceEquals(this, obj)) return 0;
            if (ReferenceEquals(null, obj)) return 1;
            else return _cost.CompareTo(obj._cost);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(this, obj)) return 0;
            if (ReferenceEquals(null, obj)) return 1;
            if (obj is Item other) return CompareTo((Item)obj);
            else throw new ArgumentException($"Object must be of type {nameof(Item)}");
        }

        public static bool operator ==(Item left, Item right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Item left, Item right)
        {
            return !Equals(left, right);
        }

        public static bool operator <(Item left, Item right)
        {
            return Comparer<Item>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Item left, Item right)
        {
            return Comparer<Item>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Item left, Item right)
        {
            return Comparer<Item>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Item left, Item right)
        {
            return Comparer<Item>.Default.Compare(left, right) >= 0;
        }
    }
}
