using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {

        private IBookstoreRepo repo { get; set; }

        public Cart cart { get; set; }
        public string returnURL { get; set; }

        public CartModel (IBookstoreRepo r)
        {
            repo = r;
        }

        public void OnGet(string url)
        {
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            returnURL = url ?? "/";
        }

        public IActionResult OnPost(int BookId, string url)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            cart.AddToCart(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { url = url });
        }
    }
}
