using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void CostCalcaulte_每本一百_如果只有買一本_應支付一百元()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=0},
                new Book{Name="哈利波特3", ISDN="00003", Amount=0},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = 100;
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CostCalcaulte_買了兩本不同的書_則會有九五折()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=1},
                new Book{Name="哈利波特3", ISDN="00003", Amount=0},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = Convert.ToInt32(200 * 0.95);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_買了兩本相同的書_則維持原價()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=2},
                new Book{Name="哈利波特2", ISDN="00002", Amount=0},
                new Book{Name="哈利波特3", ISDN="00003", Amount=0},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = 200;
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_買3本不同的書_則會有九折()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=1},
                new Book{Name="哈利波特3", ISDN="00003", Amount=1},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = Convert.ToInt32(100 * 3 * 0.9);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_如果是四本不同的書_打八折()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=1},
                new Book{Name="哈利波特3", ISDN="00003", Amount=1},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=1},
            };

            int expected = Convert.ToInt32(100 * 4 * 0.8);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_一次買整套5本_打75折()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=1},
                new Book{Name="哈利波特3", ISDN="00003", Amount=1},
                new Book{Name="哈利波特4", ISDN="00004", Amount=1},
                new Book{Name="哈利波特5", ISDN="00005", Amount=1},
            };

            int expected = Convert.ToInt32(100 * 5 * 0.75);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=1},
                new Book{Name="哈利波特3", ISDN="00003", Amount=2},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = Convert.ToInt32(100 * 3 * 0.9 + 100);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_第一集買了一本_第二三集各買了兩本_價格應460()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=1},
                new Book{Name="哈利波特2", ISDN="00002", Amount=2},
                new Book{Name="哈利波特3", ISDN="00003", Amount=2},
                new Book{Name="哈利波特4", ISDN="00004", Amount=0},
                new Book{Name="哈利波特5", ISDN="00005", Amount=0},
            };

            int expected = Convert.ToInt32(100 * 3 * 0.9 + 100 * 2 * 0.95);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_選便宜的算法_1到3集各買2本_4到5集各買一本_最便宜的價格為640()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=2},
                new Book{Name="哈利波特2", ISDN="00002", Amount=2},
                new Book{Name="哈利波特3", ISDN="00003", Amount=2},
                new Book{Name="哈利波特4", ISDN="00004", Amount=1},
                new Book{Name="哈利波特5", ISDN="00005", Amount=1},
            };

            int expected = Convert.ToInt32(100 * 4 * 0.8 + 100 * 4 * 0.80);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }
           
        [TestMethod]
        public void CostCalcaulte_選便宜的算法_1到4集各買2本_5集買一本_價格應為695()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=2},
                new Book{Name="哈利波特2", ISDN="00002", Amount=2},
                new Book{Name="哈利波特3", ISDN="00003", Amount=2},
                new Book{Name="哈利波特4", ISDN="00004", Amount=2},
                new Book{Name="哈利波特5", ISDN="00005", Amount=1},
            };

            int expected = Convert.ToInt32(100 * 5 * 0.75 + 100 * 4 * 0.80);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CostCalcaulte_選便宜的算法_當1到3集各買4本_45集買一本_最便宜的價格應為1280()
        {
            //  arrange
            var books = new List<Book>()
            {
                new Book{Name="哈利波特1", ISDN="00001", Amount=4},
                new Book{Name="哈利波特2", ISDN="00002", Amount=4},
                new Book{Name="哈利波特3", ISDN="00003", Amount=4},
                new Book{Name="哈利波特4", ISDN="00004", Amount=2},
                new Book{Name="哈利波特5", ISDN="00005", Amount=2},
            };

            int expected = Convert.ToInt32(1280);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }
    }
}
