using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Unit { get; set; }
        public string Discount { get; set; }

        public Order Order { get; set; }
        public Products Product { get; set; }
    }
}
