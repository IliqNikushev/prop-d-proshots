using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class AdminUserTest : UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(Record.NotToBeSentToDatabaseException))]
        public override void DatabaseCreate()
        {
            new AdminUser(1, null, null, null, null, null).Create();
        }

        private int workingAdminID = 7;
        private int workingShopID = 3;

        [TestMethod]
        public override void DatabaseGet()
        {
            AdminUser a = Database.Find<AdminUser>("|T|.id = {0}", this.workingAdminID);
            Assert.IsTrue(a != null, "admin not found");
            Assert.AreEqual(workingAdminID, a.ID);
            Assert.AreEqual("TAdmin",a.FirstName);
            Assert.AreEqual("TAdmin",a.LastName);
            Assert.AreEqual("password",a.Password);
            Assert.AreEqual("Admin",a.Username);
        }

        [TestMethod]
        public void AddEvent()
        {
            AdminUser a = Database.Find<AdminUser>("|T|.id = {0}", this.workingAdminID);
            Assert.IsTrue(a != null, "Admin not found");

            long previous = Database.Count<EventLandmark>();
            EventLandmark e = a.AddEvent("test", "test", 0, 0, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.IsTrue(e != null, "Event not found");
            long current = Database.Count<EventLandmark>();
            Assert.AreEqual(previous + 1, current);
            Assert.AreEqual("test", e.Description);
            Assert.AreEqual("test", e.Label);

            Database.Delete(e, "|T|.location = {0}", e.ID);
            Database.Delete<TentPitch>("|T|.id = {0}", e.ID);
            current = Database.Count<EventLandmark>();
            Assert.AreEqual(previous, current);

            LogMessage result = Database.Where<LogMessage>("|T|.name = {0}", "create event").LastOrDefault();
            Assert.IsTrue(result != null, "message not found");
            Assert.AreEqual("test 0 0 success " + workingAdminID + " => " + e.ID, result.Description);

            Database.Delete(result, "|T|.id = {0}", result.ID);

            Assert.AreEqual(null, Database.Find<LogMessage>("|T|.id = {0}", result.ID));
        }
    }
}
