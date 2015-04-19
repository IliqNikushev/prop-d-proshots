using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Visitor : User
    {
        public decimal Amount { get; private set; }

        public Visitor(string identificator) : base(identificator) { }
        public Visitor(string username, string password) : base(username, password) { }

        public void Hire(RentableItem item)
        {
            //check if has enough in account
        }

        public void Return(RentableItem Item)
        {
            //check if he has this item
        }
    }
}
