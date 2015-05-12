using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Visitor : User
    {
        public decimal Amount { get; private set; }
        public string RFID { get; private set; }

        public Visitor(string identificator) : base(identificator) { }
        public Visitor(string username, string password) : base(username, password) { }

        public Visitor(int id, string firstName, string lastName, string username, string email, decimal amount, string rfid) : base(id,firstName,lastName,username,email)
        {
            this.RFID = rfid;
            this.Amount = amount;
        }

        public void Rent(RentableItem item)
        {
            //check if has enough in account
        }

        public void Return(RentableItem Item)
        {
            //check if he has this item
        }

        protected override void OnBuildFrom(User user)
        {
            Visitor visitor = user as Visitor;

            //this.amount = visitor.amount
        }
    }
}
