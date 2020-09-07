using ClinicaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using ClinicaAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace ClinicaAPI.Controllers
{
    public class PatientController : ApiController
    {
        // GET: Patient
        private PatientService patientService = new PatientService();
        public IEnumerable<Patient> Get()
        {
            return patientService.GetPatients();            
        }

        public IHttpActionResult GetPatient(int id)
        {
            var patient = patientService.GetPatient(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);

        }

        public HttpResponseMessage PostPatient([FromBody]Patient patient)
        {
            //var oPatient = JsonConvert.DeserializeObject<Patient>(patient.ToString());
            bool status = patientService.CreatePatient(patient);
            if (status)
            {                
                return Request.CreateResponse(System.Net.HttpStatusCode.Created, patient);
            }           
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

        }


    }
}