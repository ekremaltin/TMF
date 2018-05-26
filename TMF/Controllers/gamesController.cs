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
    public class gamesController : Controller
    {
        private TmfContext db = new TmfContext();

        // GET: games
        public ActionResult Index()
        {
            return View(db.game.ToList());
        }

        public JsonResult getGames()
        {
            var liste = new SelectList(db.game, "id", "name");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getRankCs()
        {
            var liste = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id >86), "id", "value");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getRankLol()
        {
            var liste = new SelectList(db.compAtt.Where(a => a.id <= 27 && a.id > 0), "id", "value");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = db.game.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // GET: games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,url,image")] games games)
        {
            if (ModelState.IsValid)
            {
                db.game.Add(games);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(games);
        }

        // GET: games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = db.game.Find(id);

            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,url,image")] games games)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(games);
        }

        // GET: games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            games games = db.game.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }

        // POST: games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            games games = db.game.Find(id);
            db.game.Remove(games);
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
