using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_BierenSecurity.Models;

namespace MVC_BierenSecurity.Services
{
    public class BrouwerService
    {
        private static Dictionary<int, Brouwer> brouwers = new Dictionary<int, Brouwer>();

        internal void Add(Brouwer b)
        {
            using (var db = new BierenEntities())
            {
                db.Brouwers.Add(b);
                db.SaveChanges();
            }
        }

        public List<Brouwer> FindAll()
        {
            using (var db = new BierenEntities())
            {
                return db.Brouwers.ToList();
            }
        }

        public Brouwer Read(int ID)
        {
            using (var db = new BierenEntities())
            {
                return db.Brouwers.Find(ID);
            }
        }

        public void Delete(int ID)
        {
            using (var db = new BierenEntities())
            {
                var brouwer = db.Brouwers.Find(ID);
                db.Brouwers.Remove(brouwer);
                db.SaveChanges();
            }
        }
    }
}