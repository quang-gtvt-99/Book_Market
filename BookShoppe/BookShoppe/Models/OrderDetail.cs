using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Unit { get; set; }
        public int? DiscountId { get; set; }
        public int? Amount { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Products Product { get; set; }
    }
}
