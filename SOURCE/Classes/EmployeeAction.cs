using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class EmployeeAction : Record
    {
        public EmployeeAction(int id, DateTime date, Employee employee, string action)
            : base(id)
        {
            this.Date = date;
            this.Employee = employee;
            this.Action = action;
        }

        public Employee Employee { get; private set; }
        public DateTime Date { get; private set; }

        public string Action{get; private set;}

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
