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

        public void SaveBook(Book b)
        {
            _bc.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            _bc.Add(b);
            _bc.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            _bc.Remove(b);
            _bc.SaveChanges();
        }
    }
}
