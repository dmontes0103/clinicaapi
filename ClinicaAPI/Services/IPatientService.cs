using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaAPI.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        bool CreatePatient(Patient _patient);
        bool AuthenticatePatient(Login _patient);
    }
}
