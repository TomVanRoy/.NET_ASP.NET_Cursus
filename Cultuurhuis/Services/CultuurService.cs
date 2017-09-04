using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cultuurhuis.Models;

namespace Cultuurhuis.Services
{
    public class CultuurService
    {
        public List<Genre> GetAllGenres()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.OrderBy(m => m.GenreNaam).ToList();
            }
        }

        public Genre GetGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.Find(id);
            }
        }

        public List<Voorstelling> GetVoorstellingenByGenre(int? id)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var query = from voorstelling in db.Voorstellingen.Include("Genre")
                            where voorstelling.Datum >= DateTime.Today && voorstelling.GenreNr == id
                            orderby voorstelling.Datum
                            select voorstelling;
                return query.ToList();
            }
        }
    }
}