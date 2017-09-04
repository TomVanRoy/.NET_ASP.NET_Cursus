using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_BierenSecurity.Models;

namespace MVC_BierenSecurity.Services
{
    public class SoortService
    {
        private static Dictionary<int, Soort> soorten = new Dictionary<int, Soort>();

        internal void Add(Soort s)
        {
            using (var db = new BierenEntities())
            {
                db.Soorten.Add(s);
                db.SaveChanges();
            }
        }

        public List<Soort> FindAll()
        {
            using (var db = new BierenEntities())
            {
                return db.Soorten.ToList();
            }
        }

        public Soort Read(int ID)
        {
            using (var db = new BierenEntities())
            {
                return db.Soorten.Find(ID);
            }
        }

        public void Delete(int ID)
        {
            using (var db = new BierenEntities())
            {
                var soort = db.Soorten.Find(ID);
                db.Soorten.Remove(soort);
                db.SaveChanges();
            }
        }
    }
}