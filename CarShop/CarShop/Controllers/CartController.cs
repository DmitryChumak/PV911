using CarShop.Extensions;
using CarShop.Models;
using CarShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CartController : Controller
    {
        CarContext context;
        public CartController(CarContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            }); ;
        }

        public IActionResult AddToCart(int carId, string returnUrl)
        {
            Car car = context.Cars.FirstOrDefault(x => x.CarId == carId);
            if (car != null)
            {
                var cart = GetCart();
                cart.AddItem(car, 1);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveFromCart(int carId, string returnUrl)
        {
            Car car = context.Cars.FirstOrDefault(x => x.CarId == carId);
            if (car != null)
            {
                var cart = GetCart();
                cart.RemoveLine(car);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetObjectAsJson("Cart",cart);
            }
            return cart;
        }
    }
}
