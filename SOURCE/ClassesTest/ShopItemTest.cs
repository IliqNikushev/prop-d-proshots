using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class ShopItemTest : ItemTest
    {
        [TestMethod]
        [ExpectedException(typeof(Record.NotToBeSentToDatabaseException))]
        public override void DatabaseCreate()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void DatabaseGet()
        {
            throw new NotImplementedException();
        }
    }
}
