using MVC_BierenSecurity.Services;
using MVC_BierenSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BierenSecurity.Controllers
{
    public class BierController : Controller
    {
        private BierService bierService = new BierService();
        private BierenEntities db = new BierenEntities();

        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Add()
        {
            var bier = new Bier();
            return View(bier);
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                bierService.Add(b);
                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Delete(int BierNr)
        {
            var bier = bierService.Read(BierNr);
            this.TempData["bier"] = bier;
            bierService.Delete(BierNr);
            return RedirectToAction("Verwijderd");
        }

        // GET: Bier
        public ActionResult Index()
        {
            var bieren = bierService.FindAll();
            return View(bieren);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderen(int BierNr)
        {
            var bier = bierService.Read(BierNr);
            return View(bier);
        }
    }
}