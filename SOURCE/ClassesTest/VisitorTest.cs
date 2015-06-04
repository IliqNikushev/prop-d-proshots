using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class VisitorTest : UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(Record.NotToBeSentToDatabaseException))]
        public override void DatabaseCreate()
        {
            new Visitor(0, null, null, null, null, null, null, 0, null, false).Create();
        }

        [TestMethod]
        public override void DatabaseGet()
        {
            Visitor v = Database.Find<Visitor>("{0}.username = {1}", Database.TableName<User>(), "tester");

            Assert.IsTrue(v != null);
        }
    }
}
