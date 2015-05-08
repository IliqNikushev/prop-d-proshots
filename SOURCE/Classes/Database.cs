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
        public static Action<Exception, string> OnUnableToProcessSQL;

        const string C_Server = "athena01.fhict.local";
        const string C_DataBase = "dbi317294";
        const string C_UserID = "dbi317294";
        const string C_Password = "NBD7TnUwhT";
        static string connectionString = string.Format(
                    "server={0};database={1};uid={2};password={3}",
                    C_Server, C_DataBase, C_UserID, C_Password
                );

        static Dictionary<Type, string> tables = new Dictionary<Type, string>()
        {
            { typeof(EmployeeAction), "EmployeeActions"},
            { typeof(Appointment), "Appointments a Join AppointmentTasks t on a.id = t.appointment_id"},
            { typeof(Receipt), "Receipts r Join ReceiptItems i on r.id = i.receipt_id Join ShopItems s on i.item_id = s.item_id"},
            { typeof(RentableItemHistory), "RentableItemHistories h Join RentableItems r on h.item_id = r.item_id"},
            { typeof(Tent), "Tents t Join TentPeople p on t.location = p.tent_id"},
            { typeof(TentAreaLandmark), "Tents_All"},
            { typeof(Warning), "Warnings"},
            { typeof(PurchasableItem), "PurchasableItems"},
            { typeof(Landmark), "Landmarks"},
            { typeof(Job), "Jobs"},
            { typeof(Deposit), "PayPalDeposits"},
            { typeof(AppointmentTask), "AppointmentTasks"},
            { typeof(AppointedItem), "Items_Appointed"},
            { typeof(LogMessage), "Logs"},
            { typeof(RentableItem), "RentableItems"},
            { typeof(PayPalDocument), "PayPalDocuments"},
            { typeof(RestockSelection), "Restocks"},
            { typeof(Visitor), "Users u Join Visitors v on u.id = v.user_id"},
            { typeof(Employee), "Users u Join Employees e on u.id = e.user_id"},
            { typeof(AdminUser), "Users u where u.type = 'admin'"}
        };
        public static List<string> consistencyExceptions;
        public static void CheckConsistency()
        {
            consistencyExceptions = new List<string>();
            foreach (var table in tables)
            {
                try
                {
                    ExecuteSQL("Select * from " + table.Value, true);
                }
                catch (Exception ex)
                {
                    consistencyExceptions.Add(ex.GetType().Name.Replace("Exception",":")+ex.Message+"\n"+table.Value);
                }
            }
        }

        public static IEnumerable<Type> notTableDefinedRecords
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().
                    Where(x => x.IsSubclassOf(typeof(Record))).
                    Where(x => !tables.ContainsKey(x)).
                    Where(x => !x.IsSubclassOf(typeof(User)) && !x.IsAbstract).
                    Where(x => !x.IsSubclassOf(typeof(Job))).
                    Where(x => !x.IsSubclassOf(typeof(Landmark)));
            }
        }

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

        public static int ExecuteSQL(string sql, bool testing = false)
        {
            int rowsAffected = 0;
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    rowsAffected = c.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (OnUnableToProcessSQL != null)
                        OnUnableToProcessSQL(ex, sql);
                    if (testing)
                        throw;
                }
            }
            return rowsAffected;
        }

        public static void ExecuteSQLWithResult(string sql, Action<Reader> resultCallback, bool testing = false)
        {
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    Reader result = c.ExecuteReader();
                    if (resultCallback == null) throw new NotImplementedException("Do not know what to do with \n" + sql);
                    resultCallback(result);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if(OnUnableToProcessSQL != null)
                        OnUnableToProcessSQL(ex, sql);
                    if (testing)
                        throw;
                }
            }
        }

        public static List<Visitor> Visitors
        {
            get
            {
                return GetAll<Visitor>();
            }
        }

        public static List<Employee> Employees
        {
            get
            {
                return GetAll<Employee>();
            }
        }

        public static List<Landmark> Landmarks
        {
            get
            {
                return GetAll<Landmark>();
            }
        }

        public static List<Job> Jobs
        {
            get
            {
                return GetAll<Job>();
            }
        }

        public static List<ShopJob> Shops
        {
            get
            {
                return GetWhere<ShopJob>("Landmarks.type ='shop'");
            }
        }

        public static List<PurchasableItem> PurchasableItems
        {
            get
            {
                return GetAll<PurchasableItem>();
            }
        }

        public static List<Appointment> Appointments
        {
            get
            {
                return GetAll<Appointment>();
            }
        }

        public static List<Warning> Warning
        {
            get
            {
                return GetAll<Warning>();
            }
        }

        public static List<TentAreaLandmark> FreeTentAreas
        {
            get
            {
                return GetWhere<TentAreaLandmark>("t.rented_by is null");
            }
        }

        public static List<Tent> GetVisitorTent(Visitor visitor)
        {
            return GetWhere<Tent>("Tents.bookedBy = " + visitor.Id + " or TentPeople.visitor_id = " + visitor.Id);
        }

        public static List<RentableItemHistory> GetVisitorRentedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>("h.rented_by = " + visitor.Id);
        }

        public static List<RentableItemHistory> GetVisitorNotReturnedItems(Visitor visitor)
        {
            return GetWhere<RentableItemHistory>("h.rented_by = " + visitor.Id + " and r.returned_by is NULL");
        }

        public static List<Receipt> GetVisitorPurchases(Visitor visitor)
        {
            return GetWhere<Receipt>("r.purchased_by = " + visitor.Id);
        }

        public static List<Appointment> GetVisitorAppointments(Visitor visitor)
        {
            return GetWhere<Appointment>("a.appointed_by = " + visitor.Id);
        }

        public static List<EmployeeAction> GetEmployeeActions(Employee employee)
        {
            return GetWhere<EmployeeAction>("EmployeeActions.employee_id = '" + employee.Id);
        }

        public static Employee GetEmployee(string userName, string password)
        {
            return GetWhere<Employee>("Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static Visitor GetVisitor(string userName, string password)
        {
            return GetWhere<Visitor>("Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static AdminUser GetAdmin(string userName, string password)
        {
            return GetWhere<AdminUser>("Users.userName = '" + userName + "' and Users.password = '" + password + "'").FirstOrDefault();
        }

        public static User GetUser(string username, string password)
        {
            return GetWhere<User>("Users.password = '" + password + "' and Users.username = '" + username + "'").FirstOrDefault() as User;
        }

        public static User GetUser(string id)
        {
            return GetWhere<User>("Visitors.rfid = " + id + ")").FirstOrDefault() as User;
        }

        public static List<Deposit> GetVisitorTopUps(Visitor visitor)
        {
            return GetWhere<Deposit>("d.visitor_id = " + visitor.Id);
        }

        private static List<T> GetAll<T>() where T : Record
        {
            return GetWhere<T>("");
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

        static List<object> processingList;
        static Type processType = typeof(int);

        private static void ProcessReader(Reader reader)
        {
            Type t = processType;
            processingList = new List<object>();
            using (reader)
            {
                while (reader.Read())
                {
                    object row = GetRow(t, reader);
                    processingList.Add(row);
                }
            }
        }

        private static List<object> GetWhere(Type t, string where)
        {
            string tableName = GetTableFor(t);
            processType = t;
            ExecuteSQLWithResult("Select * From " + tableName + (where != "" ? " Where " + where : ""), ProcessReader);

            List<object> result = new List<object>(processingList);
            processingList.Clear();
            processingList = null;
            return result;
        }

        private static List<T> GetWhere<T>(string where) where T : Record
        {
            return GetWhere(typeof(T), where).Select(x=>x as T).ToList();
        }

        private static string GetTableFor(Type t)
        {
            if (tables.ContainsKey(t))
                return tables[t];
            throw new NotImplementedException("Table for " + t.Name + " not implemented");
        }
    }
}
