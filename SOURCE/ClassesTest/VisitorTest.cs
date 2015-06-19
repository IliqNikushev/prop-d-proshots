using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class VisitorTest : UserTest
    {
        Visitor Tester { get { return Database.Find<Visitor>("{0}.username = {1}", Database.TableFor<User>(), "tester"); } }
        [TestMethod]
        [ExpectedException(typeof(Record.NotToBeSentToDatabaseException))]
        public override void DatabaseCreate()
        {
            new Visitor(0, null, null, null, null, null, null, 0, null, false,false).Create();
        }

        [TestMethod]
        public override void DatabaseGet()
        {
            Visitor v = Tester;

            Assert.IsTrue(Tester != null);
        }

        public void TopUps() { Assert.AreEqual(1, Database.GetVisitorTopUps(Tester).Count); }
        public void RentedItems() { Assert.AreEqual(1,Database.GetVisitorRentedItems(Tester).Count); }
        public void PurchasedItems() { Assert.AreEqual(1, Database.GetVisitorPurchases(Tester).Count); }
        public void Receipts() { Assert.AreEqual(1, Database.GetVisitorReceipts(Tester).Count); }
        public void BookedTents() { Assert.AreEqual(1, Database.GetTentsBookedByVisitor(Tester).Count); }
        public void BookedInTents() { Assert.AreEqual(1, Database.GetTentsBookedForVisitor(Tester).Count); }

        public void Book(TentPitch pitch)
        {

        }

        public void Rent(RentableItem item)
        {
        }


        public void Extend(RentableItemHistory Item, int days, int hours, int minutes, string reason = "")
        {
            //Item.ExtendPeriod(this, days, hours, minutes, reason);
        }

        public void Return(RentableItemHistory Item, string notes = "")
        {
            //Item.Return(this, notes);
        }

        public void CloseAccount()
        {
            //user no longer will be able to login
            //balance = 0
            //check if all items are returned
            throw new NotImplementedException();
        }

        public void ChangeBalanceTo(decimal amount)
        {
            //execute update
            throw new NotImplementedException();
        }
    }
}
