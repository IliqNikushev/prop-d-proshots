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

        public List<EmployeeAction> Actions
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

        public void Login()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.Login));
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.Logout));
        }

        public void PerformDuty()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.DutyPerformance));
        }

        public void StartBreak()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.BreakStart));
        }

        public void StopBreak()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.BreakEnd));
        }

        public void StartShift()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.ShiftStart));
        }

        public void StopShift()
        {
            throw new System.NotImplementedException();
            this.Actions.Add(new EmployeeAction(this, EmployeeActionType.ShiftEnd));
        }
    }
}
