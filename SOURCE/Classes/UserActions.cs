using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class UserAction : Record
    {
        public UserAction(User user, string action) : this(0, DateTime.Now, user, action) {}
        
        public UserAction(int id, DateTime date, User user, string action)
            : base(id)
        {
            this.Date = date;
            this.User = user;
            this.Action = action;
        }

        public User User { get; private set; }
        public DateTime Date { get; private set; }

        public string Action{get; private set;}

        public override Record Create()
        {
            return Database.Insert(this, "user_id, date, action", this.User.ID, this.Date, this.Action);
        }
    }
}
