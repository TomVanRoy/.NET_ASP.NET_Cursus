using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public class Persoon
    {
        public string Familienaam { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Geboren { get; set; }

        public bool Gehuwd { get; set; }
        public EnumGeslacht Geslacht { get; set; }
        public int ID { get; set; }
        public string Opmerkingen { get; set; }
        public string Paswoord { get; set; }
        public int Score { get; set; }
        public string Voornaam { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Wedde { get; set; }
    }
}