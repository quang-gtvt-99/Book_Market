using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShoppe.Controllers;
using BookShoppe.Models;
using BookMarket.Models;

namespace BookShoppe.Controllers
{
    public class IndexController : Controller
    {
        private readonly Book_MarketContext bmcontext = new Book_MarketContext(); 
        public IActionResult Index()
        {
            var sp = this.bmcontext.User.ToArray();
            return View();
        }
        
    }
}