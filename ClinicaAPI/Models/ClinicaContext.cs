using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicaAPI.Models
{
    public class ClinicaContext: DbContext
    {
        public ClinicaContext(): base()
        {           
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Appointment_area> Appointment_Areas { get; set; }
    }
}