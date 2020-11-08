using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class CARTITEMLIST
    {

        public string IMG_FILE { get; set; }
        public int ITEM_CD { get; set; }
        public string ITEM_NM { get; set; }
        public decimal PRICE { get; set; }
        public String QNTY { get; set; }
        public String GSTAMT { get; set; }
        public String TOTALPRICE { get; set; }
        public int CART_ID { get; set; }
        public string IMG { get; set; }

    }
}