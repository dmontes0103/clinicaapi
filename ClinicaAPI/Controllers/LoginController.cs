using ClinicaAPI.Models;
using ClinicaAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ClinicaAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET: Login

        private PatientService patientService = new PatientService();
        
        public HttpResponseMessage Post([FromBody] Login  _creds)
        {
            //var oCreds = JsonConvert.DeserializeObject<Login>(_creds.ToString());
            bool validUser = patientService.AuthenticatePatient(_creds);
            if (validUser)
            {
                var guid = (Guid.NewGuid());
                return Request.CreateResponse(System.Net.HttpStatusCode.Created,guid.ToString());
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
        }


    }
}