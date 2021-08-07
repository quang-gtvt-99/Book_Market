using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Banner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BannerId { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }
        public string Location { get; set; }

        public Products Product { get; set; }
    }
}
