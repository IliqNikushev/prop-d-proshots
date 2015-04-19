using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Employee : User
    {
        public Employee(string identificator) : base(identificator) { }
        public Employee(string username, string password) : base(username, password) { }

        public EmploymentPlace EmploymentPlace
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
