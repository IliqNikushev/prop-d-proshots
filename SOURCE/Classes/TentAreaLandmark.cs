using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class TentPitch : Landmark
    {
        public TentPitch(int id, int x, int y) : base(id, "Tent #"+id, "A tent location for visitors to stay in", x, y) { }

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

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
