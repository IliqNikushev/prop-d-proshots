using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ITServiceWorkplace : Workplace
    {
        protected override string Type
        {
            get { return "it"; }
        }

        public ITServiceWorkplace(int id, int x, int y) : base(id, "Rent desk", "Here you can rent an item", "it-logo.jpg", x, y) { }

        public List<RentableItem> Items
        {
            get
            {
                return Database.All<RentableItem>();
            }
        }

        public void RentItem(Visitor visitor, Item item)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnItem(Classes.Visitor visitor, Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
