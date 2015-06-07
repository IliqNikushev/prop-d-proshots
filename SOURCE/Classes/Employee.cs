using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Employee : User
    {
        public Employee(int id, string firstName, string lastName, string username, string password, string email, Workplace workplace, string duty)
            : base(id, firstName, lastName, username, password, email)
        {
            this.Duty = duty;
            this.Workplace = workplace;
        }

        public Workplace Workplace { get; private set; }
        public string Duty { get; private set; }

        public UserAction PerformDuty(string details)
        {
            return new UserAction(this, "duty " + details).Create() as UserAction;
        }

        public UserAction StartBreak()
        {
            return new UserAction(this, "start break").Create() as UserAction;
        }

        public UserAction StopBreak()
        {
            return new UserAction(this, "stop break").Create() as UserAction;
        }

        public UserAction StartShift()
        {
            return new UserAction(this, "start shift").Create() as UserAction;
        }

        public UserAction StopShift()
        {
            return new UserAction(this, "stop shift").Create() as UserAction;
        }
    }
}
