using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace BookShoppe.Controllers
{
    public class DetailController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        private readonly ILogger<DetailController> _logger;
        public const string CARTKEY = "cart";
        //public checkOut Input;
        public string ReturnUrl { get; set; }
        public DetailController(ILogger<DetailController> logger, Book_MarketContext BMContext)
        {
            _logger = logger;
            _BMContext = BMContext;
        }
        [HttpGet]
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
            ViewData.Model = new Products();
            
            if (detail == null)
            {
                return NotFound();
            }
            
            return View(detail);
        }
      
        [Route("AddToCart/{productid:int}")]
        public IActionResult AddToCart([FromRoute]int productid)
        { 
            var product = _BMContext.Products
                       .Where(p => p.ProductId == productid)
                       .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");


            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.ProductId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        [Route("/addInfo", Name = "addInfo")]
        public IActionResult addInfo()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = GetCartItems();
            var input = cart.Find(n => n.product.ProductId == 1);

            var orderIĐefault = _BMContext.Order.Select(i => i.OrderId).ToList();
            var odID = orderIĐefault.LastOrDefault() ;
            var odeID = odID + 1;

            var thanhtien = 0;
            foreach (var cartitem in GetCartItems())
            {
              thanhtien += Convert.ToInt32(cartitem.product.GiaBan * cartitem.quantity);
            }    
               
            var info = new Order()
            {   
                OrderId = odeID,
                CustomerId = userId,
                OrderDate = DateTime.Today,
                NameKh = "Nguyen Quang",
                PhoneKh = "0366775698",
                Email = "",
                ShipAddress = "Hà nội",
                ShipCity = "ha noi",
                Total = thanhtien,
                Status = "Đơn hàng chờ xác nhận",
                CreatedAt = DateTime.Today
            };
            if (info == null)
                return NotFound("Không có thông tin đăng kí");
            
            //var cartitem = cart.Find(p => p.order.ProductId == productid);
            //if (cartitem != null)
            //{
            //    // Đã tồn tại, tăng thêm 1
            //    cartitem.quantity++;
            //}
            //else
            {
                //  Thêm mới
                cart.Add(new CartItem() {order = info });
            }
            _BMContext.Order.Add(info);

            foreach (var cartitem in GetCartItems())
            {
                var detail = new OrderDetail()
                {
                    OrderId = odeID,
                    ProductId = cartitem.product.ProductId,
                    Unit = cartitem.quantity,
                    Amount = cartitem.product.GiaBan,

                };
                cart.Add(new CartItem() { orderDetail = detail });
                _BMContext.OrderDetail.Add(detail);
            }
            _BMContext.SaveChanges();
            SaveCartSession(cart);
            return RedirectToAction(nameof(ConfirmCheckout));
        }

        [Route("/ConfirmCheckout", Name = "ConfirmCheckout")]
        public IActionResult ConfirmCheckout()
        {
            
            _BMContext.SaveChanges();
            return View();
        }

        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute]int productid)
        {

            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.ProductId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm]int productid, [FromForm]int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...

            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.ProductId == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        [Route("/checkout")]
        public IActionResult CheckOut()
        {
            // Xử lý khi đặt hàng
            return View();
        }
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
       
       
    }
}