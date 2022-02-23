using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public Cart ()
        {
            BooksToBuy = new List<LineItem>();
        }

        public List<LineItem> BooksToBuy { get; set; }

        public void AddToCart(Book b, int q)
        {
            LineItem existingLine = BooksToBuy.Where(x => x.Book.BookId == b.BookId).FirstOrDefault();

            if (existingLine == null)
            {
                LineItem newLine = new LineItem();
                newLine.Book = b;
                newLine.Quantity = q;
                BooksToBuy.Add(newLine);
            }
            else
            {
                existingLine.Quantity += q;
            }
        }

        public double CalculateTotal()
        {
            double sum = BooksToBuy.Sum(x => x.Book.Price * x.Quantity);
            return sum;
        }
    }

    public class LineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
