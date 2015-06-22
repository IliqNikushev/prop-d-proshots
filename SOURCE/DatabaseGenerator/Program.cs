using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace DatabaseGenerator
{
    class Program
    {
        private static void Delete()
        {
            foreach (Database.Table table in Database.Tables)
            {
                string name = table.Name;
                if (table.Name == Database.TableFor<Item>().Name)
                    name = "Items";
                else if (table.Name == Database.TableFor<AdminUser>().Name)
                    name = "Users";
                else if (table.Name == Database.TableFor<ShopWorkplace>().Name)
                    name = "landmarks";
                Database.ExecuteSQL("Delete from {0}", name);
                if(Database.HadAnError)
                    Console.WriteLine("DELETE X > " + name);
                else
                    Console.WriteLine("DELETE Y > " + name);
                Database.ExecuteSQL("ALTER TABLE {0} AUTO_INCREMENT = 1", name);
                if(Database.HadAnError)
                    Console.WriteLine("AI X");
                else
                    Console.WriteLine("AI Y");
                Console.WriteLine();
            }
        }

        public static string TypeOf(Classes.Landmark l)
        {
            Type t = l.GetType();
            if (l != null)
            {
                if (t == typeof(Classes.EventLandmark)) return "event";
                if (t == typeof(Classes.PayPalMachine)) return "paypal";
                if (t == typeof(Classes.ShopWorkplace)) return "shop";
                if (t == typeof(Classes.InformationKioskWorkplace)) return "info";
                if (t == typeof(Classes.ITServiceWorkplace)) return "rent";
                if (t == typeof(Classes.PCDoctorWorkplace)) return "pc-doctor";
                if (t == typeof(Classes.TentPitch)) return "tent";
            }
            throw new InvalidOperationException("UNKNOWN LANDMARK," + t.GetType().Name);
        }

        private static void Create()
        {
            Landmark[] landmarks = new Landmark[]
            {
                new TentPitch(0, 610, 302),
                new TentPitch(0, 630, 302),
                new TentPitch(0, 650, 302),
                new TentPitch(0, 636, 280),
                new TentPitch(0, 664, 232),
                new PayPalMachine(0, 475, 209),

                new ShopWorkplace(0, "FoodAndDrink", "Main food and drink shop", "foodAndDrink.png", 564, 280),
                new ITServiceWorkplace(0, 468, 331),
                new PCDoctorWorkplace(0, 571, 230),
                new InformationKioskWorkplace(0, 423, 356)
            };

            foreach (var item in landmarks)
	        {
		        Record r = Database.Insert<Landmark>("label, description, x, y, type, logo",
                    item.Label, item.Description, item.X - 365, item.Y - 19, TypeOf(item), item.Icon.Split('/').Last());

                if(item is EventLandmark)
                {
                    EventLandmark e = item as EventLandmark;
                    Database.Insert<EventLandmark>("location, timeStart, timeEnd",
                        e.ID, e.TimeStart, e.TimeEnd);
                }
	        }

            User[] users = new User[]
            {
                new Visitor(0,"Peter", "Peterson", "Visitor", "pass", "peter@mail.com", "peter.png", 100, null, false, false),
                new Visitor(0,"Artur", "Haywood", "Artur", "pass", "artur@mail.com", "artur.png", 200, null, true, true),
                new Visitor(0,"Jacob", "Elmer", "Jacob", "pass", "jacob@mail.com", "jacob.png", 50, null, true, false),
                new Visitor(0,"Elmer", "Randell", "Elmer", "pass", "elmer@mail.com", "elmer.png", 20, null, true, false),
                new Visitor(0,"Einar", "Madigan", "Einar", "pass", "einar@mail.com", "einar.png", 0, null, true, true),
                new Visitor(0,"Ilia", "Nikushev", "Ilia", "pass", "i.nikushev@mail.bg", "ilia.png", 50, null, true, true),
                new Visitor(0,"Georgi", "Chishirkov", "Georgi", "pass", "gChishirkov@mail.bg", "georgi.png", 200, null, true, false),
                new Visitor(0,"Angel", "Doichinov", "Angel", "pass", "aDoichinov@mail.com", "angel.png", 100, null, false, true),
                new Visitor(0,"Mikaeil", "Shaghelani Lor", "Mikaeil", "pass", "m.Shaghelani@mail.com", "mikaeil.png", 33, null, true, true),

                new AdminUser(0, "Leonard", "Abram", "Admin", "pass", "la@hotmail.com"),

                new Employee(0, "Koby", "Nielson", "Shop", "pass", "kNielson@mail.en", Database.Find<ShopWorkplace>("|T|.label = 'FoodAndDrink'"), "cashier"),
                new Employee(0, "Denis", "Hawkins", "ShopManager", "pass", "d.Hawkins@hawk.eye" , Database.Find<ShopWorkplace>("|T|.label = 'FoodAndDrink'"), "shopmanager"),

                new Employee(0, "Piers", "Morin", "Rent", "pass", "pim@mail.en", Database.Find<ITServiceWorkplace>("|T|.label is not null"), "rent"),
                new Employee(0, "Wilburn", "Augustine", "Doctor", "pass", "burn@will.en", Database.Find<PCDoctorWorkplace>("|T|.label is not null"), "pcdoctor"),
                new Employee(0, "Duke", "Forest", "Info", "pass", "dForest@forst.d", Database.Find<InformationKioskWorkplace>("|T|.label is not null"), "information")
            };

            foreach (var item in users)
            {
                Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                    Database.TableFor<User>().Name,
                    "firstName, lastName, email, userName, password, type",
                    "{0}, {1}, {2}, {3}, {4}, {5}".Arg(item.FirstName, item.LastName, item.Email, item.Username, item.Password, item.GetType().Name.ToLower().Replace("user", ""))
                    );
                User x = Database.Find<User>("|T|.userName = {0}", item.Username); 
                if (item is Visitor)
                {
                    Visitor v = item as Visitor;
                    Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                        Database.TableFor<Visitor>().Name,
                        "user_id, balance, ticket, rfid, picture, isInTheEvent",
                        string.Join(",", new object[]{x.ID, v.Balance, v.Ticket, v.RFID, v.Picture, v.IsInTheEvent}.Format()));
                }
                else if (item is AdminUser)
                {
                    
                }
                else if (item is Employee)
                {
                    Employee e = item as Employee;
                    Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                        Database.TableFor<Employee>().Name,
                        "user_id, job, workplace_id",
                        string.Join(",", new object[] { x.ID, e.Duty, e.Workplace.ID }.Format()));
                }
            }

            ShopWorkplace fnd = Database.Find<ShopWorkplace>("|T|.label = 'FoodAndDrink'");

            Item[] items = new Item[]
            {
                new RentableItem(0, 4, "Lenovo", "540", "PC", "rent", "", "", 10),
                new RentableItem(0, 3, "Toshiba", "Satellite", "PC", "rent", "","",3),
                new RentableItem(0, 5, "Mac", "Pro", "PC","rent",  "", "", 5),
                new RentableItem(0, 1, "Charger", "220V", "charger", "rent", "", "", 5),
                new RentableItem(0, 1, "Samsung", "Lite", "tablet", "rent", "", "", 10),
                new RentableItem(0, 1, "Canon", "HD", "camera", "rent", "", "", 10),
                new RentableItem(0, 1, "Sony", "Xperia", "phone", "rent", "", "", 5),
                new RentableItem(0, 0.5m, "Cable", "Lan", "cable", "rent", "", "", 50),
                new RentableItem(0, 0.5m, "Cable", "USB", "cable", "rent", "", "", 50),
                new RentableItem(0, 1, "Mouse", "USB", "misc", "rent", "", "", 50),
                new RentableItem(0, 0.3m, "Keyboard", "USB", "misc", "rent", "", "", 50),
                new RentableItem(0, 0.5m, "FlashDrive", "Slim 5GB","flash", "rent", "","",10),
                new RentableItem(0, 0.5m, "FlashDrive", "Slim 25GB","flash", "rent", "","",10),

                new ShopItem(0, 1, "Lays", "Salted 50g", "chips", "snack", "", "lays-50g.png", 20, -1, fnd, -1),
                new ShopItem(0, 2, "Lays", "Salted 100g", "chips", "snack", "", "lays-100g.png", 20, -1, fnd, -1),
                new ShopItem(0, 3, "Lays", "Salted 200g", "chips", "snack", "", "lays-200g.png", 20, -1, fnd, -1),

                new ShopItem(0, .5m, "Coca-Cola", "small 100ml", "soda", "drink", "", "cc10.png", 20, -1, fnd, -1),
                new ShopItem(0, .75m, "Coca-Cola", "medium 250ml", "soda", "drink", "", "cc25.png", 20, -1, fnd, -1),
                new ShopItem(0, 1, "Coca-Cola", "large 500ml", "soda", "drink", "", "cc50.png", 20, -1, fnd, -1),

                new ShopItem(0, .6m, "Juice", "orange 200", "drink", "drink", "", "jo.png", 20, -1, fnd, -1),
                new ShopItem(0, .6m, "Juice", "blue berry 200", "drink", "drink", "", "jbl.png", 20, -1, fnd, -1),
                new ShopItem(0, .6m, "Juice", "black berry 200", "drink", "drink", "", "jb.png", 20, -1, fnd, -1),

                new ShopItem(0, 1m, "Sandwich", "Ham", "food", "food", "", "sh.png", 20, -1, fnd, -1),
                new ShopItem(0, 1m, "Sandwich", "Cheese", "food", "food", "", "sc.png", 20, -1, fnd, -1),
                new ShopItem(0, .5m, "French Fries", "Salted 100g", "food", "food", "", "ff.png", 20, -1, fnd, -1),
                new ShopItem(0, 1m, "Hot Dog", "Pork", "food", "food", "", "hd.png", 20, -1, fnd, -1),
            };

            foreach (var item in items)
            {
                Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                    Database.TableFor<Item>().Name.Replace("_ALL",""),
                    "Brand, Model, Type, Description, icon",
                    string.Join(",", new object[] { item.Brand, item.Model, item.Type, item.Description, item.Icon.Split('/').Last() }.Format())
                    );
                Item i = Database.Find<Item>("brand = {0} and model = {1}", item.Brand, item.Model);
                if (item is RentableItem)
                {
                    RentableItem r = item as RentableItem;
                    Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                    Database.TableFor<RentableItem>().Name,
                    "item_id, price, inStock",
                    string.Join(",", new object[] { i.ID, r.Price, r.InStock }.Format())
                    );
                }
                else if (item is ShopItem)
                {
                    ShopItem r = item as ShopItem;
                    Database.ExecuteSQL("Insert into {0} ({1}) Values ({2})",
                    Database.TableFor<ShopItem>().Name,
                    "shop_id, quantity, item_id, warningAmount, price",
                    string.Join(",", new object[] { r.Shop.ID, r.InStock, i.ID, -1, r.Price }.Format())
                    );
                }
            }
        }

        static void Main(string[] args)
        {
            Delete();
            Delete();
            Create();
        }
    }
}
