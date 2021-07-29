using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Discount
    {
        public Discount()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
