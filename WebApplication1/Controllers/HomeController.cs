using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<WelcomeModel> welcomers=new List<WelcomeModel>(); //создание нового листа
            using (var db =new WelcomeContext()) //использование контекста
            {
                db.welcomers.Add(new WelcomeModel { id=8, cost = 5200}); //добавление в таблицу welcomers
                db.SaveChanges(); //сохранение изменение в таблице
                welcomers = db.welcomers.ToList(); //перевод из таблицы бд в лист
            }

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
