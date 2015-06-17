using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class TentTest : LandmarkTest
    {
        [TestMethod]
        public override void DatabaseCreate()
        {
            TentPitch p = Database.FreeTentPitches.LastOrDefault();
            Assert.IsTrue(p != null);
            Visitor v = Database.Find<Visitor>("{0}.username = {1}", Database.TableFor<User>(), "tester");
            Assert.IsTrue(v!=null);
            Tent tent = new Tent(p, DateTime.Today, false, DateTime.Today, v).Create() as Tent;

            Assert.IsTrue(tent != null);

            tent.Delete("|T|.location = ", tent.Location);
            Assert.IsTrue(Database.Find<Tent>("|T|.location = {0}", tent.Location.ID) == null);
        }

        [TestMethod]
        public override void DatabaseGet()
        {
            Assert.IsTrue(Database.FreeTentPitches.Any());
        }
    }
}
