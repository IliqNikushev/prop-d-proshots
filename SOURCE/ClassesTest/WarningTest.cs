using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class WarningTest : RecordTest
    {
        [TestMethod]
        public override void DatabaseCreate()
        {
            Warning w = new Warning("test", "aTest").Create() as Warning;

            Assert.IsTrue(w != null);

            w.Delete("|T|.id = {0}", w.ID);

            w = new Warning("test", "aTest").Create() as Warning;

            Assert.IsTrue(w == null);
        }

        [TestMethod]
        public override void DatabaseGet()
        {
            Warning w = Database.Find<Warning>("|T|.id = 1");
            Assert.IsTrue(w != null);

            Assert.IsTrue(w.Name == "testing");
        }
    }
}
