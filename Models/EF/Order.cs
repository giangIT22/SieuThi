namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(256)]
        public string customer_address { get; set; }

        [Required]
        [StringLength(10)]
        public string customer_phone { get; set; }

        [StringLength(256)]
        public string note { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
