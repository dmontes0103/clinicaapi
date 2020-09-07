namespace ClinicaAPI.Migrations
{
    using ClinicaAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClinicaAPI.Models.ClinicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClinicaAPI.Models.ClinicaContext context)
        {

            context.Patients.AddOrUpdate(x => x.id,
                new Patient { id = 1, name= "Daniel", lastname="Montes", sex="M", phone=875555, admin=true, password="admin" },
                new Patient { id = 2, name = "Juan", lastname = "Lopez", sex = "M", phone = 875555, admin = false, password="user" },
                new Patient { id = 3, name = "Rebeca", lastname = "Gonzales", sex = "F", phone = 875555, admin = false, password="user" }
            );

            context.Appointment_Areas.AddOrUpdate(x => x.id,
                new Appointment_area { id = 1, name = "Medicina General" },
                new Appointment_area { id = 2, name = "Odontologia" },
                new Appointment_area { id = 3, name = "Pediatria" },
                new Appointment_area { id = 4, name = "Neurologia" }
            );           

            context.Appointments.AddOrUpdate(x => x.id,
                new Appointment { p_id=1, area_id=1, a_date= DateTime.Now },
                new Appointment { p_id=1, area_id=2, a_date= DateTime.Now },
                new Appointment { p_id=1, area_id=3, a_date= DateTime.Now.AddDays(3)},

                new Appointment { p_id = 2, area_id = 1, a_date = DateTime.Now.AddDays(3) },
                new Appointment { p_id = 2, area_id = 2, a_date = DateTime.Now.AddDays(3) },
                new Appointment { p_id = 2, area_id = 3, a_date = DateTime.Now.AddDays(3) },

                new Appointment { p_id = 3, area_id = 1, a_date = DateTime.Now.AddDays(3) },
                new Appointment { p_id = 3, area_id = 2, a_date = DateTime.Now.AddDays(3) },
                new Appointment { p_id = 3, area_id = 3, a_date = DateTime.Now.AddDays(3) }
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
