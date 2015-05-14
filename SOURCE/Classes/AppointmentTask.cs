using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointmentTask : Record
    {
        public AppointmentTask(int id, string name, decimal price, string description, Appointment appointment = null)
        {
            throw new System.NotImplementedException();
        }

        public int ID { get; private set; }
        [Column("appointment_id")]
        public Appointment Appointment{get; private set;}
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
    }
}
