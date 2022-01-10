using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string NameKh { get; set; }
        public string PhoneKh { get; set; }
        public string Email { get; set; }

        public virtual AspNetUsers Customer { get; set; }
    }
}
