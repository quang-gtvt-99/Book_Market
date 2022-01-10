using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShoppe.Controllers
{
    public class spbanchayController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public spbanchayController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }


        public async Task<PartialViewResult>  spbanchay()
        {
            ViewBag.spbanchay = new Products()
            {

            };
            var sp = new Products();
            //var spbanchay = from p in _BMContext.Products
            //                join a in _BMContext.Author on p.AuthorId equals a.AuthorId
            //                select new spbanchay
            //                {

            //                    ProductImg = p.ProductImg,
            //                    ProductName = p.ProductName,
            //                    GiaBia = p.GiaBia,
            //                    GiaBan = p.GiaBan,
            //                    Authorname = a.Name,
            //                };
            var spbanchay = await _BMContext.Products.Include(i => i.Category)
                .Include(s => s.Nph)
                .Include(s => s.Nxb)
                .Include(s => s.Author).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductId == 1)
                ;
            ViewBag.spbanchay = spbanchay;

            return PartialView(spbanchay);
        }
    }
}