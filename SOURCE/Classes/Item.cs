using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Item : Record
    {
        #region examples
        /*    
         * 0, Lays, Salted 200g, Potato Chips, 1.20
        */
        #endregion

        public int ID { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Type { get; private set; }
        public decimal Price { get; private set; }
        //public Image Icon{get; private set;}
       
        public Item(int id, decimal price, string brand, string model, string type)
        {
            this.ID = id;
            this.Price = price;
            this.Brand = brand;
            this.Model = model;
            this.Type = type;
        }
    }
}
