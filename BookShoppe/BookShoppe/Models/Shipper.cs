using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Order = new HashSet<Order>();
        }

        public int ShiperId { get; set; }
        public string Company { get; set; }
        public int? Phone { get; set; }
        public int? Hnhcm { get; set; }
        public int? Orther { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
