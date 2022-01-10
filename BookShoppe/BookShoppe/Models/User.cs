using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class User
    {
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
    }
}
