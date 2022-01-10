using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShoppe.Controllers;
using BookShoppe.Models;
using BookMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BookShoppe.Controllers
{
    public class IndexController : Controller
    {
       
        private readonly Book_MarketContext _BMContext;
        public IndexController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
        List<spbanchay> getBestSale()
        {

            var spbanchay =  _BMContext.Products.Include(i => i.Category)
                .Include(s => s.Nph)
                .Include(s => s.Nxb)
                .Include(s => s.Author).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductId == 1)
                ;
            
            return new List<spbanchay>();
        }
        public IActionResult getBestSaler()
        {
            var bestSale = _BMContext.Products.Include(i => i.Category)
                .Include(s => s.Nph)
                .Include(s => s.Nxb)
                .Include(s => s.Author).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductId == 1)
                ;
            ViewBag.spbanchay = bestSale;
            return RedirectToAction(nameof(Index));
        } 

        public IActionResult Index()
        {
           
            var sp =  from p in _BMContext.Products
                             join a in _BMContext.Categories on p.CategoryId equals a.CategoryId
                             select new spbanchay
                             {
                                 ProductImg = p.ProductImg,
                                 ProductName = p.ProductName,
                                 GiaBia = p.GiaBia,
                                 GiaBan = p.GiaBan,
                             }
                             ;
                
            return View(_BMContext.Products.ToList());
        }

      
    }
}