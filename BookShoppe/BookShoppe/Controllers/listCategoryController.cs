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
    public class listCategoryController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public listCategoryController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
        public async Task<IActionResult> List()
        {
            return View(await _BMContext.Categories.ToListAsync());
        }
    }
}