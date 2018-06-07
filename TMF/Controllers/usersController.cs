using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TMF.Models.Context;
using TMF.Models.Entity;
using Newtonsoft.Json;
using TMF.Models.Games.Steam;

namespace TMF.Controllers
{
    public class usersController : Controller
    {
        private TmfContext db = new TmfContext();

        // GET: users
        public ActionResult Index()
        {

            if (Session["id"] != null && Session["yetki"].ToString() == "1")
            {
                var a = db.user.ToList();
                return View(a);
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            if (Session["yetki"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Find");
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
                Session["search"] = usr.search == true ?  "1" : "0";
                usr.online = true;
                db.Entry(usr).State = EntityState.Modified;
                db.SaveChanges();
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
            if (Session["id"] != null)
            {
                var usr = db.user.Find(Session["id"]);
                usr.online = false;
                db.Entry(usr).State = EntityState.Modified;
                db.SaveChanges();
                Session.Clear();
                return RedirectToAction("Index", "Find");
            }
            return RedirectToAction("Index", "Find");

        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["yetki"] != null)
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
            return RedirectToAction("Login");

        }
        [HttpPost]
        public JsonResult getSteamDatas(string connectID)
        {
            if (connectID != "")
            {
                //76561198017002228
                string url = " http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=0A6275C1D7258B89774826D89329EE09&steamid=" + connectID + "&include_appinfo=1&format=json ";
                WebRequest istek = HttpWebRequest.Create(url);
                WebResponse cevap;
                cevap = istek.GetResponse();
                using (StreamReader r = new StreamReader(cevap.GetResponseStream()))
                {
                    string json = r.ReadToEnd();
                    data item = JsonConvert.DeserializeObject<data>(json);
                    return Json(item, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false);
            
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.gameList = new SelectList(db.game, "id", "name");
            ViewBag.csRanks = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id > 86), "id", "value");
            ViewBag.lolRanks = new SelectList(db.compAtt.Where(a => a.id <= 81 && a.id > 54), "id", "value");
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
                var date1 = fc["date"];
                bool mic = fc["mic"] == "on" ? true : false;
                bool hs = fc["headset"] == "on" ? true : false;

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
                bool rifle = fc["Rifler"] == "on" ? true : false;
                bool igl = fc["IGL"] == "on" ? true : false;
                bool supporter = fc["Supporter"] == "on" ? true : false;
                bool frag = fc["Fragger"] == "on" ? true : false;
                bool top = fc["Top"] == "on" ? true : false; //LOL ROLES
                bool mid = fc["Mid"] == "on" ? true : false;
                bool jung = fc["Jungle"] == "on" ? true : false;
                bool adc = fc["Adc"] == "on" ? true : false;
                bool sup = fc["Support"] == "on" ? true : false;
                string gameIDcs = fc["gameConnectIDcs"];
                string gameNickcs = fc["gameNickNamecs"];
                string gameNicklol = fc["gameNickNamelol"];

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
                    usrGameLol.gameNickName = gameNicklol;
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
                    usrGameCs.time = csHours;
                    usrGameCs.gameConnectID = gameIDcs;
                    usrGameCs.gameNickName = gameNickcs;
                    csRankData.compAtt = db.compAtt.Find(int.Parse(rankcs));
                    userGameDescListCs.Add(csRankData);
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
                return RedirectToAction("Index", "users");
            }

            return RedirectToAction("Login");
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null && (Session["id"].ToString() == id.ToString() || Session["yetki"].ToString() == "1"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users users = db.user.Find(id);
                ViewBag.csRanks = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id > 86), "id", "value");
                ViewBag.lolRanks = new SelectList(db.compAtt.Where(a => a.id <= 81 && a.id > 54), "id", "value");
                ViewBag.gameListt = new SelectList(db.game.ToList(), "id", "name");
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            return RedirectToAction("Login");

        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,dateOfBirth,mic,headset,online")] users users, FormCollection fc)
        {
            if (users.id!= null && users.username!="" && users.password!="")
            {
                //userGame table data
                bool lol = fc["League"] == "on" ? true : false;
                bool cs = fc["Counter"] == "on" ? true : false;
                bool pubg = fc["PlayerUnknown's"] == "on" ? true : false;
                bool rocket = fc["Rocket"] == "on" ? true : false;
                bool fort = fc["Fortnite"] == "on" ? true : false;
                int lolHours = int.Parse(fc["lolHours"]);
                int csHours = int.Parse(fc["csHours"]);
                string gameIDcs = fc["gameConnectIDcs"];
                string gameNickcs = fc["gameNickNamecs"];
                string gameNicklol = fc["gameNickNamelol"];

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
                bool sup = fc["Support"] == "on" ? true : false;
                bool ggg = fc["asdasdasd"] == "on" ? true : false;
                users usr = db.user.Find(users.id);
                userGames usrGameLol = usr.userGame.Where(u => u.game.id == 1).FirstOrDefault();
                userGames usrGameCs = usr.userGame.Where(u => u.game.id == 2).FirstOrDefault();
                List<userGameDescs> lolDataList = db.userGameDesc.Where(u => u.userGame.user.id == users.id && u.userGame.game.id == 1).ToList();
                List<userGameDescs> csDataList = db.userGameDesc.Where(u => u.userGame.user.id == users.id && u.userGame.game.id == 2).ToList();
                userGames userCs = new userGames();
                userGames userLol = new userGames();
                users.mic = fc["mic"] == "on" ? true : false;
                users.headset = fc["headset"] == "on" ? true : false;




                userCs.user = usr;
                //lol yoksa ve yeni girme işlemi yaparsa, yeni userGame nesnesi doldurma
                if (usrGameLol == null && lol)
                {
                    userLol.game = db.game.Find(1);
                    userLol.time = lolHours;
                    userLol.user = usr;
                    userLol.gameNickName = gameNicklol;
                    db.userGame.Add(userLol);

                }
                //cs yoksa ve yeni girme işlemi yaparsa, yeni userGame nesnesi doldurma
                if (usrGameCs == null && cs)
                {
                    userCs.game = db.game.Find(2);
                    userCs.time = csHours;
                    userCs.user = usr;
                    userCs.gameConnectID = gameIDcs;
                    userCs.gameNickName = gameNickcs;
                    db.userGame.Add(userCs);

                }
                //Lol kaldırdı ise
                if (usrGameLol != null && lol == false) //Lol tiki kaldırıldıysa tüm lol verilerini siler.
                {
                    foreach (var item in lolDataList)
                    {
                        db.userGameDesc.Remove(item);
                    }
                    db.userGame.Remove(usrGameLol);
                }
                else if (lol == true)
                {
                    if (usrGameLol != null)
                    {
                        if (usrGameLol.time != lolHours)
                        {
                            usrGameLol.time = lolHours;
                            db.Entry(usrGameLol).State = EntityState.Modified;
                        }
                        if (usrGameLol.gameNickName != gameNicklol)
                        {
                            usrGameLol.gameNickName = gameNicklol;
                            db.Entry(usrGameLol).State = EntityState.Modified;
                        }
                    }

                    if (usrGameLol == null && top)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(82);
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 82) == false && top == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(82);
                        row.userGame = usrGameLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 82) && top == false)
                    {
                        var temp = lolDataList.Where(a => a.compAtt.id == 82).First();
                        db.userGameDesc.Remove(lolDataList.Where(a => a.compAtt.id == 82).First());
                        lolDataList.Remove(temp);
                    }


                    if (usrGameLol == null && mid)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(83);
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);

                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 83) == false && mid == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(83);
                        row.userGame = usrGameLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 83) && mid == false)
                    {
                        var temp = lolDataList.Where(a => a.compAtt.id == 83).First();
                        db.userGameDesc.Remove(lolDataList.Where(a => a.compAtt.id == 83).First());
                        lolDataList.Remove(temp);
                    }


                    if (usrGameLol == null && jung)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(84);
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);

                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 84) == false && jung == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(84);
                        row.userGame = usrGameLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 84) && jung == false)
                    {
                        var temp = lolDataList.Where(a => a.compAtt.id == 84).First();
                        db.userGameDesc.Remove(lolDataList.Where(a => a.compAtt.id == 84).First());
                        lolDataList.Remove(temp);
                    }

                    if (usrGameLol == null && adc)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(85);
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);

                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 85) == false && adc == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(85);
                        row.userGame = usrGameLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 85) && adc == false)
                    {
                        var temp = lolDataList.Where(a => a.compAtt.id == 85).First();

                        db.userGameDesc.Remove(lolDataList.Where(a => a.compAtt.id == 85).First());
                        lolDataList.Remove(temp);
                    }


                    if (usrGameLol == null && sup)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(86);
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);

                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 86) == false && sup == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(86);
                        row.userGame = usrGameLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Any(u => u.compAtt.id == 86) && sup == false)
                    {
                        var temp = lolDataList.Where(a => a.compAtt.id == 86).First();
                        db.userGameDesc.Remove(lolDataList.Where(a => a.compAtt.id == 86).First());
                        lolDataList.Remove(temp);
                    }

                    if (usrGameLol == null)///sadasdas
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(int.Parse(ranklol));
                        row.userGame = userLol;
                        db.userGameDesc.Add(row);
                    }
                    else if (lolDataList.Where(u => u.compAtt.gameComponent.id == 3).First().compAtt.id != int.Parse(ranklol))
                    {
                        lolDataList.Where(u => u.compAtt.gameComponent.id == 3).First().compAtt = db.compAtt.Find(int.Parse(ranklol));
                        db.Entry(lolDataList.Where(u => u.compAtt.gameComponent.id == 3).First()).State = EntityState.Modified;
                    }

                }

                if (cs == false && usrGameCs!=null)//Cs verisi var ve tiki kaldırılmış tüm cs verilerini siler.
                {
                    foreach (var item in csDataList)
                    {
                        db.userGameDesc.Remove(item);
                    }
                    db.userGame.Remove(usrGameCs);
                }
                else if (cs == true)//Cs verisi (tik) girmiş
                {

                    if (usrGameCs != null)
                    {
                        if (usrGameCs.time != csHours) //Önceden olan cs verisi saat kontrolü ####HATA
                        {
                            usrGameCs.time = csHours;
                            db.Entry(usrGameCs).State = EntityState.Modified;
                        }
                        if (usrGameCs.gameConnectID != gameIDcs)
                        {
                            usrGameCs.gameConnectID = gameIDcs;
                            db.Entry(usrGameCs).State = EntityState.Modified;
                        }
                        if (usrGameCs.gameNickName != gameNickcs)
                        {
                            usrGameCs.gameNickName = gameNickcs;
                            db.Entry(usrGameCs).State = EntityState.Modified;
                        }
                    }

                    if (usrGameCs == null && awp == true) //Tik işaretli ama veri ilk defa girilecek
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(105);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 105) == false && awp == true)//Tik işaretlendiğinde değiştirme işlemi
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(105);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 105) && awp == false) //Tik kaldırdığında değiştirme işlemi
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 105).First();
                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 105).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null && lurker == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(106);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 106) == false && lurker == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(106);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 106) && lurker == false)
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 106).First();
                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 106).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null && rifle == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(107);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 107) == false && rifle == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(107);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 107) && rifle == false)
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 107).First();
                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 107).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null && igl == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(108);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 108) == false && igl == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(108);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 108) && igl == false)
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 108).First();

                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 108).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null && supporter == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(109);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 109) == false && supporter == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(109);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 109) && supporter == false)
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 109).First();
                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 109).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null && frag == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(110);
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 110) == false && frag == true)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(109);
                        row.userGame = usrGameCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Any(u => u.compAtt.id == 110) && frag == false)
                    {
                        var temp = csDataList.Where(a => a.compAtt.id == 110).First();
                        db.userGameDesc.Remove(csDataList.Where(a => a.compAtt.id == 110).First());
                        csDataList.Remove(temp);
                    }

                    if (usrGameCs == null)
                    {
                        userGameDescs row = new userGameDescs();
                        row.compAtt = db.compAtt.Find(int.Parse(rankcs));
                        row.userGame = userCs;
                        db.userGameDesc.Add(row);
                    }
                    else if (csDataList.Where(u => u.compAtt.gameComponent.id == 5).First().compAtt.id != int.Parse(rankcs))
                    {
                        csDataList.Where(u => u.compAtt.gameComponent.id == 5).First().compAtt = db.compAtt.Find(int.Parse(rankcs));
                        db.Entry(csDataList.Where(u => u.compAtt.gameComponent.id == 5).First()).State = EntityState.Modified;
                    }

                }
                usr.dateOfBirth = users.dateOfBirth; ;
                usr.headset = users.headset; ;
                usr.mic = users.mic;
                usr.password = users.password;
                usr.username = users.username;

                if (usr.userGame.Any(u=>u.game.id==5) == false &&  fort) // fortnite yok ama işaretlemiş - fort ekle
                {
                    userGames usrGame = new userGames();
                    usrGame.game = db.game.Find(5);
                    usrGame.user = usr;
                    db.userGame.Add(usrGame);
                }
                else if (usr.userGame.Any(u => u.game.id == 5) == true && fort == false)// fortnite var ama işaretlememiş - fort sil
                {
                    userGames temp = usr.userGame.Where(a => a.game.id == 5).First();
                    db.userGame.Remove(temp);

                }

                if (usr.userGame.Any(u => u.game.id == 3) == false &&  pubg)// pubg yok ama işaretlemiş - pubg ekle
                {
                    userGames usrGame = new userGames();
                    usrGame.game = db.game.Find(3);
                    usrGame.user = usr;
                    db.userGame.Add(usrGame);
                }
                else if (usr.userGame.Any(u => u.game.id == 3) == true && pubg == false)// pubg var ama işaretlememiş - pubg sil
                {
                    userGames temp = usr.userGame.Where(a => a.game.id == 3).First();
                    db.userGame.Remove(temp);

                }

                if (usr.userGame.Any(u => u.game.id == 4) == false && rocket)// rocket yok ama işaretlemiş - rocket ekle
                {
                    userGames usrGame = new userGames();
                    usrGame.game = db.game.Find(4);
                    usrGame.user = usr;
                    db.userGame.Add(usrGame);
                }
                else if (usr.userGame.Any(u => u.game.id == 4) == true && rocket == false)// rocket var ama işaretlememiş - rocket sil
                {
                    userGames temp = usr.userGame.Where(a => a.game.id == 4).First();
                    db.userGame.Remove(temp);
                }


                db.Entry(usr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        [HttpPost]
        public JsonResult userSearchable(bool bit,string id)
        {
            if (id !="0")
            {
                users usr = db.user.Find(int.Parse(id));
                if (usr.search == true && bit == false) //Aranmak istemiyor.
                {
                    usr.search = false;
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("0");

                }
                else if (usr.search == false && bit == true) //Aranmak istiyor.
                {

                    usr.search = true;
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("1");
                }
                else
                {
                    return Json("2");
                }
            }
            return Json("3");
        }

        public ActionResult Delete(int id)
        {
            if (Session["yetki"].ToString() == "1" || Session["id"].ToString() == id.ToString())
            {
                users users = db.user.Find(id);
                foreach (var item in users.userGame.ToList<userGames>())
                {
                    foreach (var itemDesc in item.userGameDesc.ToList<userGameDescs>())
                    {
                        db.userGameDesc.Remove(itemDesc);
                    }
                    db.userGame.Remove(item);
                }
                db.user.Remove(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "users");

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
