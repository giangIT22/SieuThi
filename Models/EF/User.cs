namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }
    }
}
