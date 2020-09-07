namespace ClinicaAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string lastname { get; set; }

        public int? phone { get; set; }

        [StringLength(1)]
        public string sex { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public bool? admin { get; set; }

    }
}
