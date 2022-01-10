using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookShoppe.Controllers
{
   
    public class CheckoutController : Controller
    {
        public const string CARTKEY = "cart";
        private readonly Book_MarketContext _BMContext;
        public CheckoutController(Book_MarketContext _MarketContext)
        {
            _BMContext = _MarketContext;
        }
        
        
    }
}