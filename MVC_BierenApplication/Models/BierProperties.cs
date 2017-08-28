using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_BierenApplication.Models
{
    public class BierProperties
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int BierNr { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Naam { get; set; }

        [UIHint("FloatKleur")]
        [AlcoholGrenzen(ErrorMessage = "{0} heeft een ongeldige waarde")]
        public float Alcohol { get; set; }
    }
}