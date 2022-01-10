using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Shipper
    {
        public int ShiperId { get; set; }
        public string Company { get; set; }
        public long? InCity { get; set; }
        public long? OurCity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
