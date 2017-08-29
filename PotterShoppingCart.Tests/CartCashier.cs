using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    public class CartCashier
    {
        public int GetExpense(List<Book> books)
        {
            var groups = books.GroupBy(x => x.Amount).ToDictionary(grouping => grouping.Key, group => group.ToList());

            var cost = groups[1].Count * 100;

            if (groups[1].Count() == 2)
                cost = Convert.ToInt32(cost * 0.95);

            return cost;
        }
    }
}