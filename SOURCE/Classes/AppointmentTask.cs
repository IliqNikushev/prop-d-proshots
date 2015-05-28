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

        [Column("appointment_id")]
        public Appointment Appointment{get; private set;}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

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
