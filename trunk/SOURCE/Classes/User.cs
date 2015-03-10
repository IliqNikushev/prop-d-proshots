using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string Identificator { get; private set; }
        public bool IsAuthenticated { get { return this.Identificator != null; } }
        public decimal Amount { get; private set; }

        public User(string identificator)
        {
            //Using the database -> 
            //Check if the name is licensed to the identificator and set the data, amount etc
            //else the user is not authenticated
            if (false)
            {

            }
            else
                throw new Exceptions.InvalidUserException();
        }

        public void Hire(HireableItem item)
        {
            //check if has enough in account
        }

        public void Return(HireableItem Item)
        {
            //check if he has this item
        }

        public void ReturnAll()
        {
            //return all items
        }
    }
}
