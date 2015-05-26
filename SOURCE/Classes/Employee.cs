using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Employee : User
    {
        public Employee(int id, string firstName, string lastName, string username, string password, string email, Job job)
            : base(id, firstName, lastName, username, password, email)
        {
            this.Job = job;
        }

        public Job Job { get; private set; }

        public List<EmployeeAction> Actions
        {
            get { return Database.GetEmployeeActions(this); }
        }

        public void Login()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.Login));
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.Logout));
        }

        public void PerformDuty()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.DutyPerformance));
        }

        public void StartBreak()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.BreakStart));
        }

        public void StopBreak()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.BreakEnd));
        }

        public void StartShift()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.ShiftStart));
        }

        public void StopShift()
        {
            throw new System.NotImplementedException();
            //this.Actions.Add(new EmployeeAction(this, EmployeeActionType.ShiftEnd));
        }

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
