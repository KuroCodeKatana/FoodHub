using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.ViewModels
{
    public class LoginViewModel
    {
        public USER_DETAILS USER_DETAILS { get; set; }
        public string USER_NAME { get; set; }

        [Display(Name = "Password")]
        public string PASSWORD { get; set; }
    }
}