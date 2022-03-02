using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class CheckoutController : Controller
    {
        ICheckoutRepo repo { get; set; }
        Cart cart { get; set; }

        public CheckoutController(ICheckoutRepo t, Cart c)
        {
            repo = t;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Checkout c)
        {
            if (cart.BooksToBuy.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                c.BooksToBuy = cart.BooksToBuy;
                repo.SavePurchase(c);
                return RedirectToPage("/CheckoutConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
