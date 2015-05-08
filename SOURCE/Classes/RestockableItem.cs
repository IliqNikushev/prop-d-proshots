using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class RestockableItem : Item
    {
        public int InStock { get;private set;}
        public int WarningLevel { get; private set; }
        public decimal Price { get; private set; }

        public void Restock(int amount)
        {
            this.InStock += amount;
        }

        public void Deplete(int amount)
        {
            if (amount > this.InStock)
                throw new NotImplementedException();
            this.InStock -= amount;
        }

        public RestockableItem(int id, decimal price, string brand, string model, string type, int inStock, int warningLevel)
            : base(id, brand, model, type)
        {
            this.Price = price;
            this.InStock = inStock;
            this.WarningLevel = warningLevel;
        }
    }
}
