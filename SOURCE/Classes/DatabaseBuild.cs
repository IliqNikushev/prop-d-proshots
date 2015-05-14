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
            {typeof(PurchasableItem), CreatePurchasableItem},
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

        private static Visitor CreateVisitor(Reader reader, string prefix)
        {
            int id = -1;
            string firstName, lastName, userName, password, email;
            CreateUser(reader, out id, out firstName, out lastName, out userName, out password, out email, prefix);

            decimal amount = reader.Get<decimal>(prefix+"Amount");
            string rfid = reader.GetStr(prefix+"RFID");
            bool ticket = reader.Get<bool>(prefix+"Ticket");
            string picture = reader.GetStr(prefix+"picture");

            return new Visitor(id, firstName, lastName, userName, password, email, picture, amount, rfid, ticket);
        }

        private static AdminUser CreateAdmin(Reader reader, string prefix)
        {
            int id = -1;
            string firstName, lastName, userName, password, email;
            CreateUser(reader, out id, out firstName, out lastName, out userName, out password, out email, prefix);

            return new AdminUser(id, firstName, lastName, userName, password, email);
        }

        private static void CreateUser(Reader reader, out int id, out string firstName, out string lastName, out string userName, out string password, out string email, string prefix)
        {
            id = reader.GetInt(prefix + "ID");
            firstName = reader.GetStr(prefix + "FirstName");
            lastName = reader.GetStr(prefix + "LastName");
            userName = reader.GetStr(prefix + "UserName");
            password = reader.GetStr(prefix + "Password");
            email = reader.GetStr(prefix + "Email");
        }

        private static User CreateUser(Reader reader, string prefix)
        {
            string type = reader.GetStr("Type");
            if (type == "visitor")
                return recordBuildDefinitions[typeof(Visitor)](reader, prefix) as Visitor;
            else if (type == "admin")
                return recordBuildDefinitions[typeof(AdminUser)](reader, prefix) as AdminUser;
            throw new NotImplementedException("User type unknown " + type);
        }

        private static AppointmentTask CreateAppointmentTask(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix+"ID");
            string name = reader.GetStr(prefix + "Name");
            decimal price = reader.Get<decimal>(prefix + "Price");
            string description = reader.GetStr(prefix + "Description");
            return new AppointmentTask(iD, name, price, description);
        }

        private static Item CreateItem(Reader reader, string prefix)
        {
            string type = reader.GetStr(prefix + "type");
            if (type == "appointment")
                return CreateAppointedItem(reader, prefix);
            throw new NotImplementedException("UNKNOWN ITEM " + type);
        }

        private static AppointedItem CreateAppointedItem(Reader reader, string prefix)
        {
            int iD = reader.Get<int>(prefix + "ID");
            string brand = reader.GetStr(prefix + "Brand");
            string model = reader.GetStr(prefix + "Model");
            string type = reader.GetStr(prefix + "Type");
            return new AppointedItem(iD, brand, model, type);
        }

        private static Appointment CreateAppointment(Reader reader, string prefix)
        {
            Visitor visitor = CreateVisitor(reader, "visitor_");
            AppointedItem appointedItem = new AppointedItem(reader.Get<int>("iid"), reader.GetStr("ibrand"), reader.GetStr("imodel"), reader.GetStr("itype"));
            int id = reader.Get<int>("id");
            System.DateTime completedOn = reader.Get<System.DateTime>("CompletedOn");
            bool isReturned = reader.Get<bool>("IsReturned");
            return new Appointment(id, appointedItem, visitor, completedOn, isReturned);
        }

        private static Deposit CreateDeposit(Reader reader, string prefix)
        {
            int iD = reader.Get<int>("ID");
            decimal amount = reader.Get<decimal>("Amount");
            return new Deposit(iD, amount);
        }

        private static Employee CreateEmployee(Reader reader, string prefix)
        {
            Job job = CreateJob(reader, "job");
            string firstName = reader.GetStr("FirstName");
            string lastName = reader.GetStr("LastName");
            int id = reader.Get<int>("Id");
            string username = reader.GetStr("Username");
            string password = reader.GetStr("Password");
            string email = reader.GetStr("Email");
            return new Employee(id, firstName, lastName, username, password, email, job);
        }

        private static EmployeeAction CreateEmployeeAction(Reader reader, string prefix)
        {
            Employee employee = CreateEmployee(reader, "emp");
            EmployeeActionType type = reader.Get<EmployeeActionType>("Type");
            return new EmployeeAction(employee, type);
        }

        private static object CreateLandmark(Reader reader, string prefix)
        {
            throw new InvalidOperationException("Cannot create Landmark");
        }

        private static EventLandmark CreateEventLandmark(Reader reader, string prefix)
        {
            System.DateTime timeStart = reader.Get<System.DateTime>("TimeStart");
            System.DateTime timeEnd = reader.Get<System.DateTime>("TimeEnd");
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new EventLandmark(iD, label, description, x, y, timeStart, timeEnd);
        }

        private static Job CreateJob(Reader reader, string prefix)
        {
            throw new InvalidOperationException("Cannot create job");
        }

        private static ShopJob CreateShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new ShopJob(iD, label, description, x, y);
        }

        private static FoodAndDrinkShopJob CreateFoodAndDrinkShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new FoodAndDrinkShopJob(iD, label, description, x, y);
        }

        private static GeneralShopJob CreateGeneralShopJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new GeneralShopJob(iD, label, description, x, y);
        }

        private static InformationKioskJob CreateInformationKioskJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new InformationKioskJob(iD, x, y);
        }

        private static ITServiceJob CreateITServiceJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            int iD = reader.Get<int>("ID");
            return new ITServiceJob(iD, x, y);
        }

        private static LogMessage CreateLogMessage(Reader reader, string prefix)
        {
            string name = reader.GetStr("Name");
            string description = reader.GetStr("Description");
            return new LogMessage(name, description);
        }

        private static PayPalMachine CreatePayPalMachine(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new PayPalMachine(iD, x, y);
        }

        private static PCDoctorJob CreatePCDoctorJob(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            string label = reader.GetStr("Label");
            string description = reader.GetStr("Description");
            int iD = reader.Get<int>("ID");
            return new PCDoctorJob(iD, x, y);
        }

        private static object CreateRestockableItem(Reader reader, string prefix)
        {
            throw new InvalidOperationException("Cannot create restocableItem");
        }

        private static RentableItem CreateRentableItem(Reader reader, string prefix)
        {
            int inStock = reader.Get<int>("InStock");
            int warningLevel = reader.Get<int>("WarningLevel");
            decimal price = reader.Get<decimal>("Price");
            int iD = reader.Get<int>("ID");
            string brand = reader.GetStr("Brand");
            string model = reader.GetStr("Model");
            string type = reader.GetStr("Type");
            return new RentableItem(iD, price, brand, model, type, inStock);
        }

        private static PayPalDocument CreatePayPalDocument(Reader reader, string prefix)
        {
            int id = reader.Get<int>("id");
            DateTime date = reader.Get<DateTime>("date");
            string raw = reader.GetStr("raw");
            return new PayPalDocument(id, date, raw);
        }

        private static PurchasableItem CreatePurchasableItem(Reader reader, string prefix)
        {
            int inStock = reader.Get<int>("InStock");
            //int warningLevel = reader.Get<int>("WarningLevel");
            decimal price = reader.Get<decimal>("Price");
            int iD = reader.Get<int>("ID");
            string brand = reader.GetStr("Brand");
            string model = reader.GetStr("Model");
            string type = reader.GetStr("type"); //todo should be item group ??
            //ShopJob shop = new ShopJob(reader.Get<int>("shop_id"), reader.GetStr("shop_label"), reader.GetStr("shop_description"), reader.Get<int>("shop_x"), reader.Get<int>("shop_y"));
            return new PurchasableItem(iD, price, brand, model, type, inStock);
        }

        private static Receipt CreateReceipt(Reader reader, string prefix)
        {
            System.DateTime purchasedOn = reader.Get<System.DateTime>("PurchasedOn");
            Visitor visitor = CreateVisitor(reader, "visitor");
            ShopJob shop = CreateShopJob(reader, "shop");
            int id = reader.Get<int>("ID");
            return new Receipt(id, visitor, shop, purchasedOn);
        }

        private static RentableItemHistory CreateRentableItemHistory(Reader reader, string prefix)
        {
            RentableItem rentedItem = CreateRentableItem(reader, "item");
            Visitor rentedBy = CreateVisitor(reader, "by");
            System.DateTime rentedAt = reader.Get<System.DateTime>("RentedAt");
            string notes = reader.GetStr("Notes");
            System.DateTime returnedAt = reader.Get<System.DateTime>("ReturnedAt");
            Visitor returnedBy = CreateVisitor(reader, "returned");
            return new RentableItemHistory(rentedItem, rentedBy, returnedBy, rentedAt, returnedAt, notes);
        }

        private static Restock CreateRestock(Reader reader, string prefix)
        {
            int iD = reader.Get<int>("ID");
            System.DateTime date = reader.Get<System.DateTime>("Date");
            return new Restock(iD, date);
        }

        private static RestockItem CreateRestockItem(Reader reader, string prefix)
        {
            Restock restock = CreateRestock(reader, "restock");
            PurchasableItem item = CreatePurchasableItem(reader, "item");
            int times = reader.Get<int>("Times");
            return new RestockItem(item, times, restock);
        }

        private static Tent CreateTent(Reader reader, string prefix)
        {
            int iD = reader.Get<int>("ID");
            TentAreaLandmark location = CreateTentAreaLandmark(reader, "location");
            System.DateTime bookedOn = reader.Get<System.DateTime>("BookedOn");
            bool isPayed = reader.Get<bool>("IsPayed");
            System.DateTime bookedTill = reader.Get<System.DateTime>("BookedTill");
            Visitor bookedBy = CreateVisitor(reader, "by");
            return new Tent(iD, location, bookedOn, isPayed, bookedTill, bookedBy);
        }

        private static TentAreaLandmark CreateTentAreaLandmark(Reader reader, string prefix)
        {
            int x = reader.Get<int>("X");
            int y = reader.Get<int>("Y");
            int iD = reader.Get<int>("ID");
            return new TentAreaLandmark(iD, x, y);
        }

        private static Warning CreateWarning(Reader reader, string prefix)
        {
            int iD = reader.Get<int>("ID");
            string name = reader.GetStr("Name");
            string description = reader.GetStr("Description");
            return new Warning(iD, name, description);
        }

        private static ReceiptItem CreateReceiptItem(Reader reader, string prefix)
        {
            int iD = reader.Get<int>("ID");
            Classes.ShopItem item = CreateShopItem(reader, "Item");
            int times = reader.Get<int>("Times");
            return new Classes.ReceiptItem(iD, item, times);
        }

        private static ShopItem CreateShopItem(Reader reader, string prefix)
        {
            Classes.ShopJob shop = CreateShopJob(reader, "shop");
            int warningLevel = reader.Get<int>("WarningLevel");
            int inStock = reader.Get<int>("InStock");
            decimal price = reader.Get<decimal>("Price");
            int iD = reader.Get<int>("ID");
            string brand = reader.GetStr("Brand");
            string model = reader.GetStr("Model");
            string type = reader.GetStr("Type");
            return new Classes.ShopItem(iD, price, brand, model, type, inStock, warningLevel, shop);
        }
    }
}