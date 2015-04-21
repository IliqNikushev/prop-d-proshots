using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Employee : User
    {
        public Employee(string username, string password) : base(username, password) { }

        public Job Job
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        protected override void OnBuildFrom(User user)
        {
            Employee employee = user as Employee;

            //apply employee properties
        }
    }
}
