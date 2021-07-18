using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShoppe.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public ProductsController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
        public async Task<IActionResult> AllProduct()
        {

            return View(await _BMContext.Products.ToListAsync());
        }
        public ViewResult ListProduct()
        {
            return View();
        }
    }
}