using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointedItem : Item
    {
        public AppointedItem(int id, string brand, string model, string type) : base(id, brand, model, type) { }
    }
}
