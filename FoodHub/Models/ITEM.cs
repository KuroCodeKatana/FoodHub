namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            FEEDBACKs = new HashSet<FEEDBACK>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ITEM_CD { get; set; }

        [Required]
        [StringLength(50)]
        public string ITEM_NM { get; set; }

        [Required]
        public string ITEM_DESC { get; set; }

        [Required]
        public string IMG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PRICE { get; set; }

        [Required]
        [StringLength(50)]
        public string STATUS { get; set; }

        public int CATE_CD { get; set; }

        [Required]
        [StringLength(10)]
        public string ITEM_TYPE { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }
    }
}
