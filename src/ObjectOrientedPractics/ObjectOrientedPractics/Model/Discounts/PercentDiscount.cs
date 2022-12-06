using System.Collections.Generic;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Discounts
{
    /// <summary>
    /// Представляет реализацию по представлению процентной скидки.
    /// </summary>
    public class PercentDiscount : IDiscount
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="PercentDiscount"/>.
        /// </summary>
        /// <param name="category">Категория.</param>
        public PercentDiscount(Category category)
        {
            Category = category;
        }

        /// <summary>
        /// Возвращает информацию по скидке.
        /// </summary>
        public string Info
        {
            get
            {
                return $"Процентная «{Category}» - {CurrentPercentDiscount}%";
            }
        }
        
        /// <summary>
        /// Возвращает и задает категорию.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает и задает сумму по категории.
        /// </summary>
        public double PurchaseAmount { get; set; }

        /// <summary>
        /// Возвращает и задает процентную скидку.
        /// </summary>
        public int CurrentPercentDiscount { get; set; } = 1;

        /// <summary>
        /// Высчитывает скидку для товаров.
        /// </summary>
        /// <param name="items">Товары.</param>
        /// <returns>Возвращает сумму скидки.</returns>
        public double Calculate(List<Item> items)
        {
            double amount = 0;
            foreach (Item item in items)
            {
                if (item.Category == Category)
                {
                    amount += item.Cost;
                }
            }

            return amount * ((double) CurrentPercentDiscount / 100);
        }

        /// <summary>
        /// Применяет скидку к товарам.
        /// </summary>
        /// <param name="items">Товары.</param>
        /// <returns>Возвращает сумму со скидкой.</returns>
        public double Apply(List<Item> items)
        {
            return Calculate(items);
        }

        /// <summary>
        /// Высчитывает новый процент скидки.
        /// </summary>
        /// <param name="items">Товары.</param>
        public void Update(List<Item> items)
        {
            double amount = 0;
            foreach (Item item in items)
            {
                if (item.Category == Category)
                {
                    amount += item.Cost;
                }
            }
            PurchaseAmount += amount;
            int newDiscountPercent = (int)(PurchaseAmount / 1000);
            if (newDiscountPercent <= 10 && newDiscountPercent != 0)
            {
                CurrentPercentDiscount = newDiscountPercent;
            }
            else if (newDiscountPercent > 10)
            {
                CurrentPercentDiscount = 10;
            }
        }
    }
}
