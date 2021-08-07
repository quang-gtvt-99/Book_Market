using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class FeedBack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FbId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public int? Star { get; set; }
        public DateTime? CreateAt { get; set; }

        public Products Product { get; set; }
    }
}
