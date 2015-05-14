using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Appointment : Record
    {
        public Appointment(int id, AppointedItem item, Visitor visitor, DateTime completedOn, bool isReturned)
        {
            this.ID = id;
            this.AppointedItem = item;
            this.Visitor = Visitor;
            this.CompletedOn = completedOn;
            this.IsReturned = isReturned;
        }

        public int ID { get; private set; }
        public Visitor Visitor { get; private set; }
        public AppointedItem AppointedItem { get; private set; }
        public DateTime CompletedOn { get; private set; }
        public bool IsReturned { get; private set; }

        public List<AppointmentTask> Tasks
        {
            get
            {
                return Database.Where<AppointmentTask>("AppointmentTasks.appointment_id = {0}", this.ID);
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
