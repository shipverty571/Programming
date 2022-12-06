using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model.Discounts
{
    /// <summary>
    /// Представляет реализацию по представлению накопительной скидки.
    /// </summary>
    public class PointsDiscount : IDiscount
    {
        /// <summary>
        /// Накопительная скидка.
        /// </summary>
        private int _points;

        /// <summary>
        /// Создает экземпляр класса <see cref="PointsDiscount"/>
        /// </summary>
        public PointsDiscount()
        {

        }

        /// <summary>
        /// Возвращает и задает накопительную скидку. Должно быть не меньше нуля.
        /// </summary>
        public int Points
        {
            get => _points;
            set
            {
                ValueValidator.AssertOnPositiveValue(nameof(Points), value);
                _points = value;
            }
        }

        /// <summary>
        /// Возвращает информацию по накопительной скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Накопительная - {Points} баллов";
            }
        }

        /// <summary>
        /// Высчитывает скидку для товаров.
        /// </summary>
        /// <param name="items">Товары.</param>
        /// <returns>Возвращает общую стоимость товаров с учетом скидки.</returns>
        public double Calculate(List<Item> items)
        {
            double amount = 0;
            foreach (var item in items)
            {
                amount += item.Cost;
            }
            if (_points <= (int) (amount * 0.3))
            {
                return _points;
            }
            if (_points > (int)(amount * 0.3))
            {
                return Math.Ceiling(amount * 0.3);
            }

            return 0;
        }

        /// <summary>
        /// Применяет скидку к товарам.
        /// </summary>
        /// <param name="items">Товары.</param>
        /// <returns>Возвращает скидку.</returns>
        public double Apply(List<Item> items)
        {
            double discount = Calculate(items);
            _points -= (int) discount;
            return discount;
        }

        /// <summary>
        /// Накапливает скидку.
        /// </summary>
        /// <param name="items">Товары.</param>
        public void Update(List<Item> items)
        {
            double amount = 0;
            foreach (var item in items)
            {
                amount += item.Cost;
            }

            _points += (int)Math.Ceiling(amount * 0.1);
        }
    }
}
