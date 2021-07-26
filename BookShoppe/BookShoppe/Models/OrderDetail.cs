using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Unit { get; set; }
        public int? DiscountId { get; set; }

        public Discount Discount { get; set; }
        public Products Product { get; set; }
    }
}
