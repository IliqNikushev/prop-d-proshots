using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class RestockableItem : Item
    {
        public int InStock { get;private set;}
        public decimal Price { get; private set; }

        public void Restock(int amount)
        {
            this.InStock += amount;

            Database.Update(this, "quantity = " + this.InStock, "|T|.id = " + this.ID);
        }

        public void Deplete(int amount)
        {
            if (amount > this.InStock)
                throw new NotImplementedException();
            this.InStock -= amount;

            Database.Update(this, "quantity = {0}".Arg(this.InStock), "|T|.id = {0}".Arg(this.ID));
        }

        public RestockableItem(int id, decimal price, string brand, string model, string type, string group, string description, string icon, int inStock)
            : base(id, brand, model, type, group, description, icon)
        {
            this.Price = price;
            this.InStock = inStock;
        }
    }
}
