using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cultuurhuis
{
    public class BestaatnognietAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (!(value is string))
            {
                return false;
            }
            else
            {
                Services.CultuurService db = new Services.CultuurService();
                return ! db.BestaatKlant((string)value);
            }
        }
    }
}