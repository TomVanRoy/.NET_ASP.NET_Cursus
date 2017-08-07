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

        public ActionResult VerdubbelDeWeddes()
        {
            //update in de database
            return Redirect("~/Werknemer/WeddesAangepast");
        }

        public ActionResult WeddesAangepast()
        {
            return View();
        }

        [NonAction]
        public void GeenAction()
        {
        }
    }
}