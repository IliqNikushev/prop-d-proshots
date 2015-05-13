using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class DatabaseTest : UnitTest
    {
        [TestMethod]
        public void Connect()
        {
            Assert.IsTrue(Classes.Database.CanConnect);
        }

        [TestMethod]
        public void ConnectFailedNotExistingDatabase()
        {
        }

        [TestMethod]
        public void ConnectFailedWrongProvider()
        {
        }

        [TestMethod]
        public void GetSingleItem()
        {
        }
            //Assert that it is retrieved
            //Assert that it's value is correct

        [TestMethod]
        public void GetMultipleItems()
        {
        }

        [TestMethod]
        public void UpdateSingleItem()
        {
        }

        [TestMethod]
        public void UpdateMultipleItems()
        {
        }

        [TestMethod]
        public void HandleValidPayPalDocument()
        {
        }

        [TestMethod]
        public void HandleInvalidPayPalDocument()
        {
        }

        [TestMethod]
        public void HandlePayPalDocumentPowerFailure()
        {
        }

        [TestMethod]
        public void HandlePayPalDocumentConnectionFailure()
        {
        }
    }
}
