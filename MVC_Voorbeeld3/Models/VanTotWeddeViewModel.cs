using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Voorbeeld3.Models
{
    public class VanTotWeddeViewModel : IValidatableObject
    {
        public List<Persoon> Personen { get; set; }

        [Display(Name = "Tot wedde")]
        [Required(ErrorMessage = "Tot wedde is verplicht")]
        public decimal? TotWedde { get; set; }

        [Display(Name = "Van wedde")]
        [Required(ErrorMessage = "Van wedde is verplicht")]
        public decimal? VanWedde { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (VanWedde > TotWedde)
            {
                validationResults.Add(new ValidationResult("TotWedde is kleiner dan VanWedde"));
            }
            return validationResults;
        }
    }
}