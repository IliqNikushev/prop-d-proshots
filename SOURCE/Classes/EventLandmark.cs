using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class EventLandmark : Landmark
    {
        protected override string Type
        {
            get { return "event"; }
        }

        public EventLandmark(int id, string label, string description, int x, int y, System.DateTime timeStart, DateTime timeEnd) : base(id, label, description, x, y) 
        {
            this.TimeStart = timeStart;
            this.TimeEnd = timeEnd;
        }

        public EventLandmark(string label, string description, int x, int y, DateTime start, DateTime end)
            : base(0, label, description, x, y)
        {
            this.TimeStart = TimeStart;
            this.TimeEnd = TimeEnd;
        }

        public DateTime TimeStart { get; private set; }
        public DateTime TimeEnd { get; private set; }

        public override Record Create()
        {
            Record baseRecord = base.Create();

            return Database.Insert(this, "location, timeStart, timeEnd", baseRecord.ID, this.TimeStart, this.TimeEnd);
        }
    }
}
