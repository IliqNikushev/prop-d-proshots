using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    using Reader = MySql.Data.MySqlClient.MySqlDataReader;
    using Connection = MySql.Data.MySqlClient.MySqlConnection;
    using Command = MySql.Data.MySqlClient.MySqlCommand;
    public static class Database
    {
        const string C_Server = "athena01.fhict.local";
        const string C_DataBase = "dbi317294";
        const string C_UserID = "dbi317294";
        const string C_Password = "NBD7TnUwhT";
        static string connectionString = string.Format(
                    "server={0};database={1};uid={2};password={3}",
                    C_Server, C_DataBase, C_UserID, C_Password
                );

        public static bool CanConnect
        {
            get
            {
                using (Connection c = new Connection(connectionString))
                {
                    try
                    {
                        c.Open();
                        c.Close();
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static void ExecuteSQL(string sql)
        {
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    c.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (!CanConnect)
                        throw new UnableToConnectException();
                    throw new InvalidSQLException(ex.Message + "\n" + sql, ex);
                }
            }
        }

        public static Reader ExecuteSQLWithResult(string sql)
        {
            Reader r = null;
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    r = c.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (!CanConnect)
                        throw new UnableToConnectException();
                    throw new InvalidSQLException(ex.Message + "\n" + sql, ex);
                }
            }
            return r;
        }

        public static List<Visitor> Visitors
        {
            get
            {
                return GetAll<Visitor>("Visitors Join Users on Visitors.user_id = Users.id");
            }
        }

        public static List<Employee> Employees
        {
            get
            {
                return GetAll<Employee>("Employees Join Users on Employees.user_id = Users.id");
            }
        }

        public static List<Landmark> Landmarks
        {
            get
            {
                return GetAll<Landmark>("Landmarks l Join LandmarkType t on l.TYPE = t.ID");
            }
        }

        public static List<Job> Jobs
        {
            get
            {
                return GetAll<Job>("Jobs");
            }
        }

        public static List<ShopJob> Shops
        {
            get
            {
                return GetWhere<ShopJob>("Landmarks", "Landmarks.type ='shop'");
            }
        }

        public static List<PurchasableItem> PurchasableItems
        {
            get
            {
                return GetAll<PurchasableItem>("PurchasableItems");
            }
        }

        public static List<Appointment> Appointments
        {
            get
            {
                return GetAll<Appointment>("Appointments");
            }
        }

        public static List<Warning> Warning
        {
            get
            {
                return GetAll<Warning>("Warnings");
            }
        }

        public static List<TentAreaLandmark> FreeTentAreas
        {
            get
            {
                return GetWhere<TentAreaLandmark>("Landmarks l Join Tents t on l.id = t.landmark_id", "t.rented_by is null");
            }
        }

        public static List<Tent> GetVisitorTent(Visitor visitor)
        {
            return GetWhere<Tent>(
                "Tents Join TentPeople on Tents.id = TentPeople.tent_id",
                "Tents.bookedBy = " + visitor.Id + " or TentPeople.visitor_id = " + visitor.Id);
        }

        public static List<RentableItemHistory> GetVisitorRentedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>(
                 "RentableItemHistories h Join RentableItems r on h.item_id = r.id",
                 "h.rented_by = " + visitor.Id);
        }

        public static List<RentableItemHistory> GetVisitorNotReturnedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>(
                 "RentableItemHistories h Join RentableItems r on h.item_id = r.id",
                 "h.rented_by = " + visitor.Id + " and r.returned_by is NULL");
        }

        public static List<Receipt> GetVisitorPurchases(Visitor visitor)
        {
            return GetWhere<Receipt>(
                 "Receipts r Join ReceiptItems i on r.id = i.receipt_id Join PurchasableItems p on i.item_id = p.id",
                 "r.purchased_by = " + visitor.Id);
        }

        public static List<Appointment> GetVisitorAppointments(Visitor visitor)
        {
            return GetWhere<Appointment>(
                 "Appointments a Join AppointmentTasks t on a.id = t.appointment_id",
                 "a.appointed_by = " + visitor.Id);
        }

        public static List<EmployeeAction> GetEmployeeActions(Employee employee)
        {
            return GetWhere<EmployeeAction>("EmployeeActions",
               "EmployeeActions.employee_id = '" + employee.Id);
        }

        public static Employee GetEmployee(string userName, string password)
        {
            return GetWhere<Employee>("Employees Join Users on Users.id = Employees.user_id",
               "Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static Visitor GetVisitor(string userName, string password)
        {
            return GetWhere<Visitor>("Visitors Join Users on Users.id = Visitors.user_id",
               "Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static AdminUser GetAdmin(string userName, string password)
        {
            return GetWhere<AdminUser>("AdminUsers Join Users on Users.id = AdminUsers.user_id",
                "Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static User GetUser(string username, string password)
        {
            string tableName = GetTableForUser();

            return GetWhere(typeof(User), tableName, "Users.password = '" + password + "' and Users.username = '" + username + "'").FirstOrDefault() as User;
        }

        public static User GetUser(string id)
        {
            string tableName = GetTableForUser();

            return GetWhere(typeof(User), tableName, "Users.id = '" + id + "')").FirstOrDefault() as User;
        }

        public static List<Deposit> GetVisitorTopUps(Visitor visitor)
        {
            return GetWhere<Deposit>("PayPalDeposits d", "d.visitor_id = " + visitor.Id);
        }

        private static List<T> GetAll<T>(string tableName) where T:class
        {
            return GetWhere<T>(tableName, "");
        }

        private static object GetRow(Type t, Reader reader)
        {
            object result = null;

            if (t == typeof(Visitor))
                result = CreateVisitor(reader);
            else if (t == typeof(AdminUser))
                result = CreateAdmin(reader);
            else if (t == typeof(User))
            {
                string type = reader.GetString("type");
                if (type == "visitor")
                    result = CreateVisitor(reader);
                else if (type == "admin")
                    result = CreateAdmin(reader);
                else throw new NotImplementedException();
            }
            else
                throw new System.NotImplementedException();

            return result;
        }

        private static Visitor CreateVisitor(Reader reader)
        {
            string id = reader.GetString(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            string userName = reader.GetString(3);
            string email = reader.GetString(4);
            decimal amount = reader.GetDecimal(5);

            return new Visitor(id, firstName, lastName, userName, email, amount);
        }

        private static AdminUser CreateAdmin(Reader reader)
        {
            string id = reader.GetString(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            string userName = reader.GetString(3);
            string email = reader.GetString(4);
            decimal amount = reader.GetDecimal(5);

            return new AdminUser(id, firstName, lastName, userName, email);
        }

        private static List<object> GetWhere(Type t, string tableName, string where)
        {
            Reader reader = ExecuteSQLWithResult("Select * From " + tableName + (where != "" ? " Where " + where : ""));

            List<object> result = new List<object>();
            using (reader)
            {
                if (!reader.HasRows)
                    return result;

                while (reader.Read())
                {
                    object row = GetRow(t, reader);
                    result.Add(row);
                }
            }
            return result;
        }

        private static List<T> GetWhere<T>(string tableName, string where) where T : class
        {
            return GetWhere(typeof(T), tableName, where).Select(x=>x as T).ToList();
        }

        private static string GetTableForUser()
        {
            string tableName = "Users";
            tableName += " Join Visitors on Users.id = Visitors.user_id";
            tableName += " Employees on Users.id = Employees.user_id";
            tableName += " Administrators on Users.id = Administrators.user_id";
            return tableName;
        }

        public class UnableToConnectException : Exception
        {
            public UnableToConnectException() { }
        }

        public class InvalidSQLException : Exception
        {
            public InvalidSQLException(string sql, Exception ex) : base(sql, ex) { }
        }
    }
}
