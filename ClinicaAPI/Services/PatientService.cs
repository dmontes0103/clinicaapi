using ClinicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ClinicaAPI.Services
{
    public class PatientService : IPatientService
    {
        private ClinicaContext clinicaContext = new ClinicaContext();
        public Patient GetPatient(int id)
        {         
            Patient _patient = clinicaContext.Patients.Find(id);
            return _patient;
        }

        public List<Patient> GetPatients()
        {            
            return clinicaContext.Patients.ToList();
        }

        public bool CreatePatient(Patient _patient)
        {
                if (clinicaContext.Patients.Any(p => p.id == _patient.id)) return false;
                clinicaContext.Patients.Add(_patient);
                clinicaContext.SaveChanges();
                return true;                       
        }
        
        public bool PatientExist(int id)
        {
            return clinicaContext.Patients.Count(e => e.id == id) > 0;
        }

        public bool AuthenticatePatient(Login login)
        {
            var validPatient = clinicaContext.Patients.FirstOrDefault(p => p.id == login.id && p.password == login.password);
            if (validPatient != null)
                return true;
            return false;
        }
    }
}