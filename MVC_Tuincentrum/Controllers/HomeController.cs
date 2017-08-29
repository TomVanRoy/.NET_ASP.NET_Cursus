using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum.Controllers
{
    [RoutePrefix("Thuis")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        // [Route]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Soorent()
        {
            return Redirect("Soort");
        }

        public ActionResult Leveranciers()
        {
            return Redirect("Leverancier");
        }

        public ActionResult Planten()
        {
            return Redirect("Plant");
        }

        // [Route("Over")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // [Route("~/Home/Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}