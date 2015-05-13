using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PurchasableItem : RestockableItem
    {
        public PurchasableItem(int id, decimal price, string brand, string model, string type, int inStock, int warningLevel)
            : base(id, price, brand, model, type, inStock, warningLevel)
        {
        }

        public void Purchase(int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
