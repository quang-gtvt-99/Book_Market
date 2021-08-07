using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BookShoppe.Controllers;
using IdentityServer4.Models;

namespace BookMarket.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

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

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Name = Input.Name,
                    Email = Input.Email,
                    Password = Input.Password,
                    Address = Input.Address,
                    Phone = Input.Phone,
                    CreatedAt = DateTime.Now,

                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
