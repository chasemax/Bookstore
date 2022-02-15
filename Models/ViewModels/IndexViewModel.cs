using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class IndexViewModel
    {
        public IQueryable<Book> BooksToDisplay { get; set; }
        public IndexPageInfo PageInfo { get; set; }
    }
}
