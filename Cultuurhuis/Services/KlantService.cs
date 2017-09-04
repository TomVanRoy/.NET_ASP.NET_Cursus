using Cultuurhuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Services
{
    public class KlantService
    {
        private static Dictionary<int, Klant> klanten = new Dictionary<int, Klant>();

        public void Delete(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var klant = db.Klanten.Find(ID);
                db.Klanten.Remove(klant);
                db.SaveChanges();
            }
        }

        public List<Klant> FindAll()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Klanten.ToList();
            }
        }

        public Klant Read(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Klanten.Find(ID);
            }
        }

        internal void Add(Klant k)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Klanten.Add(k);
                db.SaveChanges();
            }
        }
    }
}