using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public List<LineItem> BooksToBuy { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string CustomerFirst { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string CustomerLast { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string DeliveryAddress { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string DeliveryCity { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string DeliveryState { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        public string DeliveryZip { get; set; }

        public bool IsPOBox { get; set; }

        public bool Shipped { get; set; } = false;
    }
}
