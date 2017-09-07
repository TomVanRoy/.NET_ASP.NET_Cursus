using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Models
{
    public class VoorstellingenViewModel
    {
        public Genre Genre { get; set; }
        public List<Genre> Genres{ get; set; }
        public List<Voorstelling> Voorstellingen { get; set; }
    }
}