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

        public void AddEvent()
        {
            throw new System.NotImplementedException();
        }

        public void RestockStore(ShopJob shop, List<RestockItem> items)
        {
            throw new System.NotImplementedException();
        }

        protected override void Create()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
