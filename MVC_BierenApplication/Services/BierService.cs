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

        static BierService()
        {
            bieren[1] = new Bier { ID = 1, Alcohol = 9.5F, Naam = "Boerken" };
            bieren[2] = new Bier { ID = 2, Alcohol = 4.9F, Naam = "Hoegaarden" };
            bieren[3] = new Bier { ID = 3, Alcohol = 6.5F, Naam = "Leffe Bruin" };
            bieren[4] = new Bier { ID = 4, Alcohol = 5.4F, Naam = "Palm" };
            bieren[5] = new Bier { ID = 5, Alcohol = 0.0F, Naam = "Hoegaarden 0,0" };
        }

        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }

        public Bier Read(int id)
        {
            return bieren[id];
        }

        public void Delete(int id)
        {
            bieren.Remove(id);
        }
    }
}