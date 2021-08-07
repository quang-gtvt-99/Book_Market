using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class User :IdentityUser
    {
        public User()
        {
            Order = new HashSet<Order>();
            Permission = new HashSet<Permission>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Birdday { get; set; }
        public int NewColumn { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Permission> Permission { get; set; }
    }
}
