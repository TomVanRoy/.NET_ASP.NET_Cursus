using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Services;
using MVC_Voorbeeld3.Models;
using System.Globalization;

namespace MVC_BierenApplication.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();

        [HttpPost]
        public ActionResult Edit(Persoon p)
        {
            persoonService.Update(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditForm(int id)
        {
            return View(persoonService.FindByID(id));
        }

        // GET: Persoon
        public ActionResult Index()
        {
            return View(persoonService.FindAll());
        }

        public ActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }

        [HttpPost]
        public ActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {
                // Geen validatiefouten
                persoonService.Opslag(opslagViewModel.VanWedde.Value,
                                  opslagViewModel.TotWedde.Value,
                                  opslagViewModel.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                // Wel validatiefouten
                return View(opslagViewModel);
            }
        }

        [HttpPost]
        public ActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Geslacht = EnumGeslacht.Man;
            return View(persoon);
        }

        public JsonResult ValidateDOB(string Geboren)
        {
            DateTime parsedDOB;
            System.Diagnostics.Debug.WriteLine("First If fires: " + DateTime.TryParseExact(Geboren, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDOB));
            System.Diagnostics.Debug.WriteLine("parsedDOB" + parsedDOB);
            System.Diagnostics.Debug.WriteLine("Now:" + DateTime.Now);

            if (!DateTime.TryParseExact(Geboren, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDOB))
            {
                return Json("Gelieve een geldige datum in te voeren (dd/mm/jjjj) !",
                JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now < parsedDOB)
            {
                return Json("Voer een datum uit het verleden in !",
                JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }

        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                form.Personen = persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
            }
            return View("VanTotWedde", form);
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindByID(id));
        }
    }
}