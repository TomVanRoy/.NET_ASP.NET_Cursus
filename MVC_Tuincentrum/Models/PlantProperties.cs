using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC_Tuincentrum.Models
{
    public class PlantProperties
    {
        [Range(0, 1000)]
        public decimal VerkoopPrijs { get; set; }

        [ScaffoldColumn(false)]
        public string Kleur { get; set; }
    }
}