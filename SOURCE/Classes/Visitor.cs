using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Visitor : User
    {
        public decimal Balance { get; private set; }
        public string RFID { get; private set; }
        public bool Ticket { get; private set; }
        public string Picture { get; private set; }

        public Visitor(int id, string firstName, string lastName, string username, string password, string email, string picture, decimal balance, string rfid, bool ticket)
            : base(id, firstName, lastName, username, password, email)
        {
            this.RFID = rfid;
            this.Balance = balance;
            this.Ticket = ticket;
            this.Picture = picture;
        }

        public void Rent(RentableItem item)
        {
            //check if has enough in account
            throw new NotImplementedException();
        }

        public void Return(RentableItem Item)
        {
            //check if he has this item
            throw new NotImplementedException();
        }

        public void CloseAccount()
        {
            //user no longer will be able to login
            //balance = 0
            //check if all items are returned
            throw new NotImplementedException();
        }

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }

        public void ChangeBalanceTo(decimal amount)
        {
            //execute update
            throw new NotImplementedException();
        }
    }
}
