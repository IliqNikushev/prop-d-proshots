using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class RFIDTest : UnitTest
    {
        [TestMethod]
        public void HasDrivers()
        {
            Assert.IsTrue(RFID.HasDrivers);
        }

        [TestMethod]
        public void IsAttached()
        {
            Assert.IsTrue(new RFID().IsAttached);
        }
    }
}
