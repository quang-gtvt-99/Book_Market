using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppe.Controllers
{
    public class HeaderController : Controller
    {
        public IActionResult Header()
        {
            return View();
        }
    }
}