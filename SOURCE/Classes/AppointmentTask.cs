using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointmentTask : Record
    {
        public AppointmentTask(int id, string name, decimal price, string description, Appointment appointment)
            : base(id)
        {
            this.Appointment = appointment;
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }
        public AppointmentTask(string name, string description, decimal price, Appointment appointment) : this(0, name, price, description, appointment) { }
        [Column("appointment_id")]
        public Appointment Appointment{get; private set;}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public override Record Create()
        {
            return Database.Insert(this, "name,description,price,appointment_id", this.Name, this.Description, this.Price,this.Appointment.ID);
        }

        public override string ToString()
        {
            return Name + " for " + Price + " euros, details: " + Description;
        }
    }
}
