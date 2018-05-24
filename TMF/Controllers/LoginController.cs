using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TMF.Models.Context;
using TMF.Models.Entity;

namespace TMF.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private TmfContext db = new TmfContext();
        public ActionResult Index()
        {
            if (Session["yetki"] != null && (Session["yetki"].ToString() == "1" || Session["yetki"].ToString() == "2" || Session["yetki"].ToString() == "3"))
            {
                var users = db.user.Include(u => u.role);
                return View(users.ToList());
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(users user)
        {

            if (ModelState.IsValid)
            {
                var usr = db.user.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();

                if (usr != null)
                {
                    Session["id"] = usr.id;
                    Session["username"] = usr.username;
                    var yetki = (from u in db.user
                                 where u.role.id==usr.role.id
                                 select u.role.name).FirstOrDefault();
                    Session["yetki"] = yetki;
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }        
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}