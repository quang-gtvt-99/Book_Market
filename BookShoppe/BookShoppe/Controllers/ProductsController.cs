using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppe.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult AllProduct()
        {
            return View();
        }
        public ViewResult ListProduct()
        {
            return View();
        }
    }
}