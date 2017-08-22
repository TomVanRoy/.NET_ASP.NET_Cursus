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
        public float Alcohol { get; set; }

        [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }

        public string Naam { get; set; }
    }
}