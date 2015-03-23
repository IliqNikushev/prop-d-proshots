using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class Database : PowerDependantTest
    {
        //"Provider=MySQL Provider;server=localhost;User Id=MyID;password=MyPassword;database=MyDatabase;
        [TestMethod]
        public abstract void Connect();

        [TestMethod]
        public abstract void ConnectFailedNotExistingDatabase();

        [TestMethod]
        public abstract void ConnectFailedWrongProvider();

        [TestMethod]
        public abstract void GetSingleItem();
            //Assert that it is retrieved
            //Assert that it's value is correct

        [TestMethod]
        public abstract void GetMultipleItems();

        [TestMethod]
        public abstract void UpdateSingleItem();

        [TestMethod]
        public abstract void UpdateMultipleItems();

        [TestMethod]
        public abstract void Synchronize();

        [TestMethod]
        public abstract void OnSynchronizeWithConflict();

        [TestMethod]
        public abstract void HandleValidPayPalDocument();

        [TestMethod]
        public abstract void HandleInvalidPayPalDocument();

        [TestMethod]
        public abstract void HandlePayPalDocumentPowerFailure();

        [TestMethod]
        public abstract void HandlePayPalDocumentConnectionFailure();
    }
}
