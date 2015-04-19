using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PurchasableItem : Item
    {
        public PurchasableItem(int id, decimal price, string brand, string model, string type) : base(id, price, brand, model, type)
        {
        }
    }
}
