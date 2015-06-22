﻿using System;
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
        private static Dictionary<Type, Func<Reader, string,bool, Record>> recordBuildDefinitions = new Dictionary<Type, Func<Reader, string,bool, Record>>()
        {
            {typeof(AdminUser), CreateAdmin},
            {typeof(AppointedItem), CreateAppointedItem},
            {typeof(Appointment), CreateAppointment},
            {typeof(AppointmentTask), CreateAppointmentTask},
            {typeof(Deposit), CreateDeposit},
            {typeof(Employee), CreateEmployee},
            {typeof(UserAction), CreateUserAction},
            {typeof(EventLandmark), CreateEventLandmark},
            {typeof(InformationKioskWorkplace), CreateInformationKioskWorkplace},
            {typeof(Item), CreateItem},
            {typeof(ITServiceWorkplace), CreateITServiceWorkplace},
            {typeof(Workplace), CreateWorkplace},
            {typeof(Landmark), CreateLandmark},
            {typeof(LogMessage), CreateLogMessage},
            {typeof(PayPalDocument), CreatePayPalDocument},
            {typeof(PayPalMachine), CreatePayPalMachine},
            {typeof(PCDoctorWorkplace), CreatePCDoctorWorkplace},
            {typeof(Receipt), CreateReceipt},
            {typeof(RentableItem), CreateRentableItem},
            {typeof(RentableItemHistory), CreateRentableItemHistory},
            {typeof(Restock), CreateRestock},
            {typeof(RestockableItem), CreateRestockableItem},
            {typeof(RestockItem), CreateRestockItem},
            {typeof(ShopWorkplace), CreateShopWorkplace},
            {typeof(ReceiptItem), CreateReceiptItem},
            {typeof(ShopItem), CreateShopItem},
            {typeof(Tent), CreateTent},
            {typeof(TentPerson), CreateTentPerson},
            {typeof(TentPitch), CreateTentPitch},
            {typeof(User), CreateUser },
            {typeof(Visitor), CreateVisitor},
            {typeof(Warning), CreateWarning}
        };

        private static AdminUser CreateAdmin(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = -1;
            string firstName, lastName, userName, password, email;
            ExtractUser(reader, out id, out firstName, out lastName, out userName, out password, out email);

            reader.RemoveDistinctPrefix();
            return new AdminUser(id, firstName, lastName, userName, password, email);
        }

        private static AppointedItem CreateAppointedItem(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id;
            string brand;
            string model;
            string type;
            string group;
            string description;
            string icon;
            ExtractItem(reader, out id, out brand, out model, out type, out group, out description, out icon);

            reader.RemoveDistinctPrefix();
            return new AppointedItem(id, brand, model, type, group, description, icon);
        }

        private static Appointment CreateAppointment(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("Appointed_by");
            Visitor visitor = CreateVisitor(reader);
            reader.RemovePrefix();

            reader.AddPrefix("item");
            AppointedItem appointedItem = CreateAppointedItem(reader);
            reader.RemovePrefix();

            int id = reader.Get<int>("id");
            System.DateTime completedOn = reader.Get<System.DateTime>("CompletedOn");
            DateTime appointedOn = reader.Get<System.DateTime>("AppointedOn");
            bool isReturned = reader.Get<bool>("IsReturned");
            string description = reader.GetStr("description");
            bool status = reader.Get<bool>("status");

            reader.RemoveDistinctPrefix();
            return new Appointment(id, appointedItem, visitor, completedOn,appointedOn, isReturned, status ,description);
        }

        private static AppointmentTask CreateAppointmentTask(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int iD = reader.Get<int>("ID");
            string name = reader.GetStr("Name");
            decimal price = reader.Get<decimal>("Price");
            string description = reader.GetStr("Description");

            reader.AddPrefix("appointment_");
            Appointment appointment = CreateAppointment(reader);
            reader.RemovePrefix();

            reader.RemoveDistinctPrefix();
            
            return new AppointmentTask(iD, name, price, description, appointment);
        }

        private static Item CreateItem(Reader reader, string prefix="", bool asbtr = false)
        {
            string group = reader.GetStr("igroup");
            if (buildTesting)
            {
                BuildIgnore("shop_item_id");
                CreateAppointedItem(reader, "appointment");
                CreateRentableItem(reader, "rent");
            }
            switch (group.Replace('-', ' ').ToLower())
            {
                case "appointment":
                    //BuildIgnore("shop_");
                    //BuildIgnore("rent_");
                    return CreateAppointedItem(reader, "appointment");
                case "rent": 
                    return CreateRentableItem(reader, "rent");
            }
            try
            {
                //BuildIgnore("rent_");
                //BuildIgnore("shop_item_id");
                return CreateShopItem(reader, "shop", true);
            }
            catch (NotImplementedException)
            {
                if (buildTesting) return null;

                throw new NotImplementedException("Unknown item type " + group);
            }
        }

        private static Deposit CreateDeposit(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int iD = reader.Get<int>("ID");
            decimal amount = reader.Get<decimal>("Amount");
            int visitor_id = reader.Get<int>("visitor_id");
            DateTime date = reader.Get<DateTime>("date");
            reader.AddPrefix("document");
            PayPalDocument document = CreatePayPalDocument(reader);
            reader.RemovePrefix();

            reader.RemoveDistinctPrefix();

            return new Deposit(iD, amount, date, document, visitor_id);
        }

        private static Employee CreateEmployee(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("workplace");
            Workplace workplace = null;
            if(reader.HasColumnAndNotNull("id"))
                workplace = CreateWorkplace(reader);
            reader.RemovePrefix();
             string duty  = null;
            if(reader.HasColumnAndNotNull("job"))
                duty = reader.GetStr("job");

            int id = -1;
            string firstName, lastName, userName, password, email;
            ExtractUser(reader, out id, out firstName, out lastName, out userName, out password, out email);

            reader.RemoveDistinctPrefix();

            return new Employee(id, firstName, lastName, userName, password, email, workplace, duty);
        }

        private static UserAction CreateUserAction(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = reader.Get<int>("id");
            reader.AddPrefix("user");

            Employee user = CreateEmployee(reader);
            reader.RemovePrefix();

            string action = reader.GetStr("Action");
            DateTime date = reader.Get<DateTime>("date");

            reader.RemoveDistinctPrefix();

            return new UserAction(id, date, user, action);
        }

        private static Landmark CreateLandmark(Reader reader, string prefix="", bool asbtr = false)
        {
            string type = reader.GetStr("type");
            if(buildTesting)
            {
                CreatePayPalMachine(reader);
                CreateEventLandmark(reader);
                CreateTentPitch(reader);
            }
            switch (type.Replace('-', ' ').ToLower())
            {
                case "paypal": return CreatePayPalMachine(reader);
                case "event": return CreateEventLandmark(reader);
                case "tent": return CreateTentPitch(reader);
            }

            try
            {
                return CreateWorkplace(reader, prefix);
            }
            catch (NotImplementedException)
            {
                if (buildTesting) return null;

                throw new NotImplementedException("Unknown landmark type " + type);
            }
        }

        private static EventLandmark CreateEventLandmark(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            System.DateTime timeStart = DateTime.MinValue;
            System.DateTime timeEnd = DateTime.MaxValue;

            if (reader.HasColumnAndNotNull("timeStart"))
            {
                timeStart = reader.Get<System.DateTime>("TimeStart");
                timeEnd = reader.Get<System.DateTime>("TimeEnd");
            }

            int x;
            int y;
            string label;
            string description;
            int iD;
            string icon;
            ExtractLandmark(reader, out x, out y, out label, out description, out icon, out iD);

            reader.RemoveDistinctPrefix();

            return new EventLandmark(iD, label, description, x, y, timeStart, timeEnd);
        }

        private static void ExtractLandmark(Reader reader, out int x, out int y, out string label, out string description, out string icon, out int iD)
        {
            ExtractSimpleLandmark(reader, out x, out y, out iD);
            label = reader.GetStr("Label");
            description = reader.GetStr("Description");
            string type = reader.GetStr("type");
            icon = reader.GetStr("logo");
        }

        private static Workplace CreateWorkplace(Reader reader, string prefix="", bool asbtr = false)
        {
            string type = reader.GetStr("type");
            if (buildTesting)
            {
                CreateShopWorkplace(reader);
                CreatePCDoctorWorkplace(reader);
                CreateInformationKioskWorkplace(reader);
                CreateITServiceWorkplace(reader);
            }

            switch (type.Replace('-', ' ').ToLower())
            {
                case "shop": return CreateShopWorkplace(reader);
                case "pc doctor": return CreatePCDoctorWorkplace(reader);
                case "info": return CreateInformationKioskWorkplace(reader);
                case "rent": return CreateITServiceWorkplace(reader);
            }

            if (buildTesting) return null;

            throw new NotImplementedException("Unknown workplace type " + type);
        }

        private static ShopWorkplace CreateShopWorkplace(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            string label;
            string description;
            int iD;
            string logo;
            ExtractLandmark(reader, out x, out y, out label, out description, out logo, out iD);

            reader.RemoveDistinctPrefix();

            return new ShopWorkplace(iD, label, description, logo, x, y);
        }

        private static ReceiptItem CreateReceiptItem(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int iD = reader.Get<int>("ID");

            reader.AddPrefix("item");
            Classes.ShopItem item = CreateShopItem(reader);
            reader.RemovePrefix();

            decimal totalPrice = reader.Get<decimal>("totalAmount");
            decimal price = reader.Get<decimal>("pricePerItem");
            int times = reader.Get<int>("times");

            reader.AddPrefix("receipt");
            Receipt receipt = CreateReceipt(reader);
            reader.RemovePrefix();

            reader.RemoveDistinctPrefix();

            return new Classes.ReceiptItem(iD, item, receipt, times, price, totalPrice);
        }

        private static ShopItem CreateShopItem(Reader reader, string prefix="", bool abstr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("shop");
            ShopWorkplace shop = CreateShopWorkplace(reader);
            reader.RemovePrefix();

            if(abstr)
                reader.AddPrefix("item");

            int warningLevel = 0;
            int inStock = 0;
            decimal price = 0;

            warningLevel = reader.Get<int>("warningAmount");
            inStock = reader.Get<int>("quantity");
            price = reader.Get<decimal>("Price");

            if(abstr)
                reader.RemovePrefix();

            
            if (!abstr)
                reader.AddPrefix("item");

            int id = 0;
            int itemID;
            string brand;
            string model;
            string type;
            string group;
            string description;
            string icon;
            ExtractItem(reader, out itemID, out brand, out model, out type, out group, out description, out icon);
            if (!abstr)
                reader.RemovePrefix();

            if(reader.HasColumnAndNotNull("ID"))
                id = reader.Get<int>("ID");

            reader.RemoveDistinctPrefix();

            return new Classes.ShopItem(id, price, brand, model, type, group, description, icon, inStock, warningLevel, shop, itemID);
        }

        private static void ExtractItem(Reader reader, out int iD, out string brand, out string model, out string type, out string group, out string description, out string icon)
        {
            iD = reader.Get<int>("ID");
            brand = reader.GetStr("Brand");
            model = reader.GetStr("Model");
            type = reader.GetStr("Type");
            group = reader.GetStr("iGroup");
            description = reader.GetStr("description");
            icon = reader.GetStr("icon");
        }

        private static InformationKioskWorkplace CreateInformationKioskWorkplace(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            int iD;
            ExtractSimpleLandmark(reader, out x, out y, out iD);

            reader.RemoveDistinctPrefix();

            return new InformationKioskWorkplace(iD, x, y);
        }

        private static void ExtractSimpleLandmark(Reader reader, out int x, out int y, out int iD)
        {
            x = reader.Get<int>("X");
            y = reader.Get<int>("Y");
            iD = reader.Get<int>("ID");
        }

        private static ITServiceWorkplace CreateITServiceWorkplace(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            int iD;
            ExtractSimpleLandmark(reader, out x, out y, out iD);

            reader.RemoveDistinctPrefix();

            return new ITServiceWorkplace(iD, x, y);
        }

        private static LogMessage CreateLogMessage(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = reader.Get<int>("id");
            DateTime date = reader.Get<DateTime>("date");
            string name = reader.GetStr("Name");
            string description = reader.GetStr("Description");

            reader.RemoveDistinctPrefix();

            return new LogMessage(id, date, name, description);
        }

        private static PayPalMachine CreatePayPalMachine(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            int iD;
            ExtractSimpleLandmark(reader, out x, out y, out iD);

            reader.RemoveDistinctPrefix();

            return new PayPalMachine(iD, x, y);
        }

        private static PCDoctorWorkplace CreatePCDoctorWorkplace(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            int iD;
            ExtractSimpleLandmark(reader, out x, out y, out iD);

            reader.RemoveDistinctPrefix();

            return new PCDoctorWorkplace(iD, x, y);
        }

        private static RestockableItem CreateRestockableItem(Reader reader, string prefix="", bool asbtr = false)
        {
            return CreateItem(reader) as RestockableItem;
        }

        private static RentableItem CreateRentableItem(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int inStock = 0;
            decimal price = 0;
            if(reader.HasColumnAndNotNull("Price"))
            {
               inStock = reader.Get<int>("InStock");
               price = reader.Get<decimal>("Price");
            }
            int id;
            string brand;
            string model;
            string type;
            string group;
            string description;
            string icon;
            ExtractItem(reader, out id, out brand, out model, out type, out group, out description, out icon);

            reader.RemoveDistinctPrefix();

            return new RentableItem(id, price, brand, model, type, group,description, icon, inStock);
        }

        private static PayPalDocument CreatePayPalDocument(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = reader.Get<int>("id");
            DateTime date = reader.Get<DateTime>("date");
            string raw = reader.GetStr("raw");

            reader.RemoveDistinctPrefix();

            return new PayPalDocument(id, date, raw);
        }

        private static Receipt CreateReceipt(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("purchasedby");
            Visitor visitor = CreateVisitor(reader);
            reader.RemovePrefix();

            System.DateTime purchasedOn = reader.Get<System.DateTime>("PurchasedOn");
            bool postponed = reader.Get<bool>("postponed");
            int id = reader.Get<int>("ID");

            reader.RemoveDistinctPrefix();

            return new Receipt(id, visitor, purchasedOn, postponed);
        }

        private static RentableItemHistory CreateRentableItemHistory(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("item");
            RentableItem rentedItem = CreateRentableItem(reader);
            reader.RemovePrefix();

            reader.AddPrefix("rentedBy");
            Visitor rentedBy = CreateVisitor(reader);
            reader.RemovePrefix();

            System.DateTime rentedAt = reader.Get<System.DateTime>("RentedAt");
            string notes = reader.GetStr("Notes");
            int id = reader.Get<int>("id");

            System.DateTime rentedTill = reader.Get<System.DateTime>("RentedTill");
            
            Visitor returnedBy = null;
            reader.AddPrefix("returnedBy");
            if (reader.HasColumnAndNotNull("ticket"))
            {
                returnedBy = CreateVisitor(reader);
            }
            reader.RemovePrefix();

            System.DateTime returnedAt = reader.Get<System.DateTime>("ReturnedAt");

            reader.RemoveDistinctPrefix();

            return new RentableItemHistory(id, rentedItem, rentedBy, returnedBy, rentedAt, returnedAt, rentedTill, notes);
        }

        private static Restock CreateRestock(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int iD = reader.Get<int>("ID");
            System.DateTime date = reader.Get<System.DateTime>("Date");

            reader.RemoveDistinctPrefix();

            return new Restock(iD, date);
        }

        private static RestockItem CreateRestockItem(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("restock");
            Restock restock = CreateRestock(reader);
            reader.RemovePrefix();

            reader.AddPrefix("item");
            ShopItem item = CreateShopItem(reader);
            reader.RemovePrefix();

            int id = reader.Get<int>("id");
            int times = reader.Get<int>("quantity");
            decimal pricePerItem = reader.Get<decimal>("pricePerItem");
            decimal total = reader.Get<decimal>("total");
            int itemID = reader.Get<int>("item_id");

            reader.RemoveDistinctPrefix();

            return new RestockItem(id, item, times, restock, pricePerItem, total);
        }

        private static Tent CreateTent(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            reader.AddPrefix("location");
            TentPitch location = CreateTentPitch(reader);
            reader.RemovePrefix();

            System.DateTime bookedOn = reader.Get<System.DateTime>("BookedOn");
            bool isPayed = reader.Get<bool>("isPaid");
            System.DateTime bookedTill = reader.Get<System.DateTime>("BookedTill");

            reader.AddPrefix("bookedBy");
            Visitor bookedBy = CreateVisitor(reader);
            reader.RemovePrefix();

            reader.RemoveDistinctPrefix();

            return new Tent(location, bookedOn, isPayed, bookedTill, bookedBy);
        }

        private static TentPerson CreateTentPerson(Reader reader, string prefix = "", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = reader.Get<int>("id");
            System.DateTime checkedInTime = reader.Get<System.DateTime>("CheckedInTime");

            reader.AddPrefix("tent");
            Tent tent = CreateTent(reader);
            reader.RemovePrefix();

            reader.AddPrefix("visitor");
            Visitor visitor = CreateVisitor(reader);
            reader.RemovePrefix();

            reader.RemoveDistinctPrefix();

            return new TentPerson(id, visitor, tent, checkedInTime);
        }

        private static TentPitch CreateTentPitch(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int x;
            int y;
            int iD;
            ExtractSimpleLandmark(reader, out x, out y, out iD);

            reader.RemoveDistinctPrefix();

            return new TentPitch(iD, x, y);
        }

        private static void ExtractUser(Reader reader, out int id, out string firstName, out string lastName, out string userName, out string password, out string email)
        {
            id = reader.Get<int>("ID");
            firstName = reader.GetStr("FirstName");
            lastName = reader.GetStr("LastName");
            userName = reader.GetStr("UserName");
            password = reader.GetStr("Password");
            email = reader.GetStr("Email");
            string type = reader.GetStr("type");
        }

        private static User CreateUser(Reader reader, string prefix="", bool asbtr = false)
        {
            string type = reader.GetStr("Type");

            if (buildTesting)
            {
                CreateVisitor(reader, "visitor");
                CreateAdmin(reader, "admin");
                CreateEmployee(reader, "employee");
            }

            switch (type.Replace('-', ' ').ToLower())
            {
                case "visitor": return CreateVisitor(reader, "visitor");
                case "admin": return CreateAdmin(reader, "admin");
                case "employee": return CreateEmployee(reader, "employee");
            }

            if (buildTesting) return null;

            throw new NotImplementedException("Unknwon user type " + type);
        }

        private static Visitor CreateVisitor(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int id = -1;
            string firstName, lastName, userName, password, email;
            ExtractUser(reader, out id, out firstName, out lastName, out userName, out password, out email);

            decimal amount = 0;
            string rfid = null;
            bool ticket = false;
            string picture = null;
            bool isInTheEvent = false;

            if (reader.HasColumnAndNotNull("ticket"))
            {
                amount = reader.Get<decimal>("balance");
                rfid = reader.GetStr("RFID");
                ticket = reader.Get<bool>("Ticket");
                picture = reader.GetStr("picture");
                isInTheEvent = reader.Get<bool>("IsInTheEvent");
            }

            reader.RemoveDistinctPrefix();

            return new Visitor(id, firstName, lastName, userName, password, email, picture, amount, rfid, ticket, isInTheEvent);
        }

        private static Warning CreateWarning(Reader reader, string prefix="", bool asbtr = false)
        {
            reader.AddDistinctPrefix(prefix);

            int iD = reader.Get<int>("ID");
            string name = reader.GetStr("Name");
            string description = reader.GetStr("Description");

            reader.RemoveDistinctPrefix();

            return new Warning(iD, name, description);
        }

        public class BuildResult
        {
            public List<string> Search = new List<string>();
            public Dictionary<string, KeyValuePair<Type, Type>> Found = new Dictionary<string, KeyValuePair<Type, Type>>();

            public void Ignore(string target)
            {
                var f = this.Found.Where(x => x.Key.StartsWith(target.ToLower())).ToArray();
                foreach (var item in f)
                    Found.Remove(item.Key);
            }
        }

        public static Dictionary<Type, BuildResult> BuildTestingResults = new Dictionary<Type, BuildResult>();
        public static bool buildTesting = false;
        public static bool testing = false;
        static Type currentTesting;

        private static void BuildIgnore(string target)
        {
            BuildTestingResults[currentTesting].Ignore(target);
        }

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