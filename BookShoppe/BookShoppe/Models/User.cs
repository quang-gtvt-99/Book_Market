using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            Permission = new HashSet<Permission>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Permission> Permission { get; set; }
    }
}
