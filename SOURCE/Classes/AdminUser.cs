using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AdminUser : User
    {
        public AdminUser(int id, string firstName, string lastName, string username, string password, string email)
            : base(id, firstName, lastName, username,password, email)
        {
        }

        public EventLandmark AddEvent(string name, string description, int x, int y, DateTime start, DateTime end)
        {
            EventLandmark r = new EventLandmark(name, description, x, y, start, end).Create() as EventLandmark;
            if (r != null)
                new LogMessage("create event", "{0} at {1} {2} by {3}({4}) successfuly ".Args(name, x, y, this.FullName, this.ID)).Create();
            else
                new LogMessage("create event", "{0} at {1} {2} by {3}({4}) failed".Args(name, x, y, this.FullName, this.ID)).Create();
            return r;
        }
    }
}
