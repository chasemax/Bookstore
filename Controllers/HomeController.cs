using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepo _bkrepo;

        public HomeController(IBookstoreRepo t) => _bkrepo = t;

        public IActionResult Index(int pageNum = 1)
        {
            IndexViewModel ivm = new IndexViewModel();
            int pageSize = 10;

            IQueryable<Book> pageBooks = _bkrepo.Books
                .OrderBy(x => x.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize);
            ivm.BooksToDisplay = pageBooks;
            ivm.PageInfo = new IndexPageInfo();

            ivm.PageInfo.PageSize = pageSize;
            ivm.PageInfo.BookCount = _bkrepo.Books.Count();
            ivm.PageInfo.CurrentPage = pageNum;

            return View(ivm);
        }
    }
}
