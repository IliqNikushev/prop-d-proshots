using System;
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
                    "server={0};database={1};uid={2};password={3};",
                    C_Server, C_DataBase, C_UserID, C_Password
                );

        private static System.Reflection.Assembly assembly;
        public static System.Reflection.Assembly Assembly
        {
            get
            {
                if (assembly == null)
                    assembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetTypes().Where(y => y == typeof(Record)).Any()).First();
                return assembly;
            }
        }

        static Dictionary<Type, Table> tables = new Dictionary<Type, Table>()
        {
            {typeof(AdminUser), new Table("Admins").
                Copy<User>()},
            {typeof(AppointedItem), new Table("Items_ALL Where Items_ALL.type = 'appointment'")
                .Copy<Item>()},
            {typeof(Appointment), new Table("Appointments", "description", "id", "completedOn", "isReturned").
                Join<AppointedItem>("JOIN", "Items_ALL.id = Appointments.appointed_item", "item").
                Join<Visitor>("JOIN", "Appointments.appointed_by = Visitors.user_id", "appointed_by")},
            {typeof(AppointmentTask), new Table("AppointmentTasks", "id", "name", "description", "price").
                Join<Appointment>("JOIN", "AppointmentTasks.appointment_ID = Appointments.id", "appointment")},
            {typeof(Deposit), new Table("PayPalDeposits", "id", "amount", "date").
                Join<PayPalDocument>("JOIN", "PayPalDeposits.paypal_document_id = PayPalDocuments.id", "document")},
            {typeof(Employee), new Table("Employees", "job").
                Join<User>("JOIN", "Employees.user_id = Users.id", "").
                Join<Landmark>("LEFT JOIN", "Landmarks.id = Employees.workplace_id", "workplace")},
            {typeof(EmployeeAction), new Table("EmployeeActions", "date", "action", "id").
                Join<Employee>("JOIN", "Employees.user_id = EmployeeActions.employee_id", "employee")},
            {typeof(EventLandmark), new Table("Events", "timeStart", "timeEnd").
                Join<Landmark>("JOIN", "Landmarks.id = Events.location", "")},
            {typeof(InformationKioskJob), new Table("Landmarks where landmarks.type = 'info'")
                .Copy<ITServiceJob>()},
            {typeof(Item), new Table("Items_ALL", "brand", "model", "id", "type", "description", "igroup", "icon" )},
            {typeof(ITServiceJob), new Table("Landmarks where landmarks.type = 'it'", "id", "x", "y")},
            {typeof(Job), new Table("Workplaces", "id", "x", "y", "label", "description", "type", "logo")},
            {typeof(Landmark), new Table("Landmarks", "id", "label", "description", "x", "y", "type", "logo")},
            {typeof(LogMessage), new Table("Logs", "id", "date", "description", "name")},
            {typeof(PayPalDocument), new Table("PayPalDocuments", "id", "date", "raw")},
            {typeof(PayPalMachine), new Table("Landmarks where landmarks.type = 'paypal'")
                .Copy<ITServiceJob>()},
            {typeof(PCDoctorJob), new Table("Landmarks where landmarks.type ='pc-doctor'")
                .Copy<ITServiceJob>()},
            {typeof(ShopItem), new Table("ShopItems", "quantity", "id", "warningAmount", "price").
                Join<Item>("JOIN" ,"ShopItems.item_id = Items_ALL.id", "item").
                Join<ShopJob>("JOIN" ,"Shops.id = Shopitems.shop_id", "shop")},
            {typeof(Receipt), new Table("Receipts", "id", "purchasedOn").
                Join<Visitor>("JOIN", "Receipts.purchasedby = Visitors.user_id", "purchasedby")},
            {typeof(ReceiptItem), new Table("ReceiptItems", "id", "totalAmount", "pricePerItem", "times").
                Join<Receipt>("JOIN", "Receipts.id = ReceiptItems.receipt_id", "receipt").
                Join<ShopItem>("JOIN", "ShopItems.item_id = ReceiptItems.item_id", "item")},
            {typeof(RentableItem), new Table("RentableItems", "price", "inStock").
                Join<Item>("Join", "RentableItems.item_id = Items_ALL.id", "")},
            {typeof(RentableItemHistory), new Table("RentableItemHistories", "returnedAt", "rentedAt", "notes", "rentedTill", "id").
                Join<RentableItem>("JOIN", "RentableItemHistories.item_id = RentableItems.item_id", "item").
                Join<Visitor>("LEFT JOIN", "RentableItemHistories.returnedBy = Visitors.user_id", "returnedBy").
                Join<Visitor>("JOIN", "RentableItemHistories.rentedBy = rentedBy.user_id", "rentedBy", "rentedBy")},
            {typeof(Restock), new Table("Restocks", "id", "date")},
            {typeof(RestockableItem), new Table("RestockableItems").
                Copy<Item>()},
            {typeof(RestockItem), new Table("RestockItems", "quantity", "pricePerItem", "total", "id").
                Join<Restock>("JOIN", "Restocks.id = RestockItems.restock_id", "restock").
                Join<ShopItem>("JOIN", "ShopItems.item_id = RestockItems.item_id", "item")},
            {typeof(ShopJob), new Table("Shops", "id", "label", "description", "x", "y", "type", "logo")},
            {typeof(Tent), new Table("Tents", "bookedOn", "bookedTill", "isPayed").
                Join<Visitor>("JOIN", "Tents.bookedBy = Visitors.user_id", "bookedBy").
                Join<TentPitch>("JOIN", "Landmarks.id = Tents.location", "location")},
            {typeof(TentPerson), new Table("TentPeople", "ID", "CheckedInTime").
                Join<Visitor>("JOIN", "TentPeople.visitor_id = Visitors.user_id", "visitor").
                Join<Tent>("JOIN", "Tents.location = TentPeople.Tent_ID", "tent")},
            {typeof(TentPitch), new Table("Landmarks where landmarks.type = 'tent'").
                Copy<ITServiceJob>()},
            {typeof(User), new Table("Users", "id", "firstName", "lastName", "email", "password", "type", "username")},
            {typeof(Visitor), new Table("Visitors", "balance", "picture", "ticket", "rfid").
                Join<User>("JOIN", "Users.id = Visitors.user_id", "")},
            {typeof(Warning), new Table("Warnings", "id", "name", "description")},
        };

        private static Table TName<T>() where T : Record
        {
            return new Table(TableNameFor(typeof(T)));
        }

        public static Table TableName<T>() where T : Record
        {
            return TName<T>();
        }

        public static string TableNameFor(Record record)
        {
            return TableNameFor(record.GetType());
        }

        private static string TableNameFor(Type type)
        {
            if (tables.ContainsKey(type))
                return tables[type].Name;

            throw new KeyNotFoundException("NOT CORRECT TYPE REQUESTED");
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

        public static Record Insert(Record record, string values, params object[] parameters)
        {
            if (values.Split(',').Length != parameters.Length) throw new InvalidOperationException("Value missing in parameters");

            Type t = new System.Diagnostics.StackFrame(1).GetMethod().DeclaringType;
            if (!t.IsSubclassOf(typeof(Record)))
                t = record.GetType();
            Table table = tables[t];

            return Insert(t, table, values, parameters);
        }

        public static T Insert<T>(string values, params object[] parameters) where T:Record
        {
            if (values.Split(',').Length != parameters.Length) throw new InvalidOperationException("Value missing in parameters");

            Table table = tables[typeof(T)];

            return (T)Insert(typeof(T), table, values, parameters);
        }

        public static Record Update(Record record, string set, string identifier)
        {
            Table table = tables[record.GetType()];
            //if (table.Joins.Count > 0) throw new NotImplementedException("Nested update not implemented");

            ExecuteScalar(string.Format("UPDATE {0} SET {1} WHERE {2};",
                    table.Name, set, identifier));

            List<object> result = GetWhere(record.GetType(), identifier);
            return result.Last() as Record;
        }

        public static int ExecuteSQL(string sql, params object[] parameters)
        {
            return ExecuteSQL(string.Format(sql, parameters));
        }

        public static object ExecuteScalar(string sql, params object[] parameters)
        {
            return ExecuteScalar(string.Format(sql, parameters));
        }

        public static void ExecuteSQLWithResult(string sql, Action<Reader> resultCallback, params object[] parameters)
        {
            ExecuteSQLWithResult(string.Format(sql, parameters), resultCallback);
        }

        public static object ExecuteScalar(string sql)
        {
            LogSQL(sql);

            object result = null;
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    result = c.ExecuteScalar();
                    connection.Close();

                    LogResult(result);
                }
                catch (Exception ex)
                {
                    LogResult(ex.GetType().Name + " \n " + ex.Message);
                    if (OnUnableToProcessSQL != null)
                        OnUnableToProcessSQL(ex, sql);
                    if (testing)
                        throw;
                }
            }
            return result;
        }

        public static int ExecuteSQL(string sql)
        {
            LogSQL(sql);

            int rowsAffected = 0;
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    rowsAffected = c.ExecuteNonQuery();
                    connection.Close();

                    LogResult(rowsAffected);
                }
                catch (Exception ex)
                {
                    LogResult(ex.GetType().Name + " \n " + ex.Message);
                    if (OnUnableToProcessSQL != null)
                        OnUnableToProcessSQL(ex, sql);
                    if (testing)
                        throw;
                }
            }
            return rowsAffected;
        }

        public static void ExecuteSQLWithResult(string sql, Action<Reader> readerCallback)
        {
            LogSQL(sql);
            processingList = new List<object>();
            using (Connection connection = new Connection(connectionString))
            {
                Command c = new Command(sql, connection);
                try
                {
                    connection.Open();
                    Reader reader = c.ExecuteReader();
                    if (readerCallback == null) throw new NotImplementedException("Do not know what to do with \n" + sql);

                    int fields = 0;
                    bool hasRows = false;
                    int rowsCount = 0;

                    using (reader)
                    {
                        fields = reader.FieldCount;
                        hasRows = reader.HasRows;
                        readerCallback(reader);
                    }

                    rowsCount = processingList.Count();
                    connection.Close();
                    
                    LogResult(hasRows + " => Cols:" + fields + " * Rows:" + rowsCount);
                }
                catch (Exception ex)
                {
                    LogResult(ex.GetType().Name + " \n " + ex.Message);
                    if(OnUnableToProcessSQL != null)
                        OnUnableToProcessSQL(ex, sql);
                    if (testing)
                        throw;
                }
            }
        }

        private static void LogSQL(string sql)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("sql.txt", true);
            using (sw)
            {
                sw.WriteLine(DateTime.Now + ">>>" + new System.Diagnostics.StackFrame(1).GetMethod().Name);
                sw.WriteLine(sql);
            }
        }

        public static List<T> Where<T>(string wherePattern, params object[] parameters) where T : Record
        {
            return GetWhere<T>(wherePattern, parameters);
        }

        public static List<T> GetAll<T>() where T : Record
        {
            return All<T>();
        }

        public static List<T> All<T>() where T : Record
        {
            return GetWhere<T>("");
        }

        public static long Count<T>(string wherePattern = "", params object[] parameters)
        {
            string where = "";
            if (wherePattern != "" || wherePattern != null)
                where = wherePattern.Arg(parameters);
            string tableString = tables[typeof(T)].ToString().ToLower();
            where = where.Replace("|T|", tables[typeof(T)].Name);
            if(where.Trim().Length > 0)
                if (tableString.ToLower().IndexOf("where") != -1)
                    where = " and " + where;
            return (long)ExecuteScalar("Select count(*) from {0} {1}",
                tableString.Split(new string[] { "\r\nfrom\r\n", " from " }, StringSplitOptions.None).Last(), where);
        }

        public static T Find<T>(string where, params object[] parameters) where T : Record
        {
            return GetWhere<T>(where + " Limit 1", parameters).FirstOrDefault();
        }

        public static T Get<T>(string where, params object[] parameters) where T : Record
        {
            return Find<T>(where, parameters);
        }

        private static void LogResult(object result)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("sql.txt", true);
            using (sw)
            {
                sw.WriteLine("result => " + result);
                sw.WriteLine("<<<");
                sw.WriteLine("");
            }
        }

        private static Record Insert(Type recordType, Table table, string values, params object[] parameters)
        {
            //if (table.Joins.Count > 0) throw new NotImplementedException("Nested insert not implemented");
            parameters = parameters.Format();
            string[] valuesSplit = values.Split(',');
            KeyValuePair<string, object>[] whereParameters = new KeyValuePair<string, object>[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
                whereParameters[i] = new KeyValuePair<string, object>(valuesSplit[i].Trim(), parameters[i].ToString());

            ExecuteScalar("Insert into {0} ({1}) values ({2}); ", table.Name,
                    values,
                    string.Join(",", parameters));

            List<object> result = GetWhere(recordType, string.Join(" and ", whereParameters.Select(x => x.Key + " = " + x.Value)));
            return result.Last() as Record;
        }

        static List<object> processingList;
        static Type processType = typeof(int);

        private static void ProcessReader(Reader reader)
        {
            Type t = processType;
            if (buildTesting)
            {
                if (!BuildTestingResults.ContainsKey(t))
                {
                    BuildTestingResults.Add(t, new BuildResult());
                    currentTesting = t;
                    AddBuildTestFound(reader);
                }
                GetRow(t, reader);
            }
            else
                while (reader.Read())
                {
                    object row = GetRow(t, reader);
                    processingList.Add(row);
                }
        }

        private static object GetRow(Type t, Reader reader)
        {
            object result = null;
            if (!recordBuildDefinitions.ContainsKey(t))
                throw new NotImplementedException("Do not know how to build " + t.Name);

            result = recordBuildDefinitions[t](reader, "", false);
            reader.ClearPrefixes();

            return result;
        }

        private static List<T> GetWhere<T>(string where, params object[] parameters) where T : Record
        {
            Type t = typeof(T);

            if (t == typeof(User))
            {
                Table newTable = new Table(tables[typeof(Employee)]).Join<Visitor>("LEFT JOIN", "Users.id = Visitors.user_id", "","", false);
                foreach (var table in newTable.Joins)
                {
                    if (table.Name == tables[typeof(User)].Name)
                        table.Type = "RIGHT JOIN";
                    else
                        table.Type = "LEFT JOIN";
                }
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters.Format())).Select(x => x as T).ToList();
            }

            if (t == typeof(Item))
            {
                Table newTable = new Table(tables[typeof(Item)]).
                    Join<ShopItem>("LEFT JOIN", "ShopItems.item_id = Items_all.id", "shop_item","",false).
                    Join<ShopJob>("JOIN" ,"Shops.id = Shopitems.shop_id", "shop_shop").
                    Join<RentableItem>("LEFT JOIN", "RentableItems.item_id = Items_ALL.id", "rent", "", false);
                foreach (var table in newTable.Joins)
                    if (table.Name != tables[typeof(Item)].Name)
                        table.Type = "LEFT JOIN";
                
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters.Format())).Select(x => x as T).ToList();
            }

            if (t == typeof(Landmark))
            {
                Table newTable = new Table(tables[typeof(EventLandmark)]);
                foreach (var table in newTable.Joins)
                {
                    if (table.Name == tables[typeof(Landmark)].Name)
                        table.Type = "RIGHT JOIN";
                    else
                        table.Type = "LEFT JOIN";
                }
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters.Format())).Select(x => x as T).ToList();
            }

            if (t.IsAbstract && t != typeof(Job))
                throw new NotImplementedException("ABSTRACT TYPE REQUESTED AT DATABASE: " + t.Name);

            return GetWhere(t, string.Format(where, parameters.Format())).Select(x => x as T).ToList();
        }

        private static List<object> GetWhere(Type t, string sql, string where)
        {
            processType = t;

            string[] wantedTables = sql.Split('|');
            where = where.Replace("|T|", tables[t].Name);

            ExecuteSQLWithResult(sql + (sql.ToLower().IndexOf("where") == -1 ?  " Where " + where : " and " + where), ProcessReader);

            List<object> result = new List<object>(processingList);
            processingList.Clear();
            processingList = null;
            return result;
        }

        private static List<object> GetWhere(Type t, string where)
        {
            Table tableName = tables[t];
            processType = t;

            return GetWhere(t, "Select " + tableName, where);
        }

        private static Table GetTableFor(Type t)
        {
            if (tables.ContainsKey(t))
                return tables[t];
            throw new NotImplementedException("Table for " + t.Name + " not implemented");
        }
    }
}
