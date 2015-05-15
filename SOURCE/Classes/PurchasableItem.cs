using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PurchasableItem : RestockableItem
    {
        public PurchasableItem(int id, decimal price, string brand, string model, string type, string description, int inStock)
            : base(id, price, brand, model, type, description, inStock)
        {
        }
    }
}
