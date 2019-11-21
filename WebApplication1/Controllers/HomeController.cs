using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(WelcomeModel model)
        {
            WelcomeModel user = null;
            using (var db = new WelcomeContext()) //использование контекста
            {
                user = db.welcomers.Where(x => x.name == model.name && x.profession == model.profession)
                    .ToList()[0];
            }

            if (user == null)
            {
                ViewBag.Message =
                    "Добро пожаловать! Пожалуйста, перед тем, как выйти из здания подойдите к соответствующему окну!";

                using (var db = new WelcomeContext())
                {
                    db.Add(new WelcomeModel {isinbuilding = true, lastin = DateTime.Now,
                        profession = model.profession, name = model.name});
                }

                return View();
            }
            ViewBag.Message =
                "Добро пожаловать!";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
