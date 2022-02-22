﻿using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Components
{
    public class CategoryViewComponent : ViewComponent 
    {
        private IBookstoreRepo repo { get; set; }

        public CategoryViewComponent (IBookstoreRepo r)
        {
            repo = r;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}