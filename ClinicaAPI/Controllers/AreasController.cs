using ClinicaAPI.Models;
using ClinicaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ClinicaAPI.Controllers
{
    public class AreasController : ApiController
    {
        private AreaService areaService = new AreaService();
        // GET: Areas
        public IEnumerable<Appointment_area> Get()
        {
            return this.areaService.GetAreas();            
        }
    }
}