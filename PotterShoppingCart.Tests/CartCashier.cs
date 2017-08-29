using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    public class CartCashier
    {
        public int GetExpense(List<Book> books)
        {
            return books.Sum(x => x.Amount) * 100;
        }
    }
}