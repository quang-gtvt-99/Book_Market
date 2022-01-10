using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public partial class spbanchay
    {
        public spbanchay() {       
        }
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public int? CategoryId { get; set; }
        public string Decription { get; set; }
        public string Detail { get; set; }
        public long? GiaBia { get; set; }
        public long? GiaBan { get; set; }
        public string Quanity { get; set; }
        public int AuthorId { get; set; }
        public int Nxbid { get; set; }
        public int Nphid { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Weight { get; set; }
        public string Format { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Language { get; set; }
        public string Size { get; set; }
        public int? PageNumber { get; set; }
        public string Authorname { get; set; }
        public string Star { get; set; }
    }
}
