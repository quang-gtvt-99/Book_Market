using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlideId { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }

        public Products Product { get; set; }
    }
}
