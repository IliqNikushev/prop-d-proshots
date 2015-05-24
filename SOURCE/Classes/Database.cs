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
        public class MiscTable
        {
            public int NumberOfCardsTotal;
            public long NumberOfCardsTaken;

            public MiscTable(int numberOfCardsTotal, long numberOfCardsTaken)
            {
                this.NumberOfCardsTaken = numberOfCardsTotal;
                this.NumberOfCardsTaken = numberOfCardsTaken;
            }
        }

        public static MiscTable Misc
        {
            get
            {
                MiscTable misc = null;
                ExecuteSQLWithResult("Select Total, Taken from Misc LIMIT 1", (x) => { if (x.Read()) misc = new MiscTable(x.Get<int>("Total"), x.Get<long>("Taken")); else misc = new MiscTable(-1, - 1); });
                return misc;
            }
        }

        public static Action<Exception, string> OnUnableToProcessSQL;

        const string C_Server = "athena01.fhict.local";
        const string C_DataBase = "dbi317294";
        const string C_UserID = "dbi317294";
        const string C_Password = "NBD7TnUwhT";
        static string connectionString = string.Format(
                    "server={0};database={1};uid={2};password={3};connect timeout=30;",
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
            {typeof(AppointedItem), new Table("Items_Appointed").Copy<Item>()},
            {typeof(Appointment), new Table("Appointments", "description", "id", "completedOn", "isReturned").
                Join<AppointedItem>("JOIN", "Items_Appointed.id = Appointments.appointed_item", "item").
                Join<Visitor>("JOIN", "Appointments.appointed_by = Visitors.user_id", "appointed_by")},
            {typeof(AppointmentTask), new Table("AppointmentTasks", "id", "name", "description", "price").
                Join<Appointment>("JOIN", "AppointmentTasks.appointment_ID = Appointments.id", "appointment")},
            {typeof(Deposit), new Table("PayPalDeposits", "id", "amount", "date").
                Join<PayPalDocument>("JOIN", "PayPalDeposits.paypal_document_id = PayPalDocuments.id", "document")},
            {typeof(Employee), new Table("Employees", "job").
                Join<User>("JOIN", "Employees.user_id = Users.id", "").
                Join<Landmark>("JOIN", "Landmarks.id = Employees.workplace_id", "workplace")},
            {typeof(EmployeeAction), new Table("EmployeeActions", "date", "action", "id").
                Join<Employee>("JOIN", "Employees.user_id = EmployeeActions.employee_id", "employee")},
            {typeof(EventLandmark), new Table("Events", "timeStart", "timeEnd").
                Join<Landmark>("JOIN", "Landmarks.id = Events.location", "")},
            {typeof(FoodAndDrinkShopJob), new Table("Landmarks_foodAndDrink").Copy<Landmark>()},
            {typeof(GeneralShopJob), new Table("Landmarks_GeneralShop").Copy<FoodAndDrinkShopJob>()},
            {typeof(InformationKioskJob), new Table("Landmarks_Info").Copy<ITServiceJob>()},
            {typeof(Item), new Table("Items_All", "brand", "model", "id", "type", "description", "igroup" )},
            {typeof(ITServiceJob), new Table("Landmarks_IT", "id", "x", "y")},
            {typeof(Job), new Table("Workplaces").Copy<ITServiceJob>()},
            {typeof(Landmark), new Table("Landmarks", "id", "label", "description", "x", "y", "type")},
            {typeof(LogMessage), new Table("Logs", "id", "date", "description", "name")},
            {typeof(PayPalDocument), new Table("PayPalDocuments", "id", "date", "raw")},
            {typeof(PayPalMachine), new Table("Landmarks_Paypal").Copy<ITServiceJob>()},
            {typeof(PCDoctorJob), new Table("Landmarks_PCDoctor").Copy<ITServiceJob>()},
            {typeof(ShopItem), new Table("ShopItems", "quantity", "id", "warningAmount", "price").
                Join<Item>("JOIN" ,"ShopItems.item_id = Items_ALL.id", "item").
                Join<ShopJob>("JOIN" ,"Shops.id = Shopitems.shop_id", "shop")},
            {typeof(Receipt), new Table("Receipts", "id", "purchasedOn").
                Join<Visitor>("JOIN", "Receipts.purchasedby = Visitors.user_id", "purchasedby")},
            {typeof(ReceiptItem), new Table("ReceiptItems", "id", "totalAmount", "pricePerItem").
                Join<Receipt>("JOIN", "Receipts.id = ReceiptItems.receipt_id", "receipt").
                Join<ShopItem>("JOIN", "ShopItems.item_id = ReceiptItems.item_id", "item")},
            {typeof(RentableItem), new Table("RentableItems", "price", "inStock").
                Join<Item>("Join", "RentableItems.item_id = Items_All.id", "")},
            {typeof(RentableItemHistory), new Table("RentableItemHistories", "returnedAt", "rentedAt", "notes", "rentedTill").
                Join<RentableItem>("JOIN", "RentableItemHistories.item_id = RentableItems.item_id", "item").
                Join<Visitor>("JOIN", "RentableItemHistories.returnedBy = Visitors.user_id", "returnedBy").
                Join<Visitor>("JOIN", "RentableItemHistories.rentedBy = rentedBy.user_id", "rentedBy", "rentedBy")},
            {typeof(Restock), new Table("Restocks", "id", "date")},
            {typeof(RestockableItem), new Table("RestockableItems").Copy<Item>()},
            {typeof(RestockItem), new Table("RestockItems", "quantity", "pricePerItem", "total").
                Join<Restock>("JOIN", "Restocks.id = RestockItems.restock_id", "restock").
                Join<ShopItem>("JOIN", "ShopItems.item_id = RestockItems.item_id", "item")},
            {typeof(ShopJob), new Table("Shops", "id", "label", "description", "x", "y", "type")},
            {typeof(Tent), new Table("Tents", "bookedOn", "bookedTill", "isPayed").
                Join<Visitor>("JOIN", "Tents.bookedBy = Visitors.user_id", "bookedBy").
                Join<TentAreaLandmark>("JOIN", "Tents_ALL.id = Tents.location", "location")},
            {typeof(TentAreaLandmark), new Table("Tents_All").Copy<ITServiceJob>()},
            {typeof(User), new Table("Users", "id", "firstName", "lastName", "email", "password", "type", "username")},
            {typeof(Visitor), new Table("Visitors", "balance", "picture", "ticket", "rfid").
                Join<User>("JOIN", "Users.id = Visitors.user_id", "")},
            {typeof(Warning), new Table("Warnings", "id", "name", "description")},
        };

        public static string TableNameFor(Type type)
        {
            if (tables.ContainsKey(type))
                return tables[type].Name;

            throw new KeyNotFoundException("NOT CORRECT TYPE REQUESTED");
        }

        public static List<string> consistencyExceptions;

        static Database() { System.IO.StreamWriter sw = new System.IO.StreamWriter("sql.txt"); using (sw) { } }
        public static void CheckConsistency()
        {
            try
            {
                consistencyExceptions = new List<string>();

                foreach (var table in tables)
                {
                    try
                    {
                        ExecuteSQL("Select " + table.Value.ToString(), true);
                    }
                    catch (Exception ex)
                    {
                        consistencyExceptions.Add(ex.GetType().Name.Replace("Exception", ":") + ex.Message + "\r\n" + table.Value.ToString());
                    }
                }
                foreach (var type in Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record))))
                {
                    if (!recordBuildDefinitions.ContainsKey(type))
                    {
                        List<System.Reflection.PropertyInfo> properties = type.GetAllProperties();
                        IEnumerable<string> fields = properties.Select(x =>
                        {
                            string t = x.PropertyType.ToString().
                            Replace("System.Int32", "int").
                            Replace("System.Double", "double").
                            Replace("System.Boolean", "bool").
                            Replace("System.Bool", "bool").
                            Replace("System.Object", "object").
                            Replace("System.Char", "char").
                            Replace("System.Decimal", "decimal").
                            Replace("System.String", "string");

                            return t + " " + x.Name.Lowerize() + " = " + "reader.Get<" + t + ">(\"" + x.Name + "\");";
                        });

                        consistencyExceptions.Add("Don't know how to build " + type.Name);
                        consistencyExceptions.Add(string.Join("\r\n", fields));
                        consistencyExceptions.Add("return new " + type + "(" + string.Join(", ", properties.Select(x => x.Name.Lowerize())) + ");");
                        consistencyExceptions.Add("");
                    }
                }

                consistencyExceptions.Add("");

                foreach (var type in Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Record))))
                {
                    if (tables.ContainsKey(type))
                    {
                        List<System.Reflection.PropertyInfo> properties = type.GetAllProperties();

                        HashSet<string> found = null;
                        try
                        {
                            ExecuteSQLWithResult("Select " + tables[type], (x) => found = new HashSet<string>(x.GetColumns().Select(y => y.ToLower())), true);
                        }
                        catch (Exception ex)
                        {
                            consistencyExceptions.Add(ex.GetType().Name.Replace("Exception", ":") + ex.Message + "\r\n" + tables[type]);
                            continue;
                        }
                        HashSet<string> current = new HashSet<string>(properties.Select(x =>
                            {
                                string name = x.Name;
                                object[] columnDefinition = x.GetCustomAttributes(typeof(ColumnAttribute), true);
                                if (columnDefinition.Length != 0)
                                    name = (columnDefinition[0] as ColumnAttribute).Name;
                                return name.ToLower();
                            }));

                        foreach (string column in found)
                            if (!current.Contains(column))
                                consistencyExceptions.Add(type.Name + "." + column + " Not found locally");
                        consistencyExceptions.Add("");

                        foreach (string column in current)
                            if (!found.Contains(column))
                                consistencyExceptions.Add(type.Name + "." + column + " Not found server side");

                        consistencyExceptions.Add("");
                        System.Reflection.ConstructorInfo[] constructors = type.GetConstructors();
                        Dictionary<Type, int> constructorRequiredTypes = new Dictionary<Type, int>();
                        foreach (var property in properties)
                        {
                            if (!constructorRequiredTypes.ContainsKey(property.PropertyType))
                                constructorRequiredTypes.Add(property.PropertyType, 0);
                            constructorRequiredTypes[property.PropertyType] += 1;
                        }

                        Dictionary<Type, int> constructorRequiredTypesCopy = new Dictionary<Type, int>(constructorRequiredTypes);
                        bool isFound = true;
                        foreach (var constructor in type.GetConstructors())
                        {
                            foreach (var parameter in constructor.GetParameters())
                            {
                                if (!constructorRequiredTypes.ContainsKey(parameter.ParameterType))
                                {
                                    isFound = false;
                                    break;
                                }
                                constructorRequiredTypes[parameter.ParameterType] -= 1;
                                if (constructorRequiredTypes[parameter.ParameterType] < 0)
                                {
                                    isFound = false;
                                    break;
                                }
                            }
                            foreach (var item in constructorRequiredTypes)
                            {
                                if (item.Value > 0)
                                {
                                    isFound = false;
                                    break;
                                }
                            }
                            if (!isFound)
                            {
                                IEnumerable<KeyValuePair<string, string>> fields = properties.Select(x => new KeyValuePair<string, string>(
                                    x.PropertyType.ToString().
                                        Replace("System.Int32", "int").
                                        Replace("System.Double", "double").
                                        Replace("System.Boolean", "bool").
                                        Replace("System.Bool", "bool").
                                        Replace("System.Object", "object").
                                        Replace("System.Char", "char").
                                        Replace("System.Decimal", "decimal").
                                        Replace("System.String", "string"), x.Name));

                                string constructorStr = string.Join(", ", fields.Select(x => x.Key + " " + x.Value.Lowerize()));
                                string initialize = string.Join("\r\n", properties.Select(x => "this." + x.Name + " = " + x.Name.Lowerize() + ";"));

                                consistencyExceptions.Add("Default Constructor not found for " + type.Name);
                                consistencyExceptions.Add(string.Join("\r\n", constructorRequiredTypes.Select(x => x.Key + " => " + x.Value)));
                                consistencyExceptions.Add("public " + type.Name + "(" + constructorStr + ")\r\n{\r\n" + initialize + "\r\n}");
                                break;
                            }
                            constructorRequiredTypes = new Dictionary<Type, int>(constructorRequiredTypesCopy);
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
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Initializer.txt"))
                {
                    sw.WriteLine(ex.GetType().Name);
                    sw.WriteLine(ex.Message);
                }
            }
        }

        public static IEnumerable<Type> notTableDefinedRecords
        {
            get
            {
                return Assembly.GetTypes().
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
                    if (testing || buildTesting)
                        throw;
                }
            }
            return rowsAffected;
        }
        public static void ExecuteSQLWithResult(string sql, Action<Reader> resultCallback, params object[] parameters)
        {
            ExecuteSQLWithResult(string.Format(sql, parameters), resultCallback);
        }

        public static void ExecuteSQLWithResult(string sql, Action<Reader> readerCallback, bool testing = false)
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
                    if (testing || buildTesting)
                        throw;
                }
            }
        }

        private static void LogSQL(string sql)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("sql.txt", true);
            using (sw)
            {
                sw.WriteLine(DateTime.Now + ">>>");
                sw.WriteLine(sql);
            }
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
                return GetWhere<ShopJob>("Landmarks.type ='shop'");
            }
        }

        public static List<ShopItem> PurchasableItems
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

        public static List<TentAreaLandmark> FreeTentAreas
        {
            get
            {
                return GetWhere<TentAreaLandmark>("t.rented_by is null");
            }
        }

        public static Tent GetTent(TentAreaLandmark landmark)
        {
            return Find<Tent>("location = {0}", landmark.ID);
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

        private static object GetRow(Type t, Reader reader)
        {
            object result = null;
            if(!recordBuildDefinitions.ContainsKey(t))
                throw new NotImplementedException("Do not know how to build "  + t.Name);

            result = recordBuildDefinitions[t](reader, "", false);
            reader.ClearPrefixes();

            return result;
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

        public static T Find<T>(string where, params object[] parameters) where T : Record
        {
            return GetWhere<T>(where, parameters).FirstOrDefault();
        }

        public static T Get<T>(string where, params object[] parameters) where T : Record
        {
            return Find<T>(where, parameters);
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
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters)).Select(x => x as T).ToList();
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
                
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters)).Select(x => x as T).ToList();
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
                return GetWhere(t, "Select " + newTable.ToString(), string.Format(where, parameters)).Select(x => x as T).ToList();
            }

            if (t.IsAbstract && t != typeof(Job))
                throw new NotImplementedException("ABSTRACT TYPE REQUESTED AT DATABASE: " + t.Name);

            return GetWhere(t, string.Format(where, parameters)).Select(x => x as T).ToList();
        }

        private static List<object> GetWhere(Type t, string sql, string where)
        {
            processType = t;

            ExecuteSQLWithResult(sql + (where != "" ? " Where " + where : ""), ProcessReader);

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

        class Table
        {
            public class JoinTable
            {
                public Table Table { get { return tables[TableType]; } }
                public Type TableType;
                public string Prefix;
                public string on;
                public string On
                {
                    get
                    {
                        if (this.Alias == null || this.Alias == "") return this.on;
                        return this.on.Replace(this.Table.Name + ".", this.Alias + ".");
                    }
                    set { this.on = value; }
                }
                public string Alias;
                public string Name { get { if (this.Alias == null) return Table.Name; return Table.Name + " " + Alias; } }
                public string Type;
                public bool AddInherited;

                public JoinTable(Type tableType, string type, string prefix, string on, string alias = null, bool addInherited = true)
                {
                    this.TableType = tableType;
                    this.Type = type;
                    this.Prefix = prefix;
                    if (this.Prefix != "") this.Prefix += "_";
                    this.on = on;
                    this.Alias = alias;
                    this.AddInherited = addInherited;
                }

                public IEnumerable<string> Fields
                {
                    get
                    {
                        if (this.Alias == null || this.Alias == "")
                            return Table.Fields.Select(x => x + " " + Prefix + x.Split('.').Last());
                        return Table.Fields.Select(x => x.Replace(Table.Name + ".", Alias + ".") + " " + Prefix + x.Split('.').Last());
                    }
                }

                public string FieldsStr
                {
                    get
                    {
                        return string.Join(", ", this.Fields);
                    }
                }

                public override string ToString()
                {
                    return this.Type + " " + this.Name;
                }
            }

            public string Name;
            public string Extra = "";
            private List<string> fields = null;
            public List<string> Fields
            {
                get
                {
                    if (this.fields.Count == 0)
                        ApplyCopy();
                    return this.fields;
                }
                private set { this.fields = value; }
            }
            public List<JoinTable> Joins = new List<JoinTable>();
            List<Type> CopyFrom = new List<Type>();
            public Table(string name, params string[] fields)
            {
                this.Name = name;
                if (this.Name.IndexOf(" ") != -1)
                {
                    this.Extra = this.Name.Substring(this.Name.IndexOf(" "));
                    this.Name = this.Name.Substring(0, this.Name.IndexOf(" "));
                }
                this.Fields = new List<string>(fields.Select(x => this.Name + "." + x));
            }

            public Table(Table t)
            {
                t.ApplyCopy();
                this.Fields = new List<string>(t.Fields);
                this.Joins = new List<JoinTable>(t.Joins);
                this.Name = t.Name;
                this.Extra = t.Extra;
            }

            public Table Join<T>(string type, string on, string prefix, string alias = null, bool addInherited = true) where T : Record
            {
                this.Joins.Add(new JoinTable(typeof(T), type, prefix, on, alias, addInherited));
                return this;
            }

            public Table Copy<T>()
            {
                this.CopyFrom.Add(typeof(T));
                return this;
            }

            private void ApplyCopy()
            {
                if (this.CopyFrom.Count != 0)
                {
                    IEnumerable<string> current = this.fields.Select(x=>x.ToLower());;
                    foreach (Type copy in this.CopyFrom)
                        this.fields.AddRange(tables[copy].Fields.Select(x => x.Replace(tables[copy].Name + ".", this.Name + ".")).Where(x=>!current.Contains(x.ToLower())));
                    this.CopyFrom.Clear();
                }
            }

            public override string ToString()
            {
                string name = this.Name + this.Extra;
                ApplyCopy();
                string fields = string.Join(", ", this.Fields.Select(x => x + " " + x.Split('.').Last()));
                if (this.Joins.Count != 0)
                {
                    HashSet<string> usedJoins = new HashSet<string>();
                    foreach (var join in this.Joins)
                        ProcessJoin(join, ref name, ref fields, usedJoins, join, new List<JoinTable>());

                    foreach (var join in this.Joins)
                        if (join.Table.Extra != null && join.Table.Extra != "")
                            name += "\r\n" + join.Table.Extra;
                }
                return fields + "\r\nfrom\r\n" + name;
            }

            private void ProcessJoin(JoinTable join, ref string name, ref string fields, HashSet<string> usedJoins, JoinTable main, List<JoinTable> parents)
            {
                string oldAlias = join.Alias;

                int i = 0;
                if (usedJoins.Contains(join.Name))
                {
                    string alias = oldAlias;
                    if (alias == null)
                        alias = join.Table.Name;

                    if (join.Prefix != null && join.Prefix != "")
                        alias = join.Table.Name + "_" + join.Prefix.Replace("_", "");
                    else
                        if (main.Prefix != null && main.Prefix != "")
                            alias = join.Table.Name + "_" + main.Prefix.Replace("_", "");
                    join.Alias = alias;
                    while (usedJoins.Contains(join.Name))
                        join.Alias = alias + "_" + (i++);
                }
                string oldPrefix = join.Prefix;

                string oldOn = join.on;
                foreach (var item in parents)
                    if (item.Alias != null && item.Alias != "")
                        if (join.On.Contains(item.Table.Name + "."))
                            join.On = join.On.Replace(item.Table.Name + ".", item.Alias + ".");

                usedJoins.Add(join.Name);
                name += "\r\n" + join.Type + " " + join.Name + " On " + join.On;
                {
                    string fs = fields;
                    if (parents.Count > 0)
                    {
                        JoinTable x = parents.Last();
                        join.Prefix = x.Prefix == null ? x.Alias == null ? x.Table.Name : x.Alias : x.Prefix;
                        if (join.Prefix.Last() != '_')
                            join.Prefix += "_";

                        join.Prefix += oldPrefix;
                        join.Prefix = join.Prefix.Replace("__", "_");
                    }
                    string f = join.FieldsStr;
                    fields += f.Trim().Length > 0 ? "\r\n, " + f : "";
                }

                parents.Add(join);

                if (join.Table.Joins.Count > 0 && join.AddInherited)
                    foreach (var item in join.Table.Joins)
                        ProcessJoin(item, ref name, ref fields, usedJoins, main, new List<JoinTable>(parents));
                join.Prefix = oldPrefix;
                join.Alias = oldAlias;
                join.On = oldOn;
            }
        }
    }
}
