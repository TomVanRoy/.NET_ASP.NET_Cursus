using MVC_Voorbeeld2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer
        public ActionResult Index(int? id)
        {
            return View();
            //return File(@"C:\kruisdistel.jpg", "image/jpg");
        }

        public ActionResult ShowAll(int? pageNr)
        {
            return View();
        }

        [ActionName("Lijst")]
        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer { Voornaam = "Steven", Wedde = 1000, InDienst = DateTime.Today });
            werknemers.Add(new Werknemer { Voornaam = "Prosper", Wedde = 2000, InDienst = DateTime.Today.AddDays(-2) });
            return View("AlleWerknemers", werknemers);
        }

        public ActionResult VerdubbelDeWeddes()
        {
            //update in de database
            return Redirect("~/Werknemer/WeddesAangepast");
        }

        public ActionResult WeddesAangepast()
        {
            return View();
        }

        public ActionResult Read(int id)
        {
            return View();
        }

        [NonAction]
        public void GeenAction()
        {
        }
    }
}