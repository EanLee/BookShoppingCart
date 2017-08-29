﻿using System;
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

            int expected = Convert.ToInt32(100 * 3 * 0.9);
            var cashier = new CartCashier();

            //  ack
            int actual = cashier.GetExpense(books);

            //  assert
            Assert.AreEqual(expected, actual);
        }
    }
}
