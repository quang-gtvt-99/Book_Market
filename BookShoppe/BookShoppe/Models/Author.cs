using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Author
    {
        public Author()
        {
            Products = new HashSet<Products>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Decreption { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
