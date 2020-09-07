using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClinicaAPI.Models;
using ClinicaAPI.Services;
using Newtonsoft.Json;

namespace ClinicaAPI.Controllers
{
    public class AppointmentsController : ApiController
    {
        private AppointmentService appointmentService = new AppointmentService();

        // GET: api/Appointments
        public IEnumerable<Appointment> GetAppointments()
        {
            return appointmentService.GetAppointments();
        }

        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public IEnumerable<Appointment> GetAppointment(int id)
        {
            List<Appointment> appointment = appointmentService.GetPatientAppointments(id); //db.Appointments.Find(id);
            //if (appointment.Count < 0)
            //{
            //    return NotFound();
            //}
            return appointment;
        }

        // PUT: api/Appointments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            return null;
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != appointment.id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(appointment).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AppointmentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Appointments
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage PostAppointment([FromBody] Appointment appointment)
        {
            if (appointment != null)
            {
                //var oAppointment = JsonConvert.DeserializeObject<Appointment>(appointment.ToString());
                bool status = appointmentService.CreateAppointment(appointment);
                if (status)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.Created, appointment);
                }
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.Ambiguous);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage DeleteAppointment(int id)
        {
            bool status = appointmentService.RemoveAppointment(id);
            if (status)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Accepted, id);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);            
            //Appointment appointment = db.Appointments.Find(id);
            //if (appointment == null)
            //{
            //    return NotFound();
            //}

            //db.Appointments.Remove(appointment);
            //db.SaveChanges();

            //return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        { 
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}