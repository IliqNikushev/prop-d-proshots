using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AdminUser : User
    {
        public AdminUser(int id, string firstName, string lastName, string username, string password, string email)
            : base(id, firstName, lastName, username,password, email)
        {
        }

        public EventLandmark AddEvent(string name, string description, int x, int y, DateTime start, DateTime end)
        {
            EventLandmark r = new EventLandmark(name, description, x, y, start, end).Create() as EventLandmark;
            if (r != null)
                new LogMessage("create event", name +" "+ x + " " + y + " success " + this.ID + " => " + r.ID).Create();
            else
                new LogMessage("create event", name +" "+ x + " " + y + " fail " + this.ID + " => " + name).Create();
            return r;
        }

        public void RestockStore(ShopWorkplace shop, List<RestockItem> items)
        {
            foreach (var item in items)
                item.Create();
            
            new LogMessage("restock store", shop.ID + " " + string.Join(" ", items.Select(x=>x.Item.ID + " " + x.Times))).Create();
        }
    }
}
