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
        private static Connection connection = new Connection("server=athena01.fhict.local;database=dbi317294;uid=dbi317294;password=NBD7TnUwhT");
        public static List<Visitor> GetVisitors
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<Employee> GetEmployees
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<Landmark> GetLandmarks
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<Job> GetJobs
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<ShopJob> GetShops
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<PurchasableItem> GetPurchasableItems
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<Appointment> GetAppointments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<Warning> GetWarning
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static List<TentAreaLandmark> GetFreeTentAreas
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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

        public static void ExecuteSQL(string sql)
        {
            Command c = new Command(sql, connection);

            c.ExecuteNonQuery();
        }

        public static Reader ExecuteSQLWithResult(string sql)
        {
            sql = "SELECT * FROM USER";
            Command c = new Command(sql, connection);
            connection.Open();
            var r = c.ExecuteReader();
            connection.Close();
            return r;
        }

        public static List<Tent> GetVisitorTent(Visitor visitor)
        {
            return GetWhere<Tent>(
                "Tents Join TentPeople on Tents.id = TentPeople.tent_id",
                "Tents.bookedBy = " + visitor.Id + " or TentPeople.visitor_id = " + visitor.Id);
        }

        public static List<RentableItem> GetVisitorRentedItems(Visitor visitor)
        {
            throw new System.NotImplementedException();
        }

        public static List<RentableItem> GetVisitorPurchases(Visitor visitor)
        {
            throw new System.NotImplementedException();
        }

        public static List<RentableItem> GetVisitorAppointments(Visitor visitor)
        {
            throw new System.NotImplementedException();
        }

        public static void GetEmployeeJob(Employee employee)
        {
            throw new System.NotImplementedException();
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

            return GetWhere(typeof(User),tableName, "Users.id = '" + id + "')").FirstOrDefault() as User;
        }

        private static string GetTableForUser()
        {
            string tableName = "Users";
            tableName += " Join Visitors on Users.id = Visitors.user_id";
            tableName += " Employees on Users.id = Employees.user_id";
            tableName += " Administrators on Users.id = Administrators.user_id";
            return tableName;
        }

        public static List<RentableItem> GetVisitorNotReturnedItems()
        {
            throw new System.NotImplementedException();
        }

        public static void GetJob()
        {
            throw new System.NotImplementedException();
        }

        public static List<RentableItem> GetVisitorTopUps()
        {
            throw new System.NotImplementedException();
        }
    }
}
