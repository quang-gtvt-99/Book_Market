using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }
        public string Location { get; set; }

        public Products Product { get; set; }
    }
}
