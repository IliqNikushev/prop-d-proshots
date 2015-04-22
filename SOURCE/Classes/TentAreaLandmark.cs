using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class TentAreaLandmark : Landmark
    {
        public TentAreaLandmark(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public bool Booked
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Tent Tent
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
