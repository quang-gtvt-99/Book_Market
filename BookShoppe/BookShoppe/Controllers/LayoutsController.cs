using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using BookShoppe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShoppe.Controllers
{
    public class LayoutsController : Controller
    {
        public IActionResult Layouts()
        {
            return View();
        }
       
    }
}