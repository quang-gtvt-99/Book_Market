using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class CartItem
    {
        public int quantity { set; get; }
        public Products product { set; get; }
        public int total { get; set; }
        public Order order { get; set; }
        public OrderDetail orderDetail { get; set; }


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

        [Required]
        [MaxLength(30, ErrorMessage = "Tối đa 30 kí tự")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Thông tin email là bắt buộc")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Tối đa 30 kí tự")]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string Country { get; set; }
    }
}
