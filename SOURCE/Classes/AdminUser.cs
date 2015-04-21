using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AdminUser : User
    {
        public AdminUser(string username, string password) : base(username, password) { }

        protected override void OnBuildFrom(User user)
        {
            AdminUser admin = user as AdminUser;

            //apply admin properties
        }
    }
}
