using MVC_BierenSecurity.Models;
using MVC_BierenSecurity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BierenSecurity.Controllers
{
    public class BrouwerController : Controller
    {
        private BrouwerService brouwerService = new BrouwerService();
        private BierenEntities db = new BierenEntities();

        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Add()
        {
            var brouwer = new Brouwer();
            return View(brouwer);
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(Brouwer b)
        {
            if (this.ModelState.IsValid)
            {
                brouwerService.Add(b);
                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Delete(int BrouwerNr)
        {
            var brouwer = brouwerService.Read(BrouwerNr);
            this.TempData["brouwer"] = brouwer;
            brouwerService.Delete(BrouwerNr);
            return RedirectToAction("Verwijderd");
        }

        // GET: Brouwer
        public ActionResult Index()
        {
            var brouwers = brouwerService.FindAll();
            return View(brouwers);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderd()
        {
            var brouwer = (Brouwer)this.TempData["brouwer"];
            return View(brouwer);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Verwijderen(int BrouwerNr)
        {
            var brouwer = brouwerService.Read(BrouwerNr);
            return View(brouwer);
        }
    }
}