using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Admin : User
    {
        public Admin(string identificator) : base(identificator) { }
        public Admin(string username, string password) : base(username, password) { }
    }
}
