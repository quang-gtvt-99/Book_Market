using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Products
    {
        public Products()
        {
            FeedBack = new HashSet<FeedBack>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public int? CategoryId { get; set; }
        public string Decription { get; set; }
        public string Detail { get; set; }
        public int? GiaBia { get; set; }
        public int? GiaBan { get; set; }
        public string Quanity { get; set; }
        public int AuthorId { get; set; }
        public int Nxbid { get; set; }
        public int Nphid { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Author Author { get; set; }
        public Categories Category { get; set; }
        public Nph Nph { get; set; }
        public Nxb Nxb { get; set; }
        public ICollection<FeedBack> FeedBack { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
