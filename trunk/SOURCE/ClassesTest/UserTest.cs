using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class UserTest
    {
        public const string VALID_USER_ID = "123abc";
        public const string INVALID_USER_ID = "invalid";
        private User user;

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
#warning DATABASE DOES NOT EXIST try catch
            try
            {
                user = new User(VALID_USER_ID);
            }
            catch { }
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

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
            User user = new User(INVALID_USER_ID);
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
    }
}
