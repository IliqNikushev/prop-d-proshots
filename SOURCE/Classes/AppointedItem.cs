using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointedItem : Item
    {
        public AppointedItem(int id, string brand, string model, string type, string group, string description, string icon) : base(id, brand, model, type, group, description, icon) { }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
