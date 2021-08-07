using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Order = new HashSet<Order>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiperId { get; set; }
        public string Company { get; set; }
        public long? InCity { get; set; }
        public long? OurCity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
