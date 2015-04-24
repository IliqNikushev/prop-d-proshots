using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AdminUser : User
    {
        public AdminUser(string username, string password) : base(username, password) { }

        public AdminUser(string id, string firstName, string lastName, string username, string email)
            : base(id, firstName, lastName, username, email)
        {
        }

        protected override void OnBuildFrom(User user)
        {
            AdminUser admin = user as AdminUser;

            //apply admin properties
        }

        public void AddEvent()
        {
            throw new System.NotImplementedException();
        }

        public void RestockStore(ShopJob shop, List<RestockSelection> items)
        {
            throw new System.NotImplementedException();
        }
    }
}
