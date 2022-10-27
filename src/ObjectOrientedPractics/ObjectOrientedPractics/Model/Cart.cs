using System.Collections.Generic;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет реализацию корзины товаров.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Общая стоимость.
        /// </summary>
        private double _amount;

        /// <summary>
        /// Возвращает и задает коллекцию товаров.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Возвращает и задает общую стоимость товаров.
        /// </summary>
        public double Amount
        {
            get
            {
                if (_items == null) return _amount = 0;

                foreach (var item in _items)
                {
                    _amount += item.Cost;
                }

                return _amount;
            }
        }
    }
}