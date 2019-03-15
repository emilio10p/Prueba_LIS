namespace LMCStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Key]
        public int PRODUCT_ID { get; set; }

        [StringLength(30)]
        public string PRODUCT_NAME { get; set; }

        [StringLength(100)]
        public string PRODUCT_REFERENCE { get; set; }

        public int AREA { get; set; }

        public virtual Area Area1 { get; set; }
    }
}
