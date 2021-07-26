using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Nxb
    {
        public Nxb()
        {
            Products = new HashSet<Products>();
        }

        public int Nxbid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Decreption { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
