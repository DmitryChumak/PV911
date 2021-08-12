using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        CarContext context;
        public HomeController(CarContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Cars.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.CarId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
