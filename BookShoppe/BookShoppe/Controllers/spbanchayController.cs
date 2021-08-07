using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppe.Controllers
{
    public class spbanchayController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        public spbanchayController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }


        public PartialViewResult spbanchay()
        {
            var spbanchay = from p in _BMContext.Products
                            join a in _BMContext.Author on p.AuthorId equals a.AuthorId
                            select new spbanchay
                            {

                                ProductImg = p.ProductImg,
                                ProductName = p.ProductName,
                                GiaBia = p.GiaBia,
                                GiaBan = p.GiaBan,
                                Authorname = a.Name,
                            };

            return PartialView(spbanchay);
        }
    }
}