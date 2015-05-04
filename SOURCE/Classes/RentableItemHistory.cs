using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class RentableItemHistory : Record
    {
        public RentableItemHistory(RentableItem item, Visitor rentedBy)
        {
            this.RentedBy = rentedBy;
            this.RentedAt = DateTime.Today;
            this.ReturnedAt = DateTime.MinValue;
        }

        public RentableItem RentedItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Visitor RentedBy
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime RentedAt { get; private set; }
        public DateTime ReturnedAt { get; private set; }

        public bool IsRented
        {
            get { return this.RentedBy != null; }
        }

        public bool IsReturned { get { return this.IsRented && this.ReturnedAt != DateTime.MinValue; } }

        public void Return(Visitor returnedBy)
        {
            this.RentedBy.Return(this.RentedItem);
            this.RentedBy = null;
            this.ReturnedAt = DateTime.Now;
        }
    }
}
