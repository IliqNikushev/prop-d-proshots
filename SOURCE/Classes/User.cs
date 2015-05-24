using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class User : Record, IComparable<User>, IEquatable<User>, IEqualityComparer<User>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public int Id { get; private set; }
        public virtual bool IsAuthenticated { get { return this.Id != 0; } }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(int id, string firstName, string lastName, string username,string password, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Username = username;
            this.Email = email;
        }

        public static User Authenticate(string name, string password)
        {
            return Database.GetUser(name, password);
        }

        public static Visitor Authenticate(string id)
        {
            return Database.GetVisitor(id);
        }

        public int CompareTo(User other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(User other)
        {
            return this.Id == other.Id;
        }

        public bool Equals(User x, User y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(User obj)
        {
            return this.Id;
        }
    }
}
