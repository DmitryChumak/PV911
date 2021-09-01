using CarShop.Models;
using CarShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index(SortType sortType = SortType.TitleAsc, string company = "(all)")
        {
            List<Car> cars = null;
            List<string> companies = new List<string> { "(all)" };
            companies.AddRange(context.Cars.Select(x => x.Title).Distinct());
            switch (sortType)
            {
                case SortType.TitleAsc:
                    cars = context.Cars.OrderBy(x => x.Title).ToList();
                    break;
                case SortType.ModelAsc:
                    cars = context.Cars.OrderBy(x => x.Model).ToList();
                    break;
                case SortType.PriceAsc:
                    cars = context.Cars.OrderBy(x => x.Price).ToList();
                    break;
            }

            if (!company.Contains("all"))
                cars = cars.Where(x => x.Title.ToLower() == company.ToLower()).ToList();

            return View(new CarListViewModel
            {
                Cars = cars,
                Companies = new SelectList(companies)
            });
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
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
           
        }
    }

}
