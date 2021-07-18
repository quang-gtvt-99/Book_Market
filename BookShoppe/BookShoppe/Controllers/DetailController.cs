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
    public class DetailController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public DetailController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
           var detail = await _BMContext.Products.Include(i => i.Category)
                .Include(s=>s.Nph)
                .Include(s=>s.Nxb)
                .Include(s => s.Author).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductId == id)
                ;

            if (detail == null)
            {
                return NotFound();
            }
            
            return View(detail);
        }

    }
}