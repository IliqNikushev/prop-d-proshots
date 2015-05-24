using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Tent : Record
    {
        public TentAreaLandmark Location { get; private set; }
        public DateTime BookedOn { get; private set; }
        public bool IsPayed { get; private set; }
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

        public Tent(TentAreaLandmark location, DateTime bookedOn, bool isPayed, DateTime bookedTill, Visitor bookedBy, params Visitor[] bookedFor)
        {
            this.Location = location;
            this.BookedOn = bookedOn;
            this.IsPayed = isPayed;
            this.BookedTill = bookedTill;
            this.BookedBy = bookedBy;
            this.bookedFor = bookedFor;
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
