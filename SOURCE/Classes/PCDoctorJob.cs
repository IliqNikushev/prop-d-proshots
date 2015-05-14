using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PCDoctorJob : Job
    {
        public PCDoctorJob(int id, int x, int y) : base(id, "PC DOCTOR", "Here you can give your equipment for repair or diagnosis", x, y) { }

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
        }

        public List<Appointment> NotCompletedAppointments
        {
            get
            {
                throw new System.NotImplementedException();
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
