using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Appointment : Record
    {
        public Appointment(int id, AppointedItem item, Visitor visitor, DateTime completedOn,DateTime appointedOn, bool isReturned, bool status, string description)
            : base(id)
        {
            this.AppointedItem = item;
            this.Visitor = visitor;
            this.CompletedOn = completedOn;
            this.IsReturned = isReturned;
            this.Description = description;
            this.AppointedOn = appointedOn;
            this.Status = status;
        }
        public Appointment(AppointedItem item, Visitor visitor, string description) : this(0, item, visitor, DateTime.MaxValue, DateTime.Now, false, false, description) { }

        public Visitor Visitor { get; private set; }
        public AppointedItem AppointedItem { get; private set; }
        public DateTime CompletedOn { get; private set; }
        public DateTime AppointedOn { get; private set; }
        public bool IsReturned { get; private set; }
        public bool Status { get; private set; }
        public string Description { get; private set; }
        public decimal Price
        {
            get { return Tasks.Sum(x=>x.Price);}
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

        public AppointmentTask AddTask(string name, string description, decimal price)
        {
            return new AppointmentTask(name, description, price, this).Create() as AppointmentTask;
        }

        public override Record Create()
        {
            return Database.Insert(this,"appointed_item,appointed_by,description, appointedOn",this.AppointedItem.ID,Visitor.ID,Description, DateTime.Now);
        }
        public void Complete()
        {
            Database.Update(this, "completedon = {0}, status = 1".Arg(DateTime.Now),"|T|.ID = {0}".Arg(this.ID));
        }

        public override string ToString()
        {
            return Visitor.ToString() + " scheduled their " + AppointedItem + " on " + AppointedOn.ToString("dd, at HH:mm, ") +" ({0} tasks for {1}{2})".Args(this.Tasks.Count, this.Price, Constants.Currency);
        }
    }
}
