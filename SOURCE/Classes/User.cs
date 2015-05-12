using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class User : Record 
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public int Id { get; private set; }
        public virtual bool IsAuthenticated { get { return this.Id != null; } }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        private User(User user)
        {
            if(user == null)
                throw new Exceptions.InvalidUserException();
            BuildFrom(user);
        }

        public User(int id, string firstName, string lastName, string username, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Email = email;
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
            this.Id = user.Id;
            this.Username = user.Username;
            this.Password = user.Password;

            OnBuildFrom(user);
        }

        protected abstract void OnBuildFrom(User user);

        public static User Authenticate(string name, string password)
        {
            return Database.GetUser(name, password);
        }

        public static Visitor Authenticate(string id)
        {
            return Database.GetVisitor(id);
        }
    }
}
