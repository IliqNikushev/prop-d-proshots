using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class User 
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string Identificator { get; private set; }
        public bool IsAuthenticated { get { return this.Identificator != null; } }

        public string Username
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Password
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public User(string identificator)
        {
            //Using the database -> 
            //Check if the name is licensed to the identificator and set the data, amount etc
            //else the visitor is not authenticated
            if (false)
            {

            }
            else
                throw new Exceptions.InvalidUserException();
        }

        public User(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
