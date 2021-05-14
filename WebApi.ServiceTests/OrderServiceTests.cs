using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Service.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        [DataRow(50, 25)]
        public void CheckTotalPriceMustMoreThanDiscountPassTest(int totalPrice, int discount)
        {
            OrderService service = new OrderService();

            var result = service.CheckTotalPriceMustMoreThanDiscount(totalPrice, discount);

            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        [DataRow(50, 51)]
        public void CheckTotalPriceMustMoreThanDiscountNotPassTest(int totalPrice,int discount)
        {
            OrderService service = new OrderService();

            var result = service.CheckTotalPriceMustMoreThanDiscount(totalPrice,discount);

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        [DataRow(50, 50)]
        public void CheckTotalPriceEqualEachItemsTotalPassTest(int totalPrice, int sunm)
        {
            OrderService service = new OrderService();

            var result = service.CheckTotalPriceEqualEachItemsTotal(totalPrice, sunm);

            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        [DataRow(50,25)]
        public void CheckTotalPriceEqualEachItemsTotalNotPassTest(int totalPrice, int sunm)
        {
            OrderService service = new OrderService();

            var result = service.CheckTotalPriceEqualEachItemsTotal(totalPrice, sunm);

            Assert.AreEqual(false, result);
        }
    }
}