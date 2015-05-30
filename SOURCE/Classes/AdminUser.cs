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

        public void AddEvent(string name, string description, int x, int y, DateTime start, DateTime end)
        {
            new EventLandmark(name, description, x, y, start, end).Create();
        }

        public void RestockStore(ShopJob shop, List<RestockItem> items)
        {
            throw new System.NotImplementedException();
        }
    }
}
