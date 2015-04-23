using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PCDoctorJob : Job
    {
        public PCDoctorJob(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public List<Appointment> Appointments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Appointment> NotReturnedAppointments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Appointment> NotCompletedAppointments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void AddAppointment(string visitor, AppointedItem item)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnItemToVisitor(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }

        public void CompleteAppointment(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }

        public void AddTaskToAppointment(Appointment Appointment, AppointmentTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}
