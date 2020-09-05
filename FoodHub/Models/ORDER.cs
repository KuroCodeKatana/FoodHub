namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            FEEDBACKs = new HashSet<FEEDBACK>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDER_ID { get; set; }

        public int USER_ID { get; set; }

        public int CART_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AMOUNT { get; set; }

        public DateTime START_TIME { get; set; }

        public DateTime END_TIME { get; set; }

        [Required]
        [StringLength(50)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(50)]
        public string REMARKS { get; set; }

        public virtual CART CART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }

        public virtual USER_DETAILS USER_DETAILS { get; set; }
    }
}
