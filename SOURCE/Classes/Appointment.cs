using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Appointment : Record
    {
        public Appointment(int id, AppointedItem item, Visitor visitor, DateTime completedOn,DateTime appointedOn, bool isReturned, string status, string description)
            : base(id)
        {
            this.AppointedItem = item;
            this.Visitor = Visitor;
            this.CompletedOn = completedOn;
            this.IsReturned = isReturned;
            this.Description = description;
            this.AppointedOn = appointedOn;
        }

        public Visitor Visitor { get; private set; }
        public AppointedItem AppointedItem { get; private set; }
        public DateTime CompletedOn { get; private set; }
        public DateTime AppointedOn { get; private set; }
        public bool IsReturned { get; private set; }
        public string Description { get; private set; }
        public decimal Price
        {
            get { return Tasks.Sum(x=>x.Price);}
        }
        public string Status
        {
            get { return this.Status; }
        }
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

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
