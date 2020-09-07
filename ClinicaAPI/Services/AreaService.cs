using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaAPI.Services
{
    public class AreaService : IAreaService
    {
        private ClinicaContext db = new ClinicaContext();

        public List<Appointment_area> GetAreas()
        {
            List<Appointment_area> areas = new List<Appointment_area> { };
            areas = db.Appointment_Areas.ToList();
            return areas;
        }
    }
}