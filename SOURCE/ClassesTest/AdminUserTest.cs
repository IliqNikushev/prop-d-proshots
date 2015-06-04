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
            current = Database.Count<EventLandmark>();
            Assert.AreEqual(previous, current);

            LogMessage result = Database.Where<LogMessage>("|T|.name = {0}", "create event").LastOrDefault();
            Assert.IsTrue(result != null, "message not found");
            Assert.AreEqual("test 0 0 success " + workingAdminID + " => " + e.ID, result.Description);

            Database.Delete(result, "|T|.id = {0}", result.ID);

            Assert.AreEqual(null, Database.Find<LogMessage>("|T|.id = {0}", result.ID));
        }

        [TestMethod]
        public void RestockStore()
        {
            AdminUser a = Database.Find<AdminUser>("|T|.id = {0}", this.workingAdminID);
            Assert.IsTrue(a != null, "admin not found");

            ShopWorkplace shop = Database.Find<ShopWorkplace>("|T|.id = {0}", this.workingShopID);
            Assert.IsTrue(shop != null, "shop not found");

            Assert.IsTrue(shop.Items.Count == 3);

            ShopItem item = shop.Items.First();
            Assert.IsTrue(item != null, "item not found");

            Assert.AreEqual(2, item.ID);
            long previous = shop.Items.First().InStock;
            Assert.AreEqual(8, previous);

            Restock r = new Restock().Create() as Restock;
            Assert.IsTrue(r != null, "restock not found");
            Assert.IsTrue(r.Items.Count == 0, "items of restock are not null");
            Assert.IsTrue(r.ID > 0, "restock not having and id");

            List<RestockItem> items = new List<RestockItem>();
            items.Add(new RestockItem(item, r, 4));

            a.RestockStore(shop, items);

            Assert.AreEqual(8+4, shop.Items.First().InStock);

            Database.Delete(items.First(), "|T|.restock_id = {0}", r.ID);

            Database.Delete(r, "|T|.id = {0}", r.ID);

            Assert.IsTrue(Database.Find<Restock>("|T|.id = {0}", r.ID) == null, "restock still exists");

            Assert.IsTrue(Database.Count<RestockItem>("|T|.restock_id = {0}", r.ID) == 0, "restock found");

            LogMessage result = Database.Where<LogMessage>("|T|.name = {0}", "restock store").LastOrDefault();
            
            Assert.IsTrue(result != null, "result not found");
            Assert.AreEqual("restock store", result.Name);
            Assert.AreEqual(shop.ID + " " + string.Join(" ", items.Select(x => x.Item.ID + " " + x.Times)), result.Description);

            Database.Delete(result, "|T|.id = {0}", result.ID);

            Assert.AreEqual(null, Database.Find<LogMessage>("|T|.id = {0}", result.ID));

            item = Database.Update(item, "quantity = 8", "|T|.item_id = " + item.ID) as ShopItem;

            Assert.AreEqual(8, item.InStock);

            item = shop.Items.First();

            Assert.AreEqual(8, item.InStock);
        }
    }
}
