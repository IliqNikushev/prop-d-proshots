﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PCDoctorWorkplace : Workplace
    {
        protected override string Type
        {
            get { return "doctor"; }
        }

        public PCDoctorWorkplace(int id, int x, int y) : base(id, "PC DOCTOR", "Here you can give your equipment for repair or diagnosis", "pc-doctor-logo.jpg", x, y) { }

        public List<Appointment> Appointments
        {
            get { return Database.Appointments; }
        }

        public List<Appointment> NotReturnedAppointments
        {
            get
            {
                return Database.Where<Appointment>("Appointments.isReturned = 1");
            }
        }

        public List<Appointment> NotCompletedAppointments
        {
            get
            {
                return Database.Where<Appointment>("Appointments.completedOn is NULL");
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
