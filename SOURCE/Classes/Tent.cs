using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Tent : Record
    {
        public TentPitch Location { get; private set; }
        public DateTime BookedOn { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime BookedTill { get; private set; }
        public Visitor BookedBy { get; private set; }
        private Visitor[] bookedFor;
        public Visitor[] BookedFor { get { return bookedFor; } }

        public decimal Price
        {
            get
            {
                return 30 + NumberOfPeople * 20;
            }
        }

        public int NumberOfPeople
        {
            get { return BookedFor.Length; }
        }

        public Tent(TentPitch location, DateTime bookedOn, bool isPayed, DateTime bookedTill, Visitor bookedBy, params Visitor[] bookedFor)
            : base(location.ID)
        {
            this.Location = location;
            this.BookedOn = bookedOn;
            this.IsPaid = isPayed;
            this.BookedTill = bookedTill;
            this.BookedBy = bookedBy;
            this.bookedFor = bookedFor;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
