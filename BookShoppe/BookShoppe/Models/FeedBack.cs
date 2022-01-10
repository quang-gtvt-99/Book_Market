using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class FeedBack
    {
        public int FbId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public int? Star { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual Products Product { get; set; }
    }
}
