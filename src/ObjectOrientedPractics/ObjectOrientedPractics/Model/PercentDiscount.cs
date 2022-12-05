using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class PercentDiscount : IDiscount
    {
        private int _percent;

        private Category _category;

        public PercentDiscount(Category category)
        {
            Category = category;
        }

        public string Info
        {
            get
            {
                return $"Процентная «{_category}» - {_percent}%";
            }
        }

        public Category Category
        {
            get => _category;
            set => _category = value;
        }

        public double PurchaseAmount { get; set; }

        public int CurrentPercentDiscount { get; set; } = 1;

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

        public double Apply(List<Item> items)
        {
            return Calculate(items);
        }

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
            int newDiscountPercent = (int)(PurchaseAmount / 1000);
            if (newDiscountPercent <= 10)
            {
                CurrentPercentDiscount = newDiscountPercent;
            }
        }
    }
}
