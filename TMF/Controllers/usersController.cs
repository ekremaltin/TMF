using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMF.Models.Context;
using TMF.Models.Entity;

namespace TMF.Controllers
{
    public class usersController : Controller
    {
        private TmfContext db = new TmfContext();

        // GET: users
        public ActionResult Index()
        {
            return View(db.user.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {

            var a = fc["usernameL"].ToString();
            var b = fc["passL"].ToString();
            var usr = db.user.Where(u => u.username == a && u.password == b).FirstOrDefault();

            if (usr != null)
            {
                Session["id"] = usr.id;
                Session["Ad"] = usr.username;
                Session["yetki"] = usr.role.id;
                return RedirectToAction("Index", "Find");
            }
            else
            {
                ModelState.AddModelError("", "my db Kullanıcı adı veya şifre hatalı.");
            }


            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index","Find");
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.gameList = new SelectList(db.game, "id", "name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            if (((fc["usernameK"]).ToString()).Count()>4)
            {
                var a = fc["usernameK"];
                var b = fc["passK"];
                var c = fc["emailK"];
                DateTime dt = new DateTime(2000,01,01);
                users user = new users();
                user.username = a;
                user.password = b;
                user.dateOfBirth= dt;
                user.role = db.role.Where(u=>u.id==3).FirstOrDefault();
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }            

            return RedirectToAction("Login");
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,dateOfBirth,image,mic,headset,online")] users users,FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.user.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.user.Find(id);
            db.user.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
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
