using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.ViewModels
{
    public class CategoryEntry
    {
        public CATEGORY CATEGORY { get; set; }

        public List<CATEGORYLIST> CATEGORYLIST { get; set; }

    }
}