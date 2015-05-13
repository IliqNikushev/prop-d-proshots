﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    using Reader = MySql.Data.MySqlClient.MySqlDataReader;
    using Connection = MySql.Data.MySqlClient.MySqlConnection;
    using Command = MySql.Data.MySqlClient.MySqlCommand;
    public static partial class Database
    {
        public static Action<Exception, string> OnUnableToProcessSQL;

        const string C_Server = "athena01.fhict.local";
        const string C_DataBase = "dbi317294";
        const string C_UserID = "dbi317294";
        const string C_Password = "NBD7TnUwhT";
        static string connectionString = string.Format(
                    "server={0};database={1};uid={2};password={3};connect timeout=30;",
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
            { typeof(AdminUser), "Users u where u.type = 'admin'"},
            { typeof(User), "Users"}
        };

        public static IEnumerable<Type> TypesThatDoNotHaveBuildDefinition { get { return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Record))); } }

        public static List<string> consistencyExceptions;
        public static void CheckConsistency()
        {
            consistencyExceptions = new List<string>();

            foreach (Type record in TypesThatDoNotHaveBuildDefinition)
                if (!recordBuildDefinitions.ContainsKey(record))
                    consistencyExceptions.Add("Don't know how to build " + record.Name);

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

            foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x=>x.IsSubclassOf(typeof(Record))))
            {
                if (tables.ContainsKey(type))
                {
                    List<System.Reflection.PropertyInfo> properties = type.GetAllProperties();
                    HashSet<string> found = null;
                    ExecuteSQLWithResult("Select * from " + tables[type], (x) => found = new HashSet<string>(x.GetColumns().Select(y => y.ToLower())));
                    HashSet<string> current = new HashSet<string>(properties.Select(x =>
                        {
                            string name = x.Name.ToLower();
                            object[] columnDefinition = x.GetCustomAttributes(typeof(ColumnAttribute), true);
                            if (columnDefinition.Length != 0)
                                name = (columnDefinition[0] as ColumnAttribute).Name.ToLower();
                            return name;
                        }));

                    foreach (string column in found)
                        if (!current.Contains(column))
                            consistencyExceptions.Add(type.Name + "." + column + " Not found locally");

                    foreach (string column in current)
                        if (!found.Contains(column))
                            consistencyExceptions.Add(type.Name + "." + column + " Not found server side");

                    if (type.GetConstructor(properties.Select(x => x.PropertyType).ToArray()) == null)
                    {
                        string constructor = string.Join(", ", properties.Select(x => x.PropertyType + " " + x.Name.Substring(0, 1).ToLower() + x.Name.Substring(1)));
                        string initialize = string.Join("\n", properties.Select(x => "this." + x.Name + " = " + x.Name.Substring(0, 1).ToLower() + x.Name.Substring(1)));

                        consistencyExceptions.Add("Default Constructor not found for " + type.Name);
                        consistencyExceptions.Add("public " + type.Name + "(" + constructor.
                            Replace("System.Int32", "int").
                            Replace("System.Double", "double").
                            Replace("System.Boolean", "bool").
                            Replace("System.Bool", "bool").
                            Replace("System.Object", "object").
                            Replace("System.Char", "char").
                            Replace("System.Decimal", "decimal").
                            Replace("System.String", "string")
                            + ")\r\n{\r\n" + initialize + "\r\n}");
                    }
                }
                else
                    consistencyExceptions.Add("Table not found for " + type.Name);
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("consistency.txt"))
            {
                foreach (var item in consistencyExceptions)
                    sw.WriteLine(item);
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

        public static int ExecuteSQL(string sql, params object[] parameters)
        {
            return ExecuteSQL(string.Format(sql, parameters));
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
        public static void ExecuteSQLWithResult(string sql, Action<Reader> resultCallback, params object[] parameters)
        {
            ExecuteSQLWithResult(string.Format(sql, parameters), resultCallback);
        }

        public static void ExecuteSQLWithResult(string sql, Action<Reader> resultCallback, bool testing = false)
        {
            processingList = new List<object>();
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
            return GetWhere<Tent>("TentPeople.visitor_id = {0}", visitor.Id);
        }

        public static List<Tent> GetVisitorBookedTent(Visitor visitor)
        {
            return GetWhere<Tent>("Tents.booked_by = {0}", visitor.Id);
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
            return Find<Employee>("Users.userName = '" + userName + "' and Users.password = '" + password + "'");
        }

        private static T GetUser<T>(string username, string password) where T : User
        {
            return Find<T>("Users.password = '{0}' and Users.username = '{1}'", password, username);
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
            return Find<Visitor>("Visitors.rfid = '{0}'", id);
        }

        public static List<Deposit> GetVisitorTopUps(Visitor visitor)
        {
            return GetWhere<Deposit>("d.visitor_id = {0}", visitor.Id);
        }

        private static List<T> GetAll<T>() where T : Record
        {
            return GetWhere<T>("");
        }

        

        private static object GetRow(Type t, Reader reader)
        {
            object result = null;
            if(!recordBuildDefinitions.ContainsKey(t))
                throw new NotImplementedException("Do not know how to build "  + t.Name);
            result = recordBuildDefinitions[t](reader);

            return result;
        }

        private static void GetUser(Reader reader, out int id, out string firstName, out string lastName, out string userName, out string email, out string picture)
        {
             id = reader.GetInt("ID");
             firstName = reader.GetStr("FirstName");
             lastName = reader.GetStr("LastName");
             userName = reader.GetStr("UserName");
             email = reader.GetStr("Email");
             picture = reader.GetStr("Picture");
        }

        static List<object> processingList;
        static Type processType = typeof(int);

        private static void ProcessReader(Reader reader)
        {
            Type t = processType;
            using (reader)
            {
                while (reader.Read())
                {
                    object row = GetRow(t, reader);
                    processingList.Add(row);
                }
            }
        }

        private static T Find<T>(string where, params object[] parameters) where T : Record
        {
            return GetWhere<T>(where, parameters).FirstOrDefault();
        }

        private static List<T> GetWhere<T>(string where, params object[] parameters) where T : Record
        {
            return GetWhere(typeof(T), string.Format(where, parameters)).Select(x => x as T).ToList();
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

        private static string GetTableFor(Type t)
        {
            if (tables.ContainsKey(t))
                return tables[t];
            throw new NotImplementedException("Table for " + t.Name + " not implemented");
        }
    }
}
