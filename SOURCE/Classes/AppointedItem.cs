using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointedItem : Item
    {
        public AppointedItem(int id, decimal price, string brand, string model, string type) : base(id, price, brand, model, type) { }
    }
}
