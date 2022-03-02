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

        public CartModel (IBookstoreRepo r, Cart c)
        {
            repo = r;
            cart = c;
        }

        public void OnGet(string url)
        {
            returnURL = url ?? "/";
        }

        public IActionResult OnPost(int BookId, string url)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            cart.AddToCart(b, 1);

            return RedirectToPage(new { url = url });
        }

        public IActionResult OnPostRemove(int BookId, string url)
        {
            cart.RemoveFromCart(cart.BooksToBuy.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage(new { url = url });
        }
    }
}
