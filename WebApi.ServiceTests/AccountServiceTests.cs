using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Model.Dto;

namespace WebApi.Service.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {
        [TestMethod()]

        [Owner("Taco")]

        [TestCategory("CreateAccount")]

        public void CreateAccountTest()
        {
            // arrange
            var data = new CreateAccountDto() { password="test", email="test@gmail", phone="0000000000" };

            // act
            var service = new AccountService();

            // assert
            Assert.AreEqual(true, service.CreateAccount(data));
        }
    }
}