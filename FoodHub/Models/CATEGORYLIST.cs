using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class CATEGORYLIST
    {
        public int CATE_CD { get; set; }

        [StringLength(50)]
        public string CATE_NM { get; set; }

        public string CATE_DESC { get; set; }
        public int SLNO { get; set; }
    }
}