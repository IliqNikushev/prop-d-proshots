﻿using System;
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

        public List<Deposit> TopUps { get { return Database.GetVisitorTopUps(this); } }
        public List<RentableItemHistory> RentedItems { get { return Database.GetVisitorRentedItems(this); } }
        public List<ReceiptItem> PurchasedItems { get { return Database.GetVisitorPurchases(this); } }
        public List<Receipt> Receipts { get { return Classes.Database.GetVisitorReceipts(this); } }
        public List<Tent> BookedTents { get { return Database.GetTentsBookedByVisitor(this); } }
        public List<Tent> BookedInTents { get { return Database.GetTentsBookedForVisitor(this); } }

        public void Book(Tent tent)
        {
            //check if has enough in account
            throw new NotImplementedException();
        }

        public void Rent(RentableItem item)
        {
            //check if has enough in account
            throw new NotImplementedException();
        }

        public void ExtendRentedItem(RentableItemHistory Item, int minutes)
        {
            int hours = minutes / 60;
            if (hours > 0)
                minutes -= hours * 60;
            int days = hours / 24;
            if (days > 0) hours -= days * 24;

            Extend(Item, days, hours, minutes);
        }

        public void Extend(RentableItemHistory Item, int days, int hours, int minutes, string reason = "")
        {
            Item.ExtendPeriod(this, days, hours, minutes, reason);
        }

        public void Return(RentableItemHistory Item, string notes = "")
        {
            Item.Return(this, notes);
        }

        public void CloseAccount()
        {
            //user no longer will be able to login
            //balance = 0
            //check if all items are returned
            throw new NotImplementedException();
        }

        protected override void Create()
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
