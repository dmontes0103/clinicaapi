using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaAPI.Services
{
    interface IAppointmentService
    {
        List<Appointment> GetAppointments();
        List<Appointment> GetPatientAppointments(int id);
        bool CreateAppointment(Appointment _appointment);
        bool RemoveAppointment(int id);
        bool ValidAppointment(Appointment appointment);
        bool ExistAppointment(Appointment appointment);
    }
}
