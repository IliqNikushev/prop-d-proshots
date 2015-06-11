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
        private string picture;
        public string Picture
        {
            get
            {
                //if (!picture.StartsWith("http"))
                    //return Database.PathToAthenaUploads + picture;
                    return picture;
                return picture;
            }
            set { this.picture = value; }
        }

        public Visitor(int id, string firstName, string lastName, string username, string password, string email, string picture, decimal balance, string rfid, bool ticket)
            : base(id, firstName, lastName, username, password, email)
        {
            this.RFID = rfid;
            this.Balance = balance;
            this.Ticket = ticket;
            this.Picture = picture;
        }

        public Receipt ActiveOrder(ShopWorkplace shop)
        {
            IEnumerable<Receipt> result = Database.Where<Receipt>("postponed = 1 and user_id = {0}", this.ID);
            result = result.Where(x => x.Shop == shop);
            return result.LastOrDefault();
        }

        public List<Deposit> TopUps { get { return Database.GetVisitorTopUps(this); } }
        public List<RentableItemHistory> RentedItems { get { return Database.GetVisitorRentedItems(this); } }
        public List<ReceiptItem> PurchasedItems { get { return Database.GetVisitorPurchases(this); } }
        public List<Receipt> Receipts { get { return Classes.Database.GetVisitorReceipts(this); } }
        public List<Tent> BookedTents { get { return Database.GetTentsBookedByVisitor(this); } }
        public List<Tent> BookedInTents { get { return Database.GetTentsBookedForVisitor(this); } }
        public List<Appointment> Appointments { get { return Database.GetVisitorAppointments(this); } }

        public Tent Book(TentPitch pitch, List<Visitor> visitors, DateTime bookedOn)
        {
            //check if has enough in account
            return new Tent(pitch, "{0}".Arg(bookedOn), "{0}".Arg(Classes.Constants.EventEnd), this, visitors);
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
            int Count = 0;
            foreach (RentableItemHistory I in RentedItems)
	{
		 Count += 1;
	}
                if (Count == 0)
            {
                Database.Delete(this, "Visitors.user_id = " + this.ID);
            }
            else
            {
                throw new Exception("Cannot close account, the visitor has some unreturned items!");
            }
            //balance = 0
            //check if all items are returned
        }

        public void ChangeBalanceWith(decimal amount, string reason)
        {
            this.ChangeBalanceTo(this.Balance + amount, reason);
        }

        public void ChangeBalanceTo(decimal amount, string reason)
        {
            if (amount < 0) throw new InvalidOperationException("Balance cannot be negative");

            Database.Update(this, "balance = {0}".Arg(amount), "|T|.user_id = {0}".Arg(this.ID));
            new LogMessage("change balance", this.ID + " " + reason).Create();
        }

        public void PayTicket(decimal VisitorBalance,decimal Price)
        {

                decimal EndBalance = 0;
                if (VisitorBalance >= Price)
                {
                    EndBalance = VisitorBalance - Price;
                
                Database.Update(this, "Balance = " + EndBalance.ToString(), "visitors.user_id = " + this.ID);
                Database.Update(this, "Ticket = 1", "visitors.user_id = " + this.ID);
                    }
                else
                {
                    throw new Exception ("User doesn't have enough money!");
                }
            
        }
    }
}
