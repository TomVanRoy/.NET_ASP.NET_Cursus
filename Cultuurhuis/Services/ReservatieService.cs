using Cultuurhuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cultuurhuis.Services
{
    public class ReservatieService
    {
        private static Dictionary<int, Reservatie> voorstellingen = new Dictionary<int, Reservatie>();

        public void Delete(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                var reservatie = db.Reservaties.Find(ID);
                db.Reservaties.Remove(reservatie);
                db.SaveChanges();
            }
        }

        public List<Reservatie> FindAll()
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Reservaties.ToList();
            }
        }

        public Reservatie Read(int ID)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                return db.Reservaties.Find(ID);
            }
        }

        internal void Add(Reservatie r)
        {
            using (var db = new CultuurHuisMVCEntities())
            {
                db.Reservaties.Add(r);
                db.SaveChanges();
            }
        }
    }
}