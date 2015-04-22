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
        public virtual bool IsAuthenticated { get { return this.Identificator != null; } }

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

        private User(User user)
        {
            if(user == null)
                throw new Exceptions.InvalidUserException();
            BuildFrom(user);
        }

        public User(string identificator) : this(Authenticate(identificator))
        {
        }

        public User(string username, string password) : this(Authenticate(username, password))
        {
        }

        private void BuildFrom(User user)
        {
            if (user.GetType() != this.GetType())
                throw new InvalidCastException("User is not of correct type");

            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Identificator = user.Identificator;
            this.Username = user.Username;
            this.Password = user.Password;

            OnBuildFrom(user);
        }

        protected abstract void OnBuildFrom(User user);

        public static User Authenticate(string name, string password)
        {
            User result = null;
            //get from the database the result

            //create the new user, based on the user type in the database
            //result = new Visitor(amount);
            return result;
        }

        public static User Authenticate(string id)
        {
            User result = null;
            //get from the database the result

            //create the new user, based on the user type in the database

            //
            return result;
        }
    }
}
