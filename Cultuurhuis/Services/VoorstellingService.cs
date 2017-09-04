using Cultuurhuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Services
{
    public class VoorstellingService
    {
        private static Dictionary<int, Voorstelling> voorstellingen = new Dictionary<int, Voorstelling>();

        public void Delete(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var voorstelling = db.Voorstellingen.Find(ID);
                db.Voorstellingen.Remove(voorstelling);
                db.SaveChanges();
            }
        }

        public List<Voorstelling> FindAll()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.ToList();
            }
        }

        public Voorstelling Read(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Voorstellingen.Find(ID);
            }
        }

        internal void Add(Voorstelling v)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Voorstellingen.Add(v);
                db.SaveChanges();
            }
        }
    }
}