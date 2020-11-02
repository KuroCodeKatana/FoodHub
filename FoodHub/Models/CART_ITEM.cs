namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CART_ITEM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CI_ID { get; set; }

        public int CART_ID { get; set; }

        public int ITEM_CD { get; set; }

        public int QNTY { get; set; }

        public virtual CART CART { get; set; }
    }
}
