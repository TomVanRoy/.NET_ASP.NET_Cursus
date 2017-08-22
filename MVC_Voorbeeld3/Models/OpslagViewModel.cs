using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Voorbeeld3.Models
{
    public class OpslagViewModel
    {
        [Display(Name = "Van wedde:")]
        public decimal VanWedde { get; set; }

        [Display(Name = "Tot wedde:")]
        public decimal TotWedde { get; set; }

        [Display(Name = "Percentage:")]
        public decimal Percentage { get; set; }
    }
}