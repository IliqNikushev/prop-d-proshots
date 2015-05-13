using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Appointment : Record
    {
        public Appointment(AppointedItem item, Visitor visitor)
        {
            throw new System.NotImplementedException();
        }
    
        public Visitor Visitor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public AppointedItem AppointedItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<AppointmentTask> Tasks
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime CompletedOn
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool Returned
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void UpdateTask(Classes.AppointmentTask task, string name, string description, string price)
        {
            throw new System.NotImplementedException();
        }

        public void AddTask(string name, string description, string price)
        {
            throw new System.NotImplementedException();
        }
    }
}
