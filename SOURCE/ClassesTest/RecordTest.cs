using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class RecordTest : UnitTest
    {
        [TestMethod]
        public abstract void DatabaseCreate();

        [TestMethod]
        public abstract void DatabaseGet();
    }
}
