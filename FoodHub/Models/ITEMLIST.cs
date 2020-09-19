using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class ITEMLIST
    {
        public int ITEM_CD { get; set; }

        
        public string ITEM_NM { get; set; }

        
        public string ITEM_DESC { get; set; }

        
        public string IMG { get; set; }

        
        public decimal PRICE { get; set; }

       
        public string STATUS { get; set; }

        public int CATE_CD { get; set; }

       
        public string ITEM_TYPE { get; set; }

        public int SLNO { get; set; }
    }
}