﻿using System;
using System.Collections;
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
    public class FindController : Controller
    {
        TmfContext db = new TmfContext();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        // POST: Home
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc)
        {
            int a = int.Parse(fc["minData"]); //slider min değer
            int b = int.Parse(fc["maxData"]); //max değer
            return View();
        }

        public ActionResult Search()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search(FormCollection fc)
        {
            List<users> liste = new List<users>();
            List<userGameDescs> query = (from userGameDesc in db.userGameDesc
                         select (userGameDesc)).ToList();

            int min = int.Parse(fc["minData"]); //slider min değer
            int max = int.Parse(fc["maxData"]); //max değer

            int minRank = 86 + (2 * min - 1);
            int maxRank = 86 + (2 * max);
            if (min==10)
            {
                minRank -= 1;
            }
            if (max == 10)
            {
                maxRank -= 2;
            }
            List<userGameDescs> query1 = query.Where(e => e.compAtt.id >= minRank).Where(e => e.compAtt.id <= maxRank).ToList<userGameDescs>();
            query.Clear();
            foreach (var item2 in query1)
            {
                foreach (var item in item2.userGame.userGameDesc)
	                {
                        query.Add(item);
	                } 
              
               
            }

            List<userGameDescs> q1 = new List<userGameDescs>();
            List<userGameDescs> q2 = new List<userGameDescs>();
            List<userGameDescs> q3 = new List<userGameDescs>();
            List<userGameDescs> q4 = new List<userGameDescs>();
            List<userGameDescs> q5 = new List<userGameDescs>();
            List<userGameDescs> q6 = new List<userGameDescs>();



            string AWP = fc["AWP"];
            if (AWP == "on")
            {
                q1 = query.Where(e => e.compAtt.value == "AWP").ToList();

            }



            string Lurker = fc["Lurker"];
            if (Lurker == "on")
            {
                q2 = query.Where(e => e.compAtt.value == "Lurker").ToList();

            }


            string Rifler = fc["Rifler"];
            if (Rifler == "on")
            {
                q3 = query.Where(e => e.compAtt.value == "Rifler").ToList();

            }

            string IGL = fc["IGL"];
            if (IGL == "on")
            {
                q4 = query.Where(e => e.compAtt.value == "IGL").ToList();

            }


            string Supporter = fc["Supporter"];
            if (Supporter == "on")
            {
                q5 = query.Where(e => e.compAtt.value == "Supporter").ToList();

            }


            string Fragger = fc["Fragger"];
            if (Fragger == "on")
            {
                q6 = query.Where(e => e.compAtt.value == "Fragger").ToList();

            }


            if (AWP == null && Lurker == null && Rifler == null && IGL == null && Supporter == null && Fragger == null)
            {
               
                var query2 = query.GroupBy(e => e.userGame.user.id).ToList();


                string yas = fc["yas"];
                int minHours = int.Parse(fc["minHours"]);
                int maxHours = int.Parse(fc["maxHours"]);

                foreach (var item in query2)
                {
                    users u = db.user.Find(item.Key);
                    if (yas == "-16")
                    {
                        if (DateTime.Now.Year - u.dateOfBirth.Year < 16)
                        {
                            if (minHours == 0 && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }

                        }

                    }
                    else if (yas == "+16")
                    {
                        if (DateTime.Now.Year - u.dateOfBirth.Year > 16)
                        {
                            if (minHours == 0 && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                        }

                    }
                    else
                    {
                        if (minHours == 0 && maxHours == 0)
                        {
                            liste.Add(u);
                        }
                        else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                        {
                            liste.Add(u);
                        }
                        else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                        {
                            liste.Add(u);
                        }
                        else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                        {
                            liste.Add(u);
                        }
                    }

                }


            }
            else
            {
                var q = q1.Union(q2).Union(q3).Union(q4).Union(q5).Union(q6).ToList();
                
                var query2 = q.GroupBy(e => e.userGame.user.id).ToList();


                string yas = fc["yas"];
                int minHours = int.Parse(fc["minHours"]);
                int maxHours = int.Parse(fc["maxHours"]);

                foreach (var item in query2)
                {
                    users u = db.user.Find(item.Key);
                    if (yas == "-16")
                    {
                        if (DateTime.Now.Year - u.dateOfBirth.Year < 16)
                        {
                            if (minHours == 0 && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }

                        }

                    }
                    else if (yas == "+16")
                    {
                        if (DateTime.Now.Year - u.dateOfBirth.Year > 16)
                        {
                            if (minHours == 0 && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                            {
                                liste.Add(u);
                            }
                            else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                            else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                            {
                                liste.Add(u);
                            }
                        }

                    }
                    else
                    {
                        if (minHours == 0 && maxHours == 0)
                        {
                            liste.Add(u);
                        }
                        else if (u.userGame.Find(e => e.game.id == 2).time > minHours && maxHours == 0)
                        {
                            liste.Add(u);
                        }
                        else if (minHours == 0 && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                        {
                            liste.Add(u);
                        }
                        else if (u.userGame.Find(e => e.game.id == 2).time > minHours && u.userGame.Find(e => e.game.id == 2).time < maxHours)
                        {
                            liste.Add(u);
                        }
                    }

                }


            }
               

                return View(liste);
            
        }

        public ActionResult SearchLol()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Search(FormCollection fc)
        {

        }
    }
}



//var q = (from userGameDesc in db.userGameDesc
//         where userGameDesc.compAtt.value == (string.IsNullOrEmpty(AWP) ? AWP : userGameDesc.compAtt.value)
//         || userGameDesc.compAtt.value == (string.IsNullOrEmpty(Lurker) ? Lurker : userGameDesc.compAtt.value)
//         || userGameDesc.compAtt.value == (string.IsNullOrEmpty(Rifler) ? Rifler : userGameDesc.compAtt.value)
//         || userGameDesc.compAtt.value == (string.IsNullOrEmpty(IGL) ? IGL : userGameDesc.compAtt.value)
//         || userGameDesc.compAtt.value == (string.IsNullOrEmpty(Supporter) ? Supporter : userGameDesc.compAtt.value)
//         || userGameDesc.compAtt.value == (string.IsNullOrEmpty(Fragger) ? Fragger : userGameDesc.compAtt.value)
//         group userGameDesc by userGameDesc.userGame.user.id into g
//         select (g)).ToList();