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
        public Visitor[] BookedFor
        {
            get
            {
                if (bookedFor == null)
                    bookedFor = Database.Where<TentPerson>("|T|.tent_id = {0}", this.ID).Select(x => x.Visitor).ToArray();
                return bookedFor;
            }
        }

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

        public Tent(TentPitch location, DateTime bookedOn, bool isPayed, DateTime bookedTill, Visitor bookedBy, int id = -1)
            : base(id == -1 ? location.ID : id)
        {
            this.Location = location;
            this.BookedOn = bookedOn;
            this.IsPaid = isPayed;
            this.BookedTill = bookedTill;
            this.BookedBy = bookedBy;

            this.bookedFor = new Visitor[] { };
        }

        public Tent(TentPitch location, string bookedOn, string bookedTill, Visitor bookedBy, List<Visitor> bookedFor)
            : this(location,
            new DateTime(2015, 6, int.Parse(bookedOn.Split(',').Last())),
            false, 
            new DateTime(2015, 6, int.Parse(bookedTill.Split(',').Last())),
            bookedBy, 0)
        {
            this.bookedFor = bookedFor.ToArray();
        }

        public void Cancel()
        {
            Database.Delete<TentPerson>("|T|.tent_id = {0}", this.ID);
            Database.Delete(this, "|T|.location = {0}", this.ID);
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public override Record Create()
        {
            Tent result = Database.Insert(this, "location, bookedOn, bookedTill, bookedBy",
                this.Location.ID, this.BookedOn, this.BookedTill, this.BookedBy.ID) as Tent;
            if (result != null)
                if(result.ID == result.Location.ID)
                    foreach (var item in this.bookedFor)
                        new TentPerson(item, this).Create();
            return result;
        }
    }
}
