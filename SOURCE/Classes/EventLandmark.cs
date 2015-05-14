using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class EventLandmark : Landmark
    {
        public EventLandmark(int id, string label, string description, int x, int y, System.DateTime timeStart, DateTime timeEnd) : base(id, label, description, x, y) { }

        public DateTime TimeStart
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime TimeEnd
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
