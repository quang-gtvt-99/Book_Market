using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShoppe.Controllers;
using BookShoppe.Models;
using BookMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShoppe.Controllers
{
    public class IndexController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public IndexController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
       
        public async Task<IActionResult> Index()
        {
            
            var SP = await _BMContext.Products.ToListAsync();
            var ListSP = new List<Products>();
            foreach(var sp in SP )
            {
               
            }
            return View(await _BMContext.Products.ToListAsync()); 
        }
        
    }
}