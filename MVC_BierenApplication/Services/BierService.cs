using MVC_BierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_BierenApplication.Services
{
    public class BierService
    {
        private static Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();

        internal void Add(Bier b)
        {
            using (var db = new MVCBierenEntities())
            {
                db.Bieren.Add(b);
                db.SaveChanges();
            }
        }

        public List<Bier> FindAll()
        {
            using (var db = new MVCBierenEntities())
            {
                return db.Bieren.ToList();
            }
        }

        public Bier Read(int ID)
        {
            using (var db = new MVCBierenEntities())
            {
                return db.Bieren.Find(ID);
            }
        }

        public void Delete(int ID)
        {
            using (var db = new MVCBierenEntities())
            {
                var bier = db.Bieren.Find(ID);
                db.Bieren.Remove(bier);
                db.SaveChanges();
            }
        }
    }
}