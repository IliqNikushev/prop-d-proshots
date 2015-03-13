using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class Database : UnitTest
    {
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
        public abstract void OnPowerFailure();

        [TestMethod]
        public abstract void OnConnectionFailure();

        [TestMethod]
        public abstract void Synchronize();
    }
}
