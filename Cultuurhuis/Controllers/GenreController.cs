using Cultuurhuis.Models;
using Cultuurhuis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cultuurhuis.Controllers
{
    public class GenreController : Controller
    {
        private GenreService genreService = new GenreService();
        private CultuurHuisMVCEntities db = new CultuurHuisMVCEntities();

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            var genre = new Genre();
            return View(genre);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Genre g)
        {
            if (this.ModelState.IsValid)
            {
                genreService.Add(g);
                return RedirectToAction("Index");
            }
            else
            {
                return View(g);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int genreNr)
        {
            var genre = genreService.Read(genreNr);
            this.TempData["genre"] = genre;
            genreService.Delete(genreNr);
            return RedirectToAction("Verwijderd");
        }

        public ActionResult Index()
        {
            var genres = genreService.FindAll();
            return View(genres);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Verwijderd()
        {
            var genre = (Genre)this.TempData["genre"];
            return View(genre);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Verwijderen(int genreNr)
        {
            var genre = genreService.Read(genreNr);
            return View(genre);
        }
    }
}