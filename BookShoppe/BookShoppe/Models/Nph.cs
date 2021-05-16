using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Nph
    {
        public Nph()
        {
            Products = new HashSet<Products>();
        }

        public int Nphid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Detail { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
