using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ShopJob : Job
    {
        public ShopJob(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public List<Classes.PurchasableItem> Items
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Receipt Purchase(string identificator, List<PurchaseSelection> items)
        {
            Visitor user = new Visitor(identificator);
            return Purchase(user, items);
        }

        public Receipt Purchase(Visitor user, List<PurchaseSelection> items)
        {
            //Check if items are in stock -> return those items that are not found
            //Check if he has amount in his account

            //print receipt, send to the database
            return new Receipt(user, this, items);
        }
    }
}
