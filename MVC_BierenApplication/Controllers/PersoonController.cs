using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_BierenApplication.Services;

namespace MVC_BierenApplication.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();

        // GET: Persoon
        public ActionResult Index()
        {
            return View(persoonService.FindAll());
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindByID(id));
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}