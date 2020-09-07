namespace ClinicaAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Appointment")]
    public partial class Appointment
    {
        public int id { get; set; }

        public int p_id { get; set; }
        [ForeignKey("p_id")]
        public virtual Patient Patient { get; set; }

        public DateTime a_date { get; set; }

        public int area_id { get; set; }
        [ForeignKey("area_id")]
        public virtual Appointment_area Appointment_area { get; set; }

    }
}
