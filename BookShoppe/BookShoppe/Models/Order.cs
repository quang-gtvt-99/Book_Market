using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ShiperId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public User Customer { get; set; }
        public Shipper Shiper { get; set; }
    }
}
