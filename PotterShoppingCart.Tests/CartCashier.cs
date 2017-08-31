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

            double total = bookGroup.Sum(count => _discountRule[count] * 100 * count);

            return Convert.ToInt32(total);
        }
    }
}