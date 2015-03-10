using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Item
    {
        //public Image Icon{get; private set;}
        private decimal price;
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                    throw new InvalidOperationException("Price cannot be lower or equal to 0. Price was " + value);
                else this.price = value;
            }
        }
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Item(int id, string name, decimal price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
