using Cultuurhuis.Services;
using Cultuurhuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cultuurhuis.Controllers
{
    public class KlantController : Controller
    {
        private KlantService klantService = new KlantService();
        private CultuurHuisMVCEntities db = new CultuurHuisMVCEntities();

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            var klant = new Klant();
            return View(klant);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Klant k)
        {
            if (this.ModelState.IsValid)
            {
                klantService.Add(k);
                return RedirectToAction("Index");
            }
            else
            {
                return View(k);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int klantNr)
        {
            var klant = klantService.Read(klantNr);
            this.TempData["klant"] = klant;
            klantService.Delete(klantNr);
            return RedirectToAction("Verwijderd");
        }

        // GET: Bier
        public ActionResult Index()
        {
            var klanten = klantService.FindAll();
            return View(klanten);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Verwijderd()
        {
            var klant = (Klant)this.TempData["klant"];
            return View(klant);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Verwijderen(int klantNr)
        {
            var klant = klantService.Read(klantNr);
            return View(klant);
        }
    }
}