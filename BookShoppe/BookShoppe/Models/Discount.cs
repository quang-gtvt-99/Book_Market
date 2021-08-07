using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Discount
    {
        public Discount()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
