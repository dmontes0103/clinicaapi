using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaAPI.Services
{
    interface IAreaService
    {
        List<Appointment_area> GetAreas();
    }
}
