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

       
        public IActionResult Index()
        {
            var spbanchay =  from p in _BMContext.Products
                             join a in _BMContext.Author on p.AuthorId equals a.AuthorId
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