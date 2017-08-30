using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_Security.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rolebeheer()
        {
            IDbSet<IdentityRole> alleRoles = context.Roles;
            return View(alleRoles);
        }

        public ActionResult Userbeheer()
        {
            IDbSet<ApplicationUser> alleUsers = context.Users;
            return View(alleUsers);
        }

        public ActionResult VerwijderUser(string id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult VerwijderUserDoorvoeren(string id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("Userbeheer");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UserDetail(string id)
        {
            var user = context.Users.Find(id);
            ViewBag.userid = id;
            ViewBag.username = user.UserName;

            var rolesVoorUser = new List<IdentityRole>();
            foreach (var role in user.Roles)
            {
                rolesVoorUser.Add(context.Roles.Find(role.RoleId));
            }
            return View(rolesVoorUser);
        }

        public ActionResult VerwijderRoleForMember(string userid, string roleid)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);

            if (user != null && role != null)
            {
                IdentityUserRole userrole = user.Roles.SingleOrDefault(ur => (ur.UserId == userid && ur.RoleId == roleid));
                user.Roles.Remove(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("UserDetail", "User", new { id = userid });
        }
    }
}