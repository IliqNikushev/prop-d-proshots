using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ShopWorkplace : Workplace
    {
        protected override string Type
        {
            get { return "shop"; }
        }

        public ShopWorkplace(int id, string label, string description, string logo, int x, int y) : base(id, label, description, logo, x, y) { }

        public List<Classes.ShopItem> Items
        {
            get
            {
                return Database.Where<Classes.ShopItem>("ShopItems.shop_id = {0}", this.ID);
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
            throw new NotImplementedException();
        }
    }
}
