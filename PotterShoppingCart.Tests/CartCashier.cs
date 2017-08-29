using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    public class CartCashier
    {
        public int GetExpense(List<Book> books)
        {
            int maxAmount = books.Max(x => x.Amount);
            List<int> bookGroup = new List<int>();

            for (int i = 1; i <= maxAmount; i++)
            {
                int amount = books.Count(x => x.Amount >= i);
                bookGroup.Add(amount);
            }

            int total = 0;
            foreach (var count in bookGroup)
            {
                var cost = count * 100;

                if (count == 2)
                    cost = Convert.ToInt32(cost * 0.95);

                if (count == 3)
                    cost = Convert.ToInt32(cost * 0.90);

                total += cost;
            }

            return total;
        }
    }
}