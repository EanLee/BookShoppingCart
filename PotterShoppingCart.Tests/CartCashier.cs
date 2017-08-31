using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    public class CartCashier
    {
        private Dictionary<int, double> _discountRule;

        public CartCashier()
        {
            _discountRule = new Dictionary<int, double>
            {
                { 1, 1.00 },
                { 2, 0.95 },
                { 3, 0.90 },
                { 4, 0.80 },
                { 5, 0.75 }
            };
        }

        public int GetExpense(List<Book> books)
        {
            int maxAmount = books.Max(x => x.Amount);
            List<int> bookGroup = new List<int>();

            for (int i = 1; i <= maxAmount; i++)
            {
                int amount = books.Count(x => x.Amount >= i);
                bookGroup.Add(amount);
            }

            double total = 0;
            foreach (var count in bookGroup)
            {
                var cost = _discountRule[count] * 100 * count;

                //if (count == 2)
                //    cost = Convert.ToInt32(cost * 0.95);

                //if (count == 3)
                //    cost = Convert.ToInt32(cost * 0.90);

                //if (count == 4)
                //    cost = Convert.ToInt32(cost * 0.80);

                //if (count == 5)
                //    cost = Convert.ToInt32(cost * 0.75);

                total += cost;
            }

            return Convert.ToInt32(total);
        }
    }
}