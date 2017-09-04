using Cultuurhuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Services
{
    public class GenreService
    {
        private static Dictionary<int, Genre> gernes = new Dictionary<int, Genre>();

        public void Delete(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var genre = db.Genres.Find(ID);
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }

        public List<Genre> FindAll()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.ToList();
            }
        }

        public Genre Read(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Genres.Find(ID);
            }
        }

        internal void Add(Genre g)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Genres.Add(g);
                db.SaveChanges();
            }
        }
    }
}