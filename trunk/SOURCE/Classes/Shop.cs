using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Shop
    {
        public int Id { get; private set; }
        public Shop(int id)
        {
            //Using the database -> 
            //Check if the store exists and is not logged in
            //else the shop is not valid
            if (false)
            {

            }
            else
                throw new Exceptions.InvalidShopException();
        }

        public Receipt Purchase(string identificator, List<PurchaseSelection> items)
        {
            User user = new User(identificator);
            return Purchase(user, items);
        }

        public Receipt Purchase(User user, List<PurchaseSelection> items)
        {
            //Check if items are in stock -> return those items that are not found
            //Check if he has amount in his account

            //print receipt, send to the database
            return new Receipt(user, this, items);
        }
    }
}
