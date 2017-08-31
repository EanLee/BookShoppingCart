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
            var combination = GetDiscountCombination(books.Select(book => book.Amount));

            var cheapest = combination.Select(combin => combin.Sum(count => _discountRule[count] * 100 * count)).Min();
            return Convert.ToInt32(cheapest);
        }

        private List<List<int>> GetDiscountCombination(IEnumerable<int> countCollection)
        {
            int maxCombinCount = countCollection.Max();

            var combinations = new List<List<int>>();

            for (int combinIndex = 0; combinIndex < maxCombinCount; combinIndex++)
            {
                List<int> bookGroup = new List<int>();

                var filler = countCollection.ToArray();

                for (int element = 0; element < maxCombinCount; element++)
                {
                    var maxCount = filler.Length - combinIndex + element;
                    int count = 0;

                    for (int i = 0; i < filler.Length; i++)
                    {
                        if (count == maxCount)
                            break;

                        if (filler[i] != 0)
                        {
                            count++;
                            filler[i]--;
                        }
                    }
                    bookGroup.Add(count);

                }
                combinations.Add(bookGroup);
            }

            return combinations;
        }
    }
}