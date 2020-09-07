namespace FoodHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_DETAILS()
        {
            CARTs = new HashSet<CART>();
            ORDERs = new HashSet<ORDER>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string USER_NAME { get; set; }

        [Required]
        public string EMAIL { get; set; }

        [Required]
        [Display(Name ="Password")]
        public string PASSWORD { get; set; }

        public DateTime DOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONTACT_NO { get; set; }

        [Required]
        public string ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string CITY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PIN { get; set; }

        [Required]
        [StringLength(20)]
        public string STATE { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_TYPE { get; set; }

        [Required]
        public string TOKEN { get; set; }

        [Required]
        [StringLength(20)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(6)]
        public string GENDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
    }
}
