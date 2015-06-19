using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    [TestClass]
    public class DatabaseTest : UnitTest
    {
        private Visitor tester;
        public override void OnInitialize()
        {
            base.OnInitialize();
            tester = Visitor.Authenticate("tester", "test") as Visitor;
        }

        [TestMethod]
        public void Connect()
        {
            Assert.IsTrue(Classes.Database.CanConnect);
        }

        [TestMethod]
        public void GetUser()
        {
            User user = Database.Find<User>();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            List<User> result = Database.All<User>();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetAllUsersHasAdmins()
        {
            List<User> result = Database.All<User>();

            Assert.IsTrue(result.Where(x=>x is AdminUser).Any());
        }

        [TestMethod]
        public void GetAllUsersHasEmployees()
        {
            List<User> result = Database.All<User>();

            Assert.IsTrue(result.Where(x => x is Employee).Any());
        }

        [TestMethod]
        public void GetAllAdmins()
        {
            List<AdminUser> result = Database.All<AdminUser>();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            List<Employee> result = Database.All<Employee>();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void AllRecordsCanBeBuilt()
        {
            //Assert.IsFalse(Database.notBuildDefinedRecords.Any());
        }

        [TestMethod]
        public void AllRecordsHaveTable()
        {
            Assert.IsFalse(Database.notTableDefinedRecords.Any());
        }

        [TestMethod]
        public void MiscTableExists()
        {
            //Assert.AreEqual(5,Classes.Database.Misc.NumberOfCardsTotal);
        }

        [TestMethod]
        public void GetFreeTentPitches()
        {
            //Assert.IsTrue(Classes.Database.FreeTentPitches.Count > 0);
        }

        [TestMethod]
        public void GetTentByLandmark()
        {
            //TentPitch tentPitch = Database.Find<TentPitch>("|T|.id = 3");
            //Assert.IsTrue(tentPitch != null);
            //Assert.IsTrue(Classes.Database.GetTent(tentPitch) != null);
        }

        [TestMethod]
        public void GetVisitorRentedItems()
        {
        }

        [TestMethod]
        public void GetVisitorNotReturnedItems()
        {
        }

        [TestMethod]
        public void GetVisitorNotReturnedItemsThatAreOverdue()
        {
        }

        [TestMethod]
        public void GetVisitorPurchases()
        {
        }

        [TestMethod]
        public void GetVisitorAppointments()
        {
        }

        [TestMethod]
        public void GetEmployeeActions()
        {
        }

        [TestMethod]
        public void GetEmployee()
        {
        }

        [TestMethod]
        public void GetVisitorByID()
        {
        }

        [TestMethod]
        public void GetVisitorByCredentials()
        {
        }

        [TestMethod]
        public void GetAdmin()
        {
        }

        [TestMethod]
        public void GetVisitorTopUps()
        {
        }

        [TestMethod]
        public void GetTentsByVisitor()
        {
           // Assert.AreEqual(2, Classes.Database.GetTentsBookedByVisitor(tester).Count);
        }

        [TestMethod]
        public void GetTentsForVisitor()
        {
           // Assert.AreEqual(2, Classes.Database.GetTentsBookedForVisitor(tester).Count);
        }

        [TestMethod]
        public void AllRecordsBuildDefinitionHaveColumns()
        {
            Classes.Database.buildTesting = true;

            List<KeyValuePair<Type, Exception>> errors = new List<KeyValuePair<Type, Exception>>();
            Type database = typeof(Database);
            string methodName = new Func<List<Classes.Record>>(Classes.Database.All<Classes.Record>).Method.Name;
            System.Reflection.MethodInfo all = database.GetMethod(methodName);
            Assert.IsTrue(all != null);
            Database.buildTesting = true;
            foreach (var type in Classes.Database.Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record))))
                try
                {
                    all.MakeGenericMethod(type).Invoke(null, new object[] { });
                }
                catch (Exception ex) { errors.Add(new KeyValuePair<Type, Exception>(type, ex.InnerException)); }
            
            foreach (var item in Database.BuildTestingResults)
            {
                if (errors.Where(x => x.Key == item.Key).Any()) continue;

                string receivedNotProcessed = string.Join(", ", item.Value.Found.Keys.Where(x => !item.Value.Search.Contains(x)));
                string notRequested = string.Join(", ", item.Value.Search.Where(x => !item.Value.Found.ContainsKey(x)));

                Assert.IsTrue(item.Value.Found.Keys.Count == item.Value.Search.Count, "[{0}]\nMissmatch in search / find\nRECEIVED NOT PROCESSED:\n{1}\nNOT REQUESTED:\n{2}\n{3}/{4}", item.Key, receivedNotProcessed, notRequested, item.Value.Found.Keys.Count, item.Value.Search.Count);
                Assert.IsFalse(item.Value.Found.Where(x => x.Value.Key != x.Value.Value).Any(), "[{0}]\nMissmatch in types\n{1}",item.Key, string.Join("\n", item.Value.Found.Select(x=>x.Key + " => Expected:" + x.Value.Key + " GOT:" + x.Value.Value)));
            }

            Assert.IsTrue(0 == errors.
                Where(x=>!(x.Key == typeof(RestockableItem) && x.Value.Message.StartsWith("ABSTRACT TYPE REQUESTED"))).
                Where(x => !(x.Key == typeof(Workplace) && x.Value.Message == ("Unknown job type "))).
                Where(x => !(x.Key == typeof(Landmark) && x.Value.Message == ("Unknown landmark type "))).
                Where(x => !(x.Key == typeof(UserAction) && x.Value.Message == ("Unknown job type "))).
                Where(x => !(x.Key == typeof(Employee) && x.Value.Message == ("Unknown job type "))).
                Where(x => !(x.Key == typeof(User) && x.Value.Message == ("Unknown job type "))).
                Count(),
                "\n"+errors.Count + " Errors during testing : \n" + string.Join("\n",errors.Select(x=>x.Key.Name + "\n" + x.Value.GetType().Name + "\n" + x.Value.Message + "\n"+x.Value.StackTrace)));
        }
    }
}
