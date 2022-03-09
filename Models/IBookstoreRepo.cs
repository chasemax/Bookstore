using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IBookstoreRepo
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}
