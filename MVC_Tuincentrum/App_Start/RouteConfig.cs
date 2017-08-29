using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace MVC_Tuincentrum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintResolver);
            // routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Alleplanten",
                "Plantenlijst",
                new { controller = "Plant", action = "Index" }
            );
            routes.MapRoute(
                "PlantByNr",
                "Plant/{id}",
                new { controller = "Plant", action = "Details" },
                new { id = new IntRouteConstraint() }
            );
            routes.MapRoute(
                "LeverancierByNr",
                "Leverancier/{id}",
                new { controller = "Leverancier", action = "Details" }
            );
            routes.MapRoute(
                "SoortByNr",
                "Soort/{id}",
                new { controller = "Soort", action = "Details" }
            );
            routes.MapRoute(
                "PlantenVanEenSoort",
                "Soort/{soortnaam}/planten",
                new { controller = "Plant", action = "FindPlantenBySoortNaam" }
            );
            routes.MapRoute(
                "PlantenVanEenLeverancier",
                "Leverancier/{levnr}/Planten",
                new { controller = "Plant", action = "FindPlantenByLeverancier" },
                new { levnr = new MaxRouteConstraint(10) }
            );
            routes.MapRoute(
                "PlantenByKleur",
                "PlantenPerKleur/{kleur}",
                new { controller = "Plant", action = "FindPlantenVanEenKleur" },
                new
                {
                    kleur = new CompoundRouteConstraint(
                        new List<IRouteConstraint> {
                            new AlphaRouteConstraint(),
                            new MinLengthRouteConstraint(3),
                            new MaxLengthRouteConstraint(8)
                        }
                    )
                }
            );
            routes.MapRoute(
                "FindPlantenByPrijsBetween",
                "planten",
                new { controller = "Plant", action = "FindPlantenBetweenPrijzen" },
                new { QueryConstraint = new QueryStringConstraint(new string[] { "minprijs", "maxprijs" }) }
            );
            routes.MapRoute(
                "FindPlantenByKleur",
                "planten",
                new { controller = "Plant", action = "FindPlantenVanEenKleur" },
                new { QueryConstraint = new QueryStringConstraint(new string[] { "kleur" }) }
            );
            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}