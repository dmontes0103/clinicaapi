using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicaAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private ClinicaContext clinicaContext = new ClinicaContext();

        public bool CreateAppointment(Appointment _appointment)
        {
            if (this.ValidAppointment(_appointment)) return false;
            clinicaContext.Appointments.Add(_appointment);
            clinicaContext.SaveChanges();
            return true;
        }

        public List<Appointment> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetPatientAppointments(int id)
        {
            DateTime date = DateTime.Now;            
            List<Appointment> appointments = clinicaContext.Appointments.Where(x => x.p_id == id && DateTime.Compare(date,x.a_date) < 0)
                .Include( x => x.Appointment_area)
                .OrderBy(x => x.a_date )
                .ToList();
            return appointments;
        }

        public bool RemoveAppointment(int id)
        {
            if (this.CanDeleteAppointment(id))
            {
                Appointment appointment = clinicaContext.Appointments.Find(id);                
                clinicaContext.Appointments.Remove(appointment);
                clinicaContext.SaveChanges();
                return true;
            }
            return false;            
        }

        public bool ValidAppointment(Appointment _appointment)
        {
            DateTime date = _appointment.a_date.Date;
            bool valid = clinicaContext.Appointments.Any(x => x.p_id == _appointment.p_id && (date.Year == x.a_date.Year && date.Month == x.a_date.Month && date.Day == x.a_date.Day));
            return valid;
        }

        public bool CanDeleteAppointment(int id)
        {
            Appointment appointment = clinicaContext.Appointments.Find(id);
            DateTime date = DateTime.Now;
            TimeSpan diff = appointment.a_date - date;
            if (diff.TotalHours < 24)
                return false;
            return true;

        }

        public bool ExistAppointment(Appointment appointment)
        {
            return true;
        }
    }
}