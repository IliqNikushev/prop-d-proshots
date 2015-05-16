using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    using Reader = MySql.Data.MySqlClient.MySqlDataReader;
    using Connection = MySql.Data.MySqlClient.MySqlConnection;
    using Command = MySql.Data.MySqlClient.MySqlCommand;
    public static partial class Database
    {
        public static IEnumerable<Type> notBuildDefinedRecords
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Record))).Where(x => !recordBuildDefinitions.ContainsKey(x));
            }
        }

        private static Dictionary<Type, Func<Reader, string, object>> recordBuildDefinitions = new Dictionary<Type, Func<Reader, string, object>>()
        {
            {typeof(AdminUser), CreateAdmin},
            {typeof(AppointedItem), CreateAppointedItem},
            {typeof(Appointment), CreateAppointment},
            {typeof(AppointmentTask), CreateAppointmentTask},
            {typeof(Deposit), CreateDeposit},
            {typeof(Employee), CreateEmployee},
            {typeof(EmployeeAction), CreateEmployeeAction},
            {typeof(EventLandmark), CreateEventLandmark},
            {typeof(FoodAndDrinkShopJob), CreateFoodAndDrinkShopJob},
            {typeof(GeneralShopJob), CreateGeneralShopJob},
            {typeof(InformationKioskJob), CreateInformationKioskJob},
            {typeof(Item), CreateItem},
            {typeof(ITServiceJob), CreateITServiceJob},
            {typeof(Job), CreateJob},
            {typeof(Landmark), CreateLandmark},
            {typeof(LogMessage), CreateLogMessage},
            {typeof(PayPalDocument), CreatePayPalDocument},
            {typeof(PayPalMachine), CreatePayPalMachine},
            {typeof(PCDoctorJob), CreatePCDoctorJob},
            {typeof(Receipt), CreateReceipt},
            {typeof(RentableItem), CreateRentableItem},
            {typeof(RentableItemHistory), CreateRentableItemHistory},
            {typeof(Restock), CreateRestock},
            {typeof(RestockableItem), CreateRestockableItem},
            {typeof(RestockItem), CreateRestockItem},
            {typeof(ShopJob), CreateShopJob},
            {typeof(ReceiptItem), CreateReceiptItem},
            {typeof(ShopItem), CreateShopItem},
            {typeof(Tent), CreateTent},
            {typeof(TentAreaLandmark), CreateTentAreaLandmark},
            {typeof(User), CreateUser },
            {typeof(Visitor), CreateVisitor},
            {typeof(Warning), CreateWarning}
        };

        private static AdminUser CreateAdmin(Reader reader, string prefix)
        {
            int id = -1;
            string firstName, lastName, userName, password, email;
            CreateUser(reader, out id, out firstName, out lastName, out userName, out password, out email, prefix);
            string type = reader.GetStr(prefix+"type");
            return new AdminUser(id, firstName, lastName, userName, password, email);
        }

        private static AppointedItem CreateAppointedItem(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            string brand = reader.GetStr(prefix + "Brand");
            string model = reader.GetStr(prefix + "Model");
            string type = reader.GetStr(prefix + "Type");
            string group = reader.GetStr(prefix + "igroup");
            string description = reader.GetStr(prefix + "description");
            return new AppointedItem(iD, brand, model, type, group, description);
        }

        private static Appointment CreateAppointment(Reader reader, string prefix)
        {
            Visitor visitor = CreateVisitor(reader, prefix+"Appointed_by_");
            AppointedItem appointedItem = CreateAppointedItem(reader, prefix+"item_");
            int id = reader.Get<int>(prefix + "id");
            System.DateTime completedOn = reader.Get<System.DateTime>(prefix + "CompletedOn");
            bool isReturned = reader.Get<bool>(prefix + "IsReturned");
            string description = reader.GetStr(prefix + "description");
            return new Appointment(id, appointedItem, visitor, completedOn, isReturned, description);
        }

        private static AppointmentTask CreateAppointmentTask(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            string name = reader.GetStr(prefix + "Name");
            decimal price = reader.Get<decimal>(prefix + "Price");
            string description = reader.GetStr(prefix + "Description");
            Appointment appointment = CreateAppointment(reader, prefix+"appointment_");
            return new AppointmentTask(iD, name, price, description, appointment);
        }

        private static Item CreateItem(Reader reader, string prefix)
        {
            //todo this should not be even called
            throw new InvalidOperationException();
            string group = reader.GetStr(prefix + "igroup");
            if (group == "appointment")
                return CreateAppointedItem(reader, prefix);
            if (group == "rent")
                return CreateRentableItem(reader, prefix);
            //todo ETC
            throw new NotImplementedException("UNKNOWN ITEM " + group);
        }

        private static Deposit CreateDeposit(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            decimal amount = reader.Get<decimal>(prefix+"Amount");
            DateTime date = reader.Get<DateTime>(prefix + "date");
            PayPalDocument document = CreatePayPalDocument(reader, prefix + "document_");
            return new Deposit(iD, amount, date, document);
        }

        private static Employee CreateEmployee(Reader reader, string prefix)
        {
            Job job = CreateJob(reader, prefix+"workplace_");
            string firstName = reader.GetStr(prefix+"FirstName");
            string lastName = reader.GetStr(prefix+"LastName");
            int id = reader.Get<int>(prefix+"Id");
            string username = reader.GetStr(prefix+"Username");
            string password = reader.GetStr(prefix+"Password");
            string email = reader.GetStr(prefix+"Email");
            return new Employee(id, firstName, lastName, username, password, email, job);
        }

        private static EmployeeAction CreateEmployeeAction(Reader reader, string prefix)
        {
            int id = reader.Get<int>(prefix + "id");
            Employee employee = CreateEmployee(reader, prefix+"employee_");
            string action = reader.GetStr(prefix+"Action");
            DateTime date = reader.Get<DateTime>(prefix + "date");
            return new EmployeeAction(id, date, employee, action);
        }

        private static Landmark CreateLandmark(Reader reader, string prefix)
        {
            //todo this should not be even called
            throw new InvalidOperationException();
            string type = reader.GetStr(prefix + "type");
            if (type == "paypal")
                return CreatePayPalMachine(reader, prefix);
            if (type == "event")
                return CreateEventLandmark(reader, prefix);
            if (type == "shop")
                return CreateShopJob(reader, prefix);
            //todo ETC
            throw new NotImplementedException("UNKNOWN LANDMARK " + type);
        }

        private static EventLandmark CreateEventLandmark(Reader reader, string prefix)
        {
            System.DateTime timeStart = reader.Get<System.DateTime>(prefix+"TimeStart");
            System.DateTime timeEnd = reader.Get<System.DateTime>(prefix+"TimeEnd");
            int x = reader.Get<int>(prefix+"X");
            int y = reader.Get<int>(prefix+"Y");
            string label = reader.GetStr(prefix+"Label");
            string description = reader.GetStr(prefix+"Description");
            int iD = reader.Get<int>(prefix+"ID");
            return new EventLandmark(iD, label, description, x, y, timeStart, timeEnd);
        }

        private static Job CreateJob(Reader reader, string prefix)
        {
            //todo this should not be even called
            throw new InvalidOperationException();
            string type = reader.GetStr(prefix + "type");
            if (type == "food and drink")
                return CreateFoodAndDrinkShopJob(reader, prefix);
            //todo ETC
            throw new NotImplementedException("Cannot create job");
        }

        private static ShopJob CreateShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix+"X");
            int y = reader.Get<int>(prefix + "Y");
            string label = reader.GetStr(prefix + "Label");
            string description = reader.GetStr(prefix + "Description");
            int iD = reader.Get<int>(prefix + "ID");
            string type = reader.GetStr(prefix+"type");
            return new ShopJob(iD, label, description, x, y);
        }

        private static ReceiptItem CreateReceiptItem(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix+"ID");
            Classes.ShopItem item = CreateShopItem(reader, prefix + "item_");
            int times = reader.Get<int>(prefix + "totalAmount");
            decimal price = reader.Get<decimal>(prefix + "pricePerItem");
            Receipt receipt = CreateReceipt(reader, prefix + "receipt_");
            return new Classes.ReceiptItem(iD, item, receipt, times, price);
        }

        private static ShopItem CreateShopItem(Reader reader, string prefix)
        {
            Classes.ShopJob shop = CreateShopJob(reader, prefix + "shop_");
            int warningLevel = reader.Get<int>(prefix + "warningAmount");
            int inStock = reader.Get<int>(prefix + "quantity");
            decimal price = reader.Get<decimal>(prefix + "Price");
            int iD = reader.Get<int>(prefix + "item_ID");
            int iDd = reader.Get<int>(prefix + "id");
            string brand = reader.GetStr(prefix + "item_Brand");
            string model = reader.GetStr(prefix + "item_Model");
            string type = reader.GetStr(prefix + "item_Type");
            string group = reader.GetStr(prefix + "item_iGroup");
            string description = reader.GetStr(prefix + "item_description");
            return new Classes.ShopItem(iD, price, brand, model, type, group,description, inStock, warningLevel, shop);
        }

        private static FoodAndDrinkShopJob CreateFoodAndDrinkShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            string label = reader.GetStr(prefix + "Label");
            string description = reader.GetStr(prefix + "Description");
            int iD = reader.Get<int>(prefix + "ID");
            string type = reader.GetStr(prefix + "type");
            return new FoodAndDrinkShopJob(iD, label, description, x, y);
        }

        private static GeneralShopJob CreateGeneralShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            string label = reader.GetStr(prefix + "Label");
            string description = reader.GetStr(prefix + "Description");
            int iD = reader.Get<int>(prefix + "ID");
            string type = reader.GetStr(prefix + "type");
            return new GeneralShopJob(iD, label, description, x, y);
        }

        private static InformationKioskJob CreateInformationKioskJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            int iD = reader.Get<int>(prefix + "ID");
            return new InformationKioskJob(iD, x, y);
        }

        private static ITServiceJob CreateITServiceJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            int iD = reader.Get<int>(prefix + "ID");
            return new ITServiceJob(iD, x, y);
        }

        private static LogMessage CreateLogMessage(Reader reader, string prefix)
        {
            int id = reader.Get<int>(prefix + "id");
            DateTime date = reader.Get<DateTime>(prefix + "date");
            string name = reader.GetStr(prefix + "Name");
            string description = reader.GetStr(prefix + "Description");
            return new LogMessage(name, description);
        }

        private static PayPalMachine CreatePayPalMachine(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            int iD = reader.Get<int>(prefix + "ID");
            return new PayPalMachine(iD, x, y);
        }

        private static PCDoctorJob CreatePCDoctorJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            int iD = reader.Get<int>(prefix + "ID");
            return new PCDoctorJob(iD, x, y);
        }

        private static object CreateRestockableItem(Reader reader, string prefix)
        {
            //todo this should not be even called
            throw new NotImplementedException("Cannot create restocableItem");
        }

        private static RentableItem CreateRentableItem(Reader reader, string prefix)
        {
            int inStock = reader.Get<int>(prefix + "InStock");
            decimal price = reader.Get<decimal>(prefix + "Price");
            int iD = reader.Get<int>(prefix + "ID");
            string brand = reader.GetStr(prefix + "Brand");
            string model = reader.GetStr(prefix + "Model");
            string type = reader.GetStr(prefix + "Type");
            string group = reader.GetStr(prefix + "iGroup");
            string description = reader.GetStr(prefix + "description");
            return new RentableItem(iD, price, brand, model, type, group,description, inStock);
        }

        private static PayPalDocument CreatePayPalDocument(Reader reader, string prefix)
        {
            int id = reader.Get<int>(prefix + "id");
            DateTime date = reader.Get<DateTime>(prefix + "date");
            string raw = reader.GetStr(prefix + "raw");
            return new PayPalDocument(id, date, raw);
        }

        private static Receipt CreateReceipt(Reader reader, string prefix)
        {
            System.DateTime purchasedOn = reader.Get<System.DateTime>(prefix + "PurchasedOn");
            Visitor visitor = CreateVisitor(reader, prefix + "purchasedby_");
            int id = reader.Get<int>(prefix + "ID");
            return new Receipt(id, visitor, purchasedOn);
        }

        private static RentableItemHistory CreateRentableItemHistory(Reader reader, string prefix)
        {
            RentableItem rentedItem = CreateRentableItem(reader, prefix + "item_");
            Visitor rentedBy = CreateVisitor(reader, "rentedBy_");
            System.DateTime rentedAt = reader.Get<System.DateTime>(prefix + "RentedAt");
            string notes = reader.GetStr(prefix + "Notes");
            System.DateTime returnedAt = reader.Get<System.DateTime>(prefix + "ReturnedAt");
            System.DateTime rentedTill = reader.Get<System.DateTime>(prefix + "RentedTill");
            Visitor returnedBy = CreateVisitor(reader, prefix + "returnedBy_");
            return new RentableItemHistory(rentedItem, rentedBy, returnedBy, rentedAt, returnedAt, rentedTill, notes);
        }

        private static Restock CreateRestock(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix+"ID");
            System.DateTime date = reader.Get<System.DateTime>(prefix + "Date");
            return new Restock(iD, date);
        }

        private static RestockItem CreateRestockItem(Reader reader, string prefix)
        {
            Restock restock = CreateRestock(reader, prefix + "restock_");
            ShopItem item = CreateShopItem(reader, prefix + "item_");
            int times = reader.Get<int>(prefix + "quantity");
            decimal pricePerItem = reader.Get<decimal>(prefix + "pricePerItem");
            decimal total = reader.Get<decimal>(prefix + "total");
            int itemID = reader.Get<int>(prefix + "item_id");
            return new RestockItem(item, times, restock, pricePerItem, total);
        }

        private static Tent CreateTent(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            TentAreaLandmark location = CreateTentAreaLandmark(reader, prefix + "location_");
            System.DateTime bookedOn = reader.Get<System.DateTime>(prefix + "BookedOn");
            bool isPayed = reader.Get<bool>(prefix + "IsPayed");
            System.DateTime bookedTill = reader.Get<System.DateTime>(prefix + "BookedTill");
            Visitor bookedBy = CreateVisitor(reader, prefix + "bookedBy_");
            return new Tent(iD, location, bookedOn, isPayed, bookedTill, bookedBy);
        }

        private static TentAreaLandmark CreateTentAreaLandmark(Reader reader, string prefix)
        {
            int x = reader.Get<int>(prefix + "X");
            int y = reader.Get<int>(prefix + "Y");
            int iD = reader.Get<int>(prefix + "ID");
            return new TentAreaLandmark(iD, x, y);
        }

        private static void CreateUser(Reader reader, out int id, out string firstName, out string lastName, out string userName, out string password, out string email, string prefix)
        {
            id = reader.Get<int>(prefix + "ID");
            firstName = reader.GetStr(prefix + "FirstName");
            lastName = reader.GetStr(prefix + "LastName");
            userName = reader.GetStr(prefix + "UserName");
            password = reader.GetStr(prefix + "Password");
            email = reader.GetStr(prefix + "Email");
            string type = reader.GetStr(prefix + "type");
        }

        private static User CreateUser(Reader reader, string prefix)
        {
            string type = reader.GetStr(prefix + "Type");

            if (type == "visitor")
                return CreateVisitor(reader, prefix);
            if (type == "admin")
                return CreateAdmin(reader, prefix);
            if (type == "employee")
                return CreateEmployee(reader, prefix);
            throw new NotImplementedException("User type unknown " + type);
        }

        private static Visitor CreateVisitor(Reader reader, string prefix)
        {
            int id = -1;
            string firstName, lastName, userName, password, email;
            CreateUser(reader, out id, out firstName, out lastName, out userName, out password, out email, prefix);

            decimal amount = reader.Get<decimal>(prefix + "balance");
            string rfid = reader.GetStr(prefix + "RFID");
            bool ticket = reader.Get<bool>(prefix + "Ticket");
            string picture = reader.GetStr(prefix + "picture");
            
            return new Visitor(id, firstName, lastName, userName, password, email, picture, amount, rfid, ticket);
        }

        private static Warning CreateWarning(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            string name = reader.GetStr(prefix + "Name");
            string description = reader.GetStr(prefix + "Description");
            return new Warning(iD, name, description);
        }

        public class BuildResult
        {
            public List<string> Search = new List<string>();
            public Dictionary<string, KeyValuePair<Type, Type>> Found = new Dictionary<string, KeyValuePair<Type, Type>>();
        }

        public static Dictionary<Type, BuildResult> BuildTestingResults = new Dictionary<Type, BuildResult>();
        public static bool buildTesting = false;
        static Type currentTesting;
        public static void AddBuildTestTypeMissmatch(string name, Type wanted, Type received)
        {
            BuildTestingResults[currentTesting].Found[name.ToLower()] = new KeyValuePair<Type, Type>(wanted, received);
        }

        public static void AddBuildTestFind(string name)
        {
            name = name.ToLower();
            if (BuildTestingResults[currentTesting].Found.ContainsKey(name)) return;
            BuildTestingResults[currentTesting].Found.Add(name, new KeyValuePair<Type, Type>(typeof(Record), typeof(Record)));
        }

        public static void AddBuildTestSearch(string name)
        {
            name = name.ToLower();
            if (BuildTestingResults[currentTesting].Search.Contains(name)) return;
            BuildTestingResults[currentTesting].Search.Add(name);
        }

        public static void AddBuildTestFound(Reader reader)
        {
            foreach (var item in reader.GetColumns())
                AddBuildTestFind(item);
        }
    }
}