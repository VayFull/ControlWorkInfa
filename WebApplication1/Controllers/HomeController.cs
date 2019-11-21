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
            List<Purchase> purchases=new List<Purchase>(); //создание нового листа
            using (var db =new PurchaseContext()) //использование контекста
            {
                db.purchases.Add(new Purchase { id=8, cost = 5200}); //добавление в таблицу purchases
                db.SaveChanges(); //сохранение изменение в таблице
                purchases = db.purchases.ToList(); //перевод из таблицы бд в лист
            }

            var a = purchases[0]; //что-то на паре делали

            Expression<Func<Purchase, bool >> b = x => x.id > 10;

            purchases.AsQueryable().Where(b).ToList();

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
