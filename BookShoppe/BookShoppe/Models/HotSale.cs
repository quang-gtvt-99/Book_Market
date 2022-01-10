using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class HotSale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? PercentSale { get; set; }
        public int? Unit { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Products Product { get; set; }
    }
}
