using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    public class PointsDiscount : IDiscount
    {
        private int _points;

        public PointsDiscount()
        {

        }

        public int Points
        {
            get => _points;
            private set
            {
                ValueValidator.AssertOnPositiveValue(nameof(Points), value);
                _points = value;
            }
        }

        public string Info
        {
            get
            {
                return $"Накопительная - {Points} баллов";
            }
        }

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

        public double Apply(List<Item> items)
        {
            double discount = Calculate(items);
            _points -= (int) discount;
            return discount;
        }

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
