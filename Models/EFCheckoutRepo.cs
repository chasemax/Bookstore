using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFCheckoutRepo : ICheckoutRepo
    {
        private BookstoreContext _bc { get; set; }

        public EFCheckoutRepo(BookstoreContext temp) => _bc = temp;

        public IQueryable<Checkout> Checkouts => _bc.Checkouts.Include(x => x.BooksToBuy).ThenInclude(x => x.Book);

        public void SavePurchase(Checkout c)
        {
            _bc.AttachRange(c.BooksToBuy.Select(x => x.Book));

            if (c.CheckoutId == 0)
            {
                _bc.Checkouts.Add(c);
            }

            _bc.SaveChanges();
        }
    }
}
