using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RentableItem : RestockableItem
    {
        public RentableItem(int id, decimal price, string brand, string model, string type, string group,string description, string icon, int inStock)
            : base(id, price, brand, model, type, group,description, icon, inStock)
        {
        }

        public void Rent(Classes.Visitor renter)
        {
            renter.Rent(this);
            RentableItemHistory history = new RentableItemHistory(this, renter);
        }
    }
}
