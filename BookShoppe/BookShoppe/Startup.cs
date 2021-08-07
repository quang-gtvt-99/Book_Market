using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookMarket.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.StaticFiles;
namespace BookShoppe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
            services.AddSession(cfg => {                    // Đăng ký dịch vụ Session
                cfg.Cookie.Name = "bookmarket";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                cfg.IdleTimeout = new TimeSpan(0, 60, 0);    // Thời gian tồn tại của Session
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var connectionStrings = Configuration.GetConnectionString("Server=THINKPAD-E580\\MSSQLSERVERTP; Database=Book_Market;Trusted_Connection=True;MultipleActiveResultSets=true");
            services.AddDbContext<Book_MarketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookMarketConnection")));
            services.AddDbContext<BookMarketContext>(options => {
                // Đọc chuỗi kết nối
                string connectstring = Configuration.GetConnectionString("BookMarketConnection");
                // Sử dụng MS SQL Server
                options.UseSqlServer(connectstring);
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<BookMarketContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

            });
            services.AddOptions();                                        // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

            services.AddTransient<IEmailSender, SendMailService>();        // Đăng ký dịch vụ Mail
            services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        // Đọc thông tin Authentication:Google từ appsettings.json
        IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
        // Thiết lập ClientID và ClientSecret để truy cập API google
        googleOptions.ClientId = googleAuthNSection["ClientId"];
        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
    })
    .AddFacebook(facebookOptions => {
        // Đọc cấu hình
        IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
        facebookOptions.AppId = facebookAuthNSection["AppId"];
        facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
        // Thiết lập đường dẫn Facebook chuyển hướng đến
        facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
            }
  
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseAuthentication();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Index}/{action=Index}/{id?}");
            });
        }
    }
}
