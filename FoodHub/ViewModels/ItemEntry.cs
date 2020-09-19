using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.ViewModels
{
    public class ItemEntry
    {
        public ITEM ITEM { get; set; }
        public List<ITEMLIST> ITEMLIST { get; set; }
    }
}