﻿using MVC_BierenApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_BierenApplication.Services
{
    public class PersoonService
    {
        private static Dictionary<int, Persoon> personen = new Dictionary<int, Persoon> {
            {
                1,
                new Persoon {
                    ID =1,
                    Voornaam = "Jesse",
                    Familienaam = "James",
                    Score =5,
                    Wedde =1000,
                    Paswoord ="123",
                    Geboren =new DateTime(1966,1,1),
                    Gehuwd =true,
                    Opmerkingen ="Schurk van het Wilde Westen",
                    Geslacht =EnumGeslacht.Man
                }
            },
            {
                2,
                new Persoon {
                    ID =2,
                    Voornaam = "Jane",
                    Familienaam = "Calamity",
                    Score=4,
                    Wedde=2000,
                    Paswoord="123",
                    Geboren=new DateTime(1966,2,2),
                    Gehuwd=true,
                    Opmerkingen="Martha Jane Cannary",
                    Geslacht=EnumGeslacht.Vrouw
                }
            },
            {
                3,
                new Persoon {
                    ID =3,
                    Voornaam="Billy",
                    Familienaam ="The Kid",
                    Score=5,
                    Wedde=3000,
                    Paswoord="123",
                    Geboren=new DateTime(1966,3,3),
                    Gehuwd=false,
                    Opmerkingen="Revolverheld",
                    Geslacht=EnumGeslacht.Man
                }
            },
            {
                4,
                new Persoon {
                    ID =4,
                    Voornaam="Sarah",
                    Familienaam ="Bernhardt",
                    Score=3,
                    Wedde=4000,
                    Paswoord="123",
                    Geboren=new DateTime(1966,4,4),
                    Gehuwd=false,
                    Opmerkingen="Rosine Bernardt",
                    Geslacht=EnumGeslacht.Vrouw
                }
            }
        };

        public List<Persoon> FindAll()
        {
            return personen.Values.ToList();
        }

        public Persoon FindByID(int id)
        {
            return personen[id];
        }

        public void Delete(int id)
        {
            personen.Remove(id);
        }
    }
}