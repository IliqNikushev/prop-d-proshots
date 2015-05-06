using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class RestockableItem : Item
    {
        public int InStock
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public decimal Price
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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

        public RestockableItem(int id, decimal price, string brand, string model, string type, int inStock)
            : base(id, brand, model, type)
        {
            this.Price = price;
            this.InStock = InStock;
        }
    }
}
