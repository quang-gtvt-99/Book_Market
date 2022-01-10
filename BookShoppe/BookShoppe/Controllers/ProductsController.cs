using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Models;
using BookShoppe.Models;
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
        public async Task<IActionResult> ListProduct()
        {
            return View(_BMContext.Products.ToList());
        }
        //public async Task<IActionResult> TypeProduct(int type)
        //{
        //    var sp = from s in _BMContext.Products
        //             select s;
        //    return View(sp.Where(s => s.CategoryId == type).ToListAsync());
        //}


        public async Task<IActionResult> AllProduct(
        int? type,
        string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var sp = from s in _BMContext.Products
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            { 
                type = 10;
            }
            switch (sortOrder)
            {
                case "giam":
                    sp = sp.OrderByDescending(s => s.GiaBan);
                    break;
                case "tang":
                    sp = sp.OrderBy(s => s.GiaBan);
                    break;
                default:
                    sp = sp.OrderBy(s => s.ProductName);
                    break;
            }
            DateTime d = DateTime.Now;
           // string startDate = "01/10/2021";
            DateTime d1 = d.AddMonths(-3);
            
            switch (type)
            {
                case 1:
                    sp = sp.Where(s => s.CategoryId == 1);
                    ViewBag.Typetitle = "Sách văn học";
                    break;
                case 2:
                    sp = sp.Where(s => s.CategoryId == 2);
                    ViewBag.Typetitle = "Sách kinh tế";
                    break;
                case 3:
                    sp = sp.Where(s => s.CategoryId == 3);
                    ViewBag.Typetitle = "Sách đời sống";
                    break;
                case 4:
                    sp = sp.Where(s => s.CategoryId == 4);
                    ViewBag.Typetitle = "Sách thiếu nhi";
                    break;
                case 5:
                    sp = sp.Where(s => s.CategoryId == 5);
                    ViewBag.Typetitle = "Sách tin học - ngoại ngữ";
                    break;
                case 6:
                    sp = sp.Where(s => s.CategoryId == 6);
                    ViewBag.Typetitle = "Tạp chí văn phòng phẩm";
                    break;
                case 7:
                    var  sp1 = sp.Where(s => s.ReleaseDate <= d );
                    sp = sp1.Where(s => s.ReleaseDate >= d1);
                    ViewBag.Typetitle = "Sách mới phát hành";
                    break;
                case 10:
                    ViewBag.Typetitle = "Tìm kiếm sản phẩm với từ khóa : #" +searchString+ "#";
                    sp = sp.Where(s => s.ProductName.Contains(searchString)
                                       || s.ProductName.Contains(searchString));
                    break;
                default:
                    sp = sp.OrderByDescending(s => s.ProductName);
                    ViewBag.Typetitle = "Tất cả sản phẩm";
                    break;

            }
            int pageSize = 6;
            return View(await PaginatedList<Products>.CreateAsync(sp.AsNoTracking(), pageNumber ?? 1, pageSize));
        }  
        
    }
}