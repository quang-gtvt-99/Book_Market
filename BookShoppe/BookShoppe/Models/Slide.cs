using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Slide
    {
        public int SlideId { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
