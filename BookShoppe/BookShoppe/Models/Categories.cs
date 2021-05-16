using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Decription { get; set; }
        public string Image { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
