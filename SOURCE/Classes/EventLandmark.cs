using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class EventLandmark : Landmark
    {
        public EventLandmark(int id, string label, string description, int x, int y, System.DateTime timeStart, DateTime timeEnd) : base(id, label, description, x, y) 
        {
            this.TimeStart = timeStart;
            this.TimeEnd = timeEnd;
        }

        public DateTime TimeStart { get; private set; }
        public DateTime TimeEnd { get; private set; }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
