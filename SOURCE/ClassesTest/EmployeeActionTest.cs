using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class EmployeeActionTest : RecordTest
    {
        [TestMethod]
        public override void DatabaseGet()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void DatabaseCreate()
        {
            new UserAction(0, DateTime.MinValue, null, null).Create();
        }
    }
}
