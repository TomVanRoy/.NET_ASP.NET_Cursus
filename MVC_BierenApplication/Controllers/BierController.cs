using MVC_BierenApplication.Models;
using MVC_BierenApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BierenApplication.Controllers
{
    public class BierController : Controller
    {
        private BierService bierService = new BierService();

        [HttpGet]
        public ActionResult Add()
        {
            var bier = new Bier();
            return View(bier);
        }

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

        // GET: Bier
        public ActionResult Index()
        {
            var bieren = bierService.FindAll();
            return View(bieren);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bier = bierService.Read(id);
            this.TempData["bier"] = bier;
            bierService.Delete(id);
            return RedirectToAction("Verwijderd");
        }

        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);
        }

        public ActionResult Verwijderen(int id)
        {
            var bier = bierService.Read(id);
            return View(bier);
        }
    }
}