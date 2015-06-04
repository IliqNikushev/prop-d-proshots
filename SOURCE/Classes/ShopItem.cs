using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ShopItem : RestockableItem
    {
        public ShopWorkplace Shop { get; private set; }
        public int WarningLevel { get; private set; }
        public ShopItem(int id, decimal price, string brand, string model, string type, string group, string description, string icon, int inStock, int warningLevel, ShopWorkplace shop)
            : base(id, price, brand, model, type, group, description, icon, inStock)
        {
            this.Shop = shop;
            this.WarningLevel = warningLevel;
        }

        public override string ToString()
        {
            return this.Brand + " " + this.Model;
        }
    }
}
