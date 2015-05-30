using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class RentableItemHistory : Record
    {
        [Column("item_id")]
        public RentableItem RentedItem { get; private set; }
        public Visitor RentedBy { get; private set; }
        public DateTime RentedAt { get; private set; }
        public string Notes { get; private set; }
        public DateTime ReturnedAt { get; private set; }
        public DateTime RentedTill { get; private set; }
        public Visitor ReturnedBy { get; private set; }
        public bool IsOverdue { get { return DateTime.Now > RentedTill; } }

        public bool IsRented
        {
            get { return this.ReturnedBy != null; }
        }

        public bool IsReturned { get { return this.IsRented && this.ReturnedAt != DateTime.MinValue; } }

        public RentableItemHistory(int id, RentableItem item, Visitor rentedBy, Visitor returnedBy, DateTime rentedAt, DateTime returnedAt, DateTime rentedTill, string notes) : base(id)
        {
            this.RentedItem = item;
            this.RentedBy = rentedBy;
            this.RentedAt = rentedAt;
            this.ReturnedAt = returnedAt;
            this.ReturnedBy = ReturnedBy;
            this.RentedTill = RentedTill;
            this.Notes = notes;
        }

        public RentableItemHistory(RentableItem item, Visitor rentedBy, string notes = "") : this(0, item,rentedBy, null, DateTime.Today, DateTime.MinValue, DateTime.Today, notes)
        {
        }

        public void Return(Visitor returner, string notes = "")
        {
            this.RentedBy = returner;
            this.ReturnedAt = DateTime.Now;
            this.Notes += notes;
            throw new NotImplementedException();

            //update
        }

        public void ExtendPeriod(Visitor visitor, int days, int hours, int minutes, string reason = "")
        {
            throw new NotImplementedException();
        }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
