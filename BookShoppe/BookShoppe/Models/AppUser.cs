using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class AppUser : IdentityUser
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
      
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Birdday { get; set; }
       
    }
}
