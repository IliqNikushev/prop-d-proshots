using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ITServiceJob : Job
    {
        public ITServiceJob(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public List<RentableItem> Items
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void RentItem(Visitor visitor, Item item)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnItem(Classes.Visitor visitor, Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
