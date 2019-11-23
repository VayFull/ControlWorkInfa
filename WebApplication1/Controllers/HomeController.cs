using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(WelcomeModel model)
        {
            WelcomeModel user = null;
            using (var db = new WelcomeContext()) //использование контекста
            {
                user = db.welcomers.Where(x => x.name == model.name && x.profession == model.profession)
                    .FirstOrDefault();
            }

            if (user == null)
            {
                ViewBag.Message =
                    "Добро пожаловать! Вы автоматически зарегистрированы! Пожалуйста, перед тем, как выйти из здания подойдите к соответствующему окну!";

                using (var db = new WelcomeContext())
                {
                    db.Add(new WelcomeModel {isinbuilding = true, lastin = DateTime.Now,
                        profession = model.profession, name = model.name});
                    db.SaveChanges();
                }
                return View();
            }
            ViewBag.Message = "Добро пожаловать!";
            return View();
        }

        private void AddDataInVisit(WelcomeModel user)
        {
            using (var db = new VisitContext())
            {
                db.Add(new VisitModel { timein = user.lastin, userid = user.id, timeout = DateTime.Now});
                db.SaveChanges();
            }
        }

        public IActionResult About()
        {
            @ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult About(WelcomeModel model)
        {
            WelcomeModel user = null;
            using (var db = new WelcomeContext())
            {
                user = db.welcomers.Where(x => x.name == model.name && x.profession == model.profession).FirstOrDefault();
                user.lastout=DateTime.Now;
            }
            AddDataInVisit(user);
            using (var db = new VisitContext())
            {
                db.Update(user);
            }
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
