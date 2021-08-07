using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BookMarket.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BookMarketUser class
    public class BookMarketUser : IdentityUser
    {
       
        public string Address { get; set; } 
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }   
        public DateTime? Birdday { get; set; }

    }
}
