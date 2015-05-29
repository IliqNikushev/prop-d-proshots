using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public partial class Database
    {
        public class MiscTable
        {
            public long NumberOfCardsTotal;
            public long NumberOfCardsTaken;

            public MiscTable(long numberOfCardsTotal, long numberOfCardsTaken)
            {
                this.NumberOfCardsTotal = numberOfCardsTotal;
                this.NumberOfCardsTaken = numberOfCardsTaken;
            }
        }

        public static MiscTable Misc
        {
            get
            {
                MiscTable misc = null;
                ExecuteSQLWithResult("Select Total, Taken from Misc", (x) => { if (x.Read()) misc = new MiscTable(x.Get<long>("Total"), x.Get<long>("Taken")); else misc = new MiscTable(-1, -1); });
                return misc;
            }
        }

        public static List<Visitor> Visitors
        {
            get
            {
                return All<Visitor>();
            }
        }

        public static List<Employee> Employees
        {
            get
            {
                return All<Employee>();
            }
        }

        public static List<Landmark> Landmarks
        {
            get
            {
                return All<Landmark>();
            }
        }

        public static List<Job> Jobs
        {
            get
            {
                return All<Job>();
            }
        }

        public static List<ShopJob> Shops
        {
            get
            {
                return All<ShopJob>();
            }
        }

        public static List<ShopItem> ShopItems
        {
            get
            {
                return All<ShopItem>();
            }
        }

        public static List<Appointment> Appointments
        {
            get
            {
                return All<Appointment>();
            }
        }

        public static List<Warning> Warning
        {
            get
            {
                return All<Warning>();
            }
        }

        public static List<TentPitch> FreeTentPitches
        {
            get
            {
                return GetWhere<TentPitch>("|T|.id not in (select {0}.location from {0})", TName<Tent>());
            }
        }

        public static Tent GetTent(TentPitch pitch)
        {
            return Find<Tent>("|T|.location = {0}", pitch.ID);
        }

        public static List<Tent> GetTentsBookedByVisitor(Visitor visitor)
        {
            return GetWhere<Tent>("|T|.booked_by = {0}", visitor.ID);
        }

        public static List<Tent> GetTentsBookedForVisitor(Visitor visitor)
        {
            return GetWhere<TentPerson>("|T|.visitor_id = {0}", visitor.ID).Select(x => x.Tent).ToList();
        }

        public static List<RentableItemHistory> GetVisitorRentedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>("|T|.rented_by = ", visitor.ID);
        }

        public static List<RentableItemHistory> GetVisitorNotReturnedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>("|T|.rented_by = {0} and |T|.returned_by is NULL", visitor.ID);
        }

        public static List<RentableItemHistory> GetVisitorNotReturnedItemsOverdue(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>("|T|.rented_by = {0} and |T|.returned_by is NULL and NOW() > |T|.rentedTill", visitor.ID);
        }

        public static List<Receipt> GetVisitorReceipts(Visitor visitor)
        {
            return GetWhere<Receipt>("|T|.purchased_by = {0}", visitor.ID);
        }

        public static List<ReceiptItem> GetVisitorPurchases(Visitor visitor)
        {
            return GetWhere<ReceiptItem>("{1}.purchased_by = {0}", visitor.ID, TName<Receipt>());
        }

        public static List<Appointment> GetVisitorAppointments(Visitor visitor)
        {
            return GetWhere<Appointment>("|T|.appointed_by = {0}", visitor.ID);
        }

        public static List<EmployeeAction> GetEmployeeActions(Employee employee)
        {
            return GetWhere<EmployeeAction>("|T|.employee_id = {0}", employee.ID);
        }

        public static Employee GetEmployee(string userName, string password)
        {
            return Find<Employee>("{2}.userName = {0} and {2}.password = {1}", userName, password, TName<User>());
        }

        private static T GetUser<T>(string username, string password) where T : User
        {
            return Find<T>("{2}.password = {0} and {2}.username = {1}", password, username, TName<User>());
        }

        public static Visitor GetVisitor(string username, string password)
        {
            return GetUser<Visitor>(username, password);
        }

        public static AdminUser GetAdmin(string username, string password)
        {
            return GetUser<AdminUser>(username, password);
        }

        public static User GetUser(string username, string password)
        {
            return GetUser<User>(username, password);
        }

        public static Visitor GetVisitor(string id)
        {
            return Find<Visitor>("|T|.rfid = {0}", id);
        }

        public static List<Deposit> GetVisitorTopUps(Visitor visitor)
        {
            return GetWhere<Deposit>("|T|.visitor_id = {0}", visitor.ID);
        }
    }
}
