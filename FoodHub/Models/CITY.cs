namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CITY")]
    public partial class CITY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CITY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CITY_NAME { get; set; }

        public int STATE_ID { get; set; }

        public virtual STATE STATE { get; set; }
    }
}
