using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFBookstoreRepo : IBookstoreRepo
    {
        private BookstoreContext _bc { get; set; }

        public EFBookstoreRepo(BookstoreContext t) => _bc = t;

        public IQueryable<Book> Books => _bc.Books;
    }
}
