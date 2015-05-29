using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class RecordTest : UnitTest
    {
        public override void OnInitialize()
        {
            Database.buildTesting = true;
        }

        public override void OnCleanup()
        {
            Database.buildTesting = false;
        }

        [TestMethod]
        public abstract void DatabaseSave();

        [TestMethod]
        public abstract void DatabaseCreate();

        [TestMethod]
        public abstract void DatabaseGet();

        [TestMethod]
        public abstract void DatabaseUpdate();
    }
}
