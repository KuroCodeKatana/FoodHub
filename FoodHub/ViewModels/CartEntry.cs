using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.ViewModels
{
    public class CartEntry
    {
        public List<CARTITEMLIST> CARTITEMLIST { get; set; }
        public int CART_ID { get; set; }
    }
}