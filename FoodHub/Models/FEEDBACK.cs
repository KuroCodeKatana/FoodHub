namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FEEDBACK")]
    public partial class FEEDBACK
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FB_ID { get; set; }

        public int ORDER_ID { get; set; }

        public int ITEM_CD { get; set; }

        public int RATING { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
