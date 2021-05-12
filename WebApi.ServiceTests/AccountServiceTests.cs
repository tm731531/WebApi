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


        [TestCategory("CreateAccount")]

        public void CreateAccountPassTest()
        {
            // arrange
            var data = new CreateAccountDto()
            { password = "test", email = "test@gmail", phone = "0000000000" };

            // act
            var service = new AccountService();

            // assert
            Assert.AreEqual(true, service.CreateAccount(data));
        }

        [TestMethod()]

        [TestCategory("CreateAccount")]

        public void CreateAccountNotPassTest()
        {
            // arrange
            var data = new CreateAccountDto()
            { password = "test", email = "test@gmail", phone = "9000000000" };

            // act
            var service = new AccountService();

            // assert
            Assert.AreEqual(false, service.CreateAccount(data));
        }
    }
}