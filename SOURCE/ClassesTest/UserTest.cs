using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{/*
    [TestClass]
    public class UserTest : UnitTest
    {
        public const string VALID_USER_ID = "123abc";
        public const string INVALID_USER_ID = "invalid";
        private Visitor user;

        //Use TestInitialize to run code before running each test 
        public override void OnInitialize()
        {
#warning DATABASE DOES NOT EXIST try catch
            try
            {
                user = new Visitor(VALID_USER_ID);
            }
            catch { }
        }

        [TestMethod]
        public void UserAuthenticate()
        {
            Assert.IsTrue(user.IsAuthenticated);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidUserException))]
        public void UserAuthenticateFailed()
        {
            Visitor user = new Visitor(INVALID_USER_ID);
        }

        [TestMethod]
        public void UserHireOneItem()
        {
        }

        [TestMethod]
        public void UserHireTwoItems()
        {
        }

        [TestMethod]
        public void UserHireAllItems()
        {
        }

        [TestMethod]
        public void UserHireMoreThanInStockItems()
        {
        }

        [TestMethod]
        public void UserHireNotEnoughCredits()
        {
        }
    }*/
}
