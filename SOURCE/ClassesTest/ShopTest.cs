using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class ShopTest : PowerDependantTest
    {
        public const string VALID_SHOP_ID = "3";
        public const string INVALID_SHOP_ID = "-1";
        private Shop shop;

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void Initialize() 
        {
#warning DATABASE DOES NOT EXIST try catch
            try
            {
                shop = new Shop(VALID_SHOP_ID, null, null, 0, 0);
            }
            catch { }
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void AuthenticateShop()
        {
            Assert.IsTrue(shop.ID == VALID_SHOP_ID);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidShopException))]
        public void AuthenticateShopFailed()
        {
            Shop shop = new Shop(INVALID_SHOP_ID, null, null, 0, 0);
        }

        [TestMethod]
        public void UserIsInvalid()
        {
            shop.Purchase(UserTest.INVALID_USER_ID, new List<PurchaseSelection>());
        }

        [TestMethod]
        public void UserPurchasesItem()
        {
        }

        [TestMethod]
        public void UserPurchasesTwoItems()
        {
        }

        [TestMethod]
        public void UserPurchasesAllItems()
        {
        }

        [TestMethod]
        public void UserPurchasesMoreThanInStockItems()
        {
        }

        [TestMethod]
        public void UserPurchasesOneItemInStockAndOneOutOfStockItem()
        {
        }

        [TestMethod]
        public void UserPurchasesMultipleInStockAndOutOfStockItems()
        {
        }

        [TestMethod]
        public void UserPurchasesWithNotEnoughCredits()
        {
        }

        [TestMethod]
        public override void OnPowerFailure()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void OnConnectionFailure()
        {
            throw new NotImplementedException();
        }
    }
}
