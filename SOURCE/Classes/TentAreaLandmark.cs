using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class TentPitch : Landmark
    {
        protected override string Type
        {
            get { return "tent"; }
        }

        public TentPitch(int id, int x, int y) : base(id, "Tent #"+id, "A tent location for visitors to stay in", "tent-logo.jpg", x, y) { }

        public bool IsBooked
        {
            get { return this.Tent != null; }
        }

        public Tent Tent
        {
            get
            {
                return Database.GetTent(this);
            }
        }
    }
}
