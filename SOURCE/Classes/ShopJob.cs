using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ShopJob : Job
    {
        public ShopJob(int id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public List<Classes.ShopItem> Items
        {
            get
            {
                return Database.Where<Classes.ShopItem>("shop_id = {0}", this.ID);
            }
        }

        public Receipt Purchase(string identificator, List<ReceiptItem> items)
        {
            Visitor user = Visitor.Authenticate(identificator);
            return Purchase(user, items);
        }

        public Receipt Purchase(Visitor user, List<ReceiptItem> items)
        {
            //Check if items are in stock -> return those items that are not found
            //Check if he has amount in his account

            //print receipt, send to the database
            //return new Receipt(user, this, items);
            return null;
        }
    }
}
