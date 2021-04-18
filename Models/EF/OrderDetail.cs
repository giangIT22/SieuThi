namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int id { get; set; }

        public int orders_id { get; set; }

        public int products_id { get; set; }

        [Required]
        [StringLength(50)]
        public string products_name { get; set; }

        public long products_price { get; set; }

        public int? products_qty { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
