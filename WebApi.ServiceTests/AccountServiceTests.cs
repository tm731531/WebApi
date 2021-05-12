using WebApi.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Service.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {

        AccountService service = new AccountService();
        [TestMethod()]


        [TestCategory("CreateAccount")]
        [DataRow("test@gmail.com","00000000","password")]
        public void CreateAccountPassTest(string email, string phone,string password)
        {
            // arrange
            // 可以用BO
            // act
            var result = service.CreateAccount(email, phone, password);

            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod()]

        [TestCategory("CreateAccount")]
        [DataRow("false", "00000000", "password")]

        public void CreateAccountNotPassTest(string email, string phone, string password)
        {
            // arrange
            // act
            var result = service.CreateAccount(email, phone, password);

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        [DataRow("test@gmail.com")]
        public void CheckEmailPassTest(string email)
        {
            var result = service.CheckEmail(email);

            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        [DataRow("test123456789123456789@gmail.com")]
        public void CheckEmailNotPassTest(string email)
        {

            var result = service.CheckEmail(email);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        [DataRow("0000000000")]
        public void CheckPhonePassTest(string phone)
        {
            var result = service.CheckPhone(phone);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        [DataRow("1000000000")]
        public void CheckPhoneNotPassTest(string phone)
        {
            var result = service.CheckPhone(phone);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        [DataRow("password")]
        public void CheckPasswordPassTest(string password)
        {

            var result = service.CheckPassword(password);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        [DataRow("password1")]
        public void CheckPasswordNotPassTest(string password)
        {
            var result = service.CheckPassword(password);
            Assert.AreEqual(false, result);
        }
    }
}