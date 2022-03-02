using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface ICheckoutRepo
    {
        IQueryable<Checkout> Checkouts { get; }

        void SavePurchase(Checkout c);
    }
}
