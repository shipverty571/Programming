using System;
using System.Collections.Generic;
using ObjectOrientedPractics.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Services
{
    public static class DataTools
    {
        public static bool IsCategory(Item item, int category)
        {
            return item.Category == (Category)category;
        }

        public static bool MoreThanValue(Item item, int value)
        {
            return item.Cost > value;
        }

        public static List<Item> FindByPredicate(List<Item> items, Predicate<Item> predicate)
        {
            List<Item> list = new List<Item>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<Item> Sort(List<Item> items, Func<Item, Item, bool> compare)
        {
            List<Item> newItems = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {
                    if (compare(items[i], items[j]))
                    {
                        (items[i], items[j]) = (items[j], items[i]);
                    }
                }
            }
            return newItems;
        }
    }
}
