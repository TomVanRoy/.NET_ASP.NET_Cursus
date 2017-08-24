using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_BierenApplication.Models
{
    public class Bier
    {
        [UIHint("FloatKleur")]
        [Range(0, 15, ErrorMessage = "Alcoholpercentage moet tussen {1} en {2} liggen")]
        public float Alcohol { get; set; }

        [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "De naam mag max. {1} karakters zijn")]
        public string Naam { get; set; }
    }
}