using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ShopItem : RestockableItem
    {
        public ShopJob Shop { get; private set; }
        public int WarningLevel { get; private set; }
        public ShopItem(int id, decimal price, string brand, string model, string type, string group, string description, int inStock, int warningLevel, ShopJob shop)
            : base(id, price, brand, model, type, group,description, inStock)
        {
            this.Shop = shop;
            this.WarningLevel = warningLevel;
        }

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Brand + " " + this.Model;
        }
    }
}
