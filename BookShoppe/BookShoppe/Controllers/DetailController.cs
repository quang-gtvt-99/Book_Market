using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShoppe.Controllers;
using BookShoppe.Models;
using BookMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookShoppe.Controllers
{
    public class DetailController : Controller
    {
        private readonly Book_MarketContext _BMContext;
        private readonly ILogger<DetailController> _logger;
        public const string CARTKEY = "cart";
        public DetailController(ILogger<DetailController> logger, Book_MarketContext BMContext)
        {
            _logger = logger;
            _BMContext = BMContext;
        }
        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Thông tin số điện thoại là bắt buộc")]
            [MaxLength(15, ErrorMessage = "Số điện thoại tối đa 15 số")]
            [MinLength(5, ErrorMessage = "Số điện thoại tối thiểu 5 số")]
            [Phone]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Định dạng số điện thoại không đúng")]
            [Display(Name = "Phone")]
            public string Phone { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Thông tin tên người dùng là bắt buộc")]
            [MaxLength(30, ErrorMessage = "Tối đa 30 kí tự")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Date")]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            [Required]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }

            [Required]
            [MaxLength(30, ErrorMessage = "Tối đa 30 kí tự")]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Thông tin email là bắt buộc")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Thông tin mật khẩu là bắt buộc")]
            [StringLength(100, ErrorMessage = "Mật khẩu ít nhất 6 kí tự và tối đa 100 kí tự", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Nhập mật khẩu cần xác nhận")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Mật khẩu đang không giống nhau")]
            public string ConfirmPassword { get; set; }
        }
        public InputModel Input { get; set; }

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
            return View(GetCartItems());
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