using Cultuurhuis.Models;
using Cultuurhuis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cultuurhuis.Controllers
{
    public class VoorstellingController : Controller
    {
        private VoorstellingService voorstellingService = new VoorstellingService();
        private CultuurHuisMVCEntities db = new CultuurHuisMVCEntities();

        public ActionResult Index()
        {
            GenreService genreService = new GenreService();
            var genres = genreService.FindAll();
            return View(genres);
        }

        public ActionResult FindByGenre(int? genreNr)
        {
            if (genreNr != null)
            {
                var voorstellingen = (from voorstelling in db.Voorstellingen
                                      where voorstelling.GenreNr == genreNr && voorstelling.Datum >= DateTime.Today
                                      orderby voorstelling.Datum
                                      select voorstelling).ToList();
                string genreNaam = (from voorstelling in db.Genres
                                    where voorstelling.GenreNr == genreNr
                                    select voorstelling.Naam).FirstOrDefault();
                ViewBag.genreNaam = genreNaam;
                return View(voorstellingen);
            }
            else
            {
                return Redirect("Index");
            }
        }

        public ActionResult Details(int voorstellingId)
        {
            Voorstelling voorstelling = voorstellingService.Read(voorstellingId);
            return View(voorstelling);
        }

        public ActionResult Reserveren(int voorstellingId)
        {
            return View();
        }
    }
}