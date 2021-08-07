using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarket.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookMarket.Models
{
    public class BookMarketContext : IdentityDbContext<AppUser>
    {
     
        public BookMarketContext(DbContextOptions<BookMarketContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
          
        }
        
    }
    public class BookMarketContextFactory : IDesignTimeDbContextFactory<BookMarketContext>
    {
        public BookMarketContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookMarketContext>();
            optionsBuilder.UseSqlServer("Your ConnectionString Here");
            return new BookMarketContext(optionsBuilder.Options);
        }
    }
}
