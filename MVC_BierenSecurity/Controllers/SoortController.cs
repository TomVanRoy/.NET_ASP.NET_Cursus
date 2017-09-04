using MVC_BierenSecurity.Models;
using MVC_BierenSecurity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BierenSecurity.Controllers
{
    public class SoortController : Controller
    {
        private SoortService soortService = new SoortService();
        private BierenEntities db = new BierenEntities();

        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Add()
        {
            var soort = new Soort();
            return View(soort);
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(Soort b)
        {
            if (this.ModelState.IsValid)
            {
                soortService.Add(b);
                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Delete(int SoortNr)
        {
            var soort = soortService.Read(SoortNr);
            this.TempData["soort"] = soort;
            soortService.Delete(SoortNr);
            return RedirectToAction("Verwijderd");
        }

        // GET: Soort
        public ActionResult Index()
        {
            var soorten = soortService.FindAll();
            return View(soorten);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderd()
        {
            var soort = (Soort)this.TempData["soort"];
            return View(soort);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderen(int SoortNr)
        {
            var soort = soortService.Read(SoortNr);
            return View(soort);
        }
    }
}