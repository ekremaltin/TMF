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
            var a = db.user.ToList();
            return View(a);
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
            return RedirectToAction("Index", "Find");
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
            ViewBag.csRanks = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id > 86), "id", "value");
            ViewBag.lolRanks = new SelectList(db.compAtt.Where(a => a.id <= 27 && a.id > 0), "id", "value");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            if (fc["registerPage"] == "1")
            {
                if (((fc["usernameK"]).ToString()).Count() > 4)
                {
                    var a = fc["usernameK"];
                    var b = fc["passK"];
                    var c = fc["emailK"];
                    DateTime dt = new DateTime(2000, 01, 01);
                    users user = new users();
                    user.username = a;
                    user.password = b;
                    user.dateOfBirth = dt;
                    user.role = db.role.Where(u => u.id == 3).FirstOrDefault();
                    db.user.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }

            }
            else
            {
                //user table data
                string usrname = fc["username"];
                string psw = fc["password"];
                var date1 = fc["dateOfBirth"];
                bool mic = Convert.ToBoolean(fc["mic"].Split(',')[0]);
                bool hs = Convert.ToBoolean(fc["headset"].Split(',')[0]);

                //userGame table data
                bool lol = fc["League"] == "on" ? true : false;
                bool cs = fc["Counter"] == "on" ? true : false;
                bool pubg = fc["PlayerUnknown's"] == "on" ? true : false;
                bool rocket = fc["Rocket"] == "on" ? true : false;
                bool fort = fc["Fortnite"] == "on" ? true : false;
                int lolHours = int.Parse(fc["lolHours"]);
                int csHours = int.Parse(fc["csHours"]);

                //userGameDesc table data
                var rankcs = fc["rankCs"];
                var ranklol = fc["rankLol"];
                bool awp = fc["AWP"] == "on" ? true : false; //CS ROLES
                bool lurker = fc["Lurker"] == "on" ? true : false;
                bool rifle = fc["Rifle"] == "on" ? true : false;
                bool igl = fc["IGL"] == "on" ? true : false;
                bool supporter = fc["Supporter"] == "on" ? true : false;
                bool frag = fc["Fragger"] == "on" ? true : false;
                bool top = fc["Top"] == "on" ? true : false; //LOL ROLES
                bool mid = fc["Mid"] == "on" ? true : false;
                bool jung = fc["Jungle"] == "on" ? true : false;
                bool adc = fc["Adc"] == "on" ? true : false;
                bool sup = fc["Sup"] == "on" ? true : false;

                DateTime date = new DateTime();
                date = Convert.ToDateTime(date1);

                users usr = new users();
                userGames usrGameLol = new userGames();
                userGames usrGameCs = new userGames();
                userGames usrGameFort = new userGames();
                userGames usrGamePubg = new userGames();
                userGames usrGameRocket = new userGames();
                userGameDescs topData = new userGameDescs();
                userGameDescs midData = new userGameDescs();
                userGameDescs jungData = new userGameDescs();
                userGameDescs adcData = new userGameDescs();
                userGameDescs supData = new userGameDescs();
                userGameDescs lolRankData = new userGameDescs();
                userGameDescs awpData = new userGameDescs();
                userGameDescs lurkerData = new userGameDescs();
                userGameDescs rifleData = new userGameDescs();
                userGameDescs iglData = new userGameDescs();
                userGameDescs supporterData = new userGameDescs();
                userGameDescs fragData = new userGameDescs();
                userGameDescs csRankData = new userGameDescs();
                userGameDescs usrGameDescCs = new userGameDescs();
                List<userGameDescs> userGameDescListLol = new List<userGameDescs>();
                List<userGameDescs> userGameDescListCs = new List<userGameDescs>();
                List<userGames> userGameList = new List<userGames>();
                if (lol)
                {
                    usrGameLol.game = db.game.Find(1);
                    usrGameLol.time = lolHours;
                    lolRankData.compAtt = db.compAtt.Find(int.Parse(ranklol));
                    userGameDescListLol.Add(lolRankData);
                    if (top)
                    {
                        topData.compAtt = db.compAtt.Find(82);
                        userGameDescListLol.Add(topData);
                    }
                    if (jung)
                    {
                        jungData.compAtt = db.compAtt.Find(84);
                        userGameDescListLol.Add(jungData);
                    }
                    if (mid)
                    {
                        midData.compAtt = db.compAtt.Find(83);
                        var a2 = midData;
                        userGameDescListLol.Add(a2);
                    }
                    if (adc)
                    {
                        adcData.compAtt = db.compAtt.Find(85);
                        userGameDescListLol.Add(adcData);

                    }
                    if (sup)
                    {
                        supData.compAtt = db.compAtt.Find(86);
                        userGameDescListLol.Add(supData);
                    }
                    usrGameLol.userGameDesc = userGameDescListLol;
                    userGameList.Add(usrGameLol);
                }
                if (cs)
                {
                    usrGameCs.game = db.game.Find(2);
                    csRankData.compAtt = db.compAtt.Find(int.Parse(rankcs));
                    userGameDescListCs.Add(csRankData);
                    usrGameCs.time = csHours;
                    if (awp)
                    {
                        awpData.compAtt = db.compAtt.Find(105);
                        userGameDescListCs.Add(awpData);
                    }
                    if (lurker)
                    {
                        lurkerData.compAtt = db.compAtt.Find(106);
                        userGameDescListCs.Add(lurkerData);
                    }
                    if (rifle)
                    {
                        rifleData.compAtt = db.compAtt.Find(107);
                        userGameDescListCs.Add(rifleData);
                    }
                    if (igl)
                    {
                        iglData.compAtt = db.compAtt.Find(108);
                        userGameDescListCs.Add(iglData);

                    }
                    if (supporter)
                    {
                        supporterData.compAtt = db.compAtt.Find(109);
                        userGameDescListCs.Add(supporterData);
                    }
                    if (frag)
                    {
                        fragData.compAtt = db.compAtt.Find(110);
                        userGameDescListCs.Add(fragData);
                    }
                    usrGameCs.userGameDesc = userGameDescListCs;
                    userGameList.Add(usrGameCs);
                }
                if (fort)
                {
                    usrGameFort.game = db.game.Find(5);
                    userGameList.Add(usrGameFort);
                }
                if (pubg)
                {
                    usrGamePubg.game = db.game.Find(3);
                    userGameList.Add(usrGamePubg);
                }
                if (rocket)
                {
                    usrGameRocket.game = db.game.Find(4);
                    userGameList.Add(usrGameRocket);
                }

                usr.username = usrname; //User table data
                usr.password = psw;
                usr.dateOfBirth = date;
                usr.role = db.role.Where(u => u.id == 3).FirstOrDefault();
                usr.mic = mic;
                usr.headset = hs;
                usr.userGame = userGameList;

                db.user.Add(usr);
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

            ViewBag.csRanks = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id > 86), "id", "value");
            ViewBag.lolRanks = new SelectList(db.compAtt.Where(a => a.id <= 27 && a.id > 0), "id", "value");
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
        public ActionResult Edit([Bind(Include = "id,username,password,dateOfBirth,image,mic,headset,online")] users users, FormCollection fc)
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
