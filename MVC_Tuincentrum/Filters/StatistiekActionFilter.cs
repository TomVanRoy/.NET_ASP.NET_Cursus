using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum.Filters
{
    public class StatistiekActionFilter : ActionFilterAttribute
    {
        private static Dictionary<string, int> statistiek = new Dictionary<string, int>();

        public static Dictionary<string, int> Statistiek
        {
            get
            {
                return statistiek;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Url.ToString();
            lock (statistiek)
            {
                if (statistiek.ContainsKey(url))
                {
                    statistiek[url]++;
                }
                else
                {
                    statistiek[url] = 1;
                }
            }
        }
    }
}