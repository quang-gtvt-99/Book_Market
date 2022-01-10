using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Products
    {
        public Products()
        {
            Banner = new HashSet<Banner>();
            FeedBack = new HashSet<FeedBack>();
            HotSale = new HashSet<HotSale>();
            OrderDetail = new HashSet<OrderDetail>();
            Slide = new HashSet<Slide>();
        }

        [BindProperty]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public int? CategoryId { get; set; }
        public string Decription { get; set; }
        public string Detail { get; set; }
        public int? GiaBia { get; set; }
        public int? GiaBan { get; set; }
        public string Quanity { get; set; }
        public int? AuthorId { get; set; }
        public int? Nxbid { get; set; }
        public int? Nphid { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Weight { get; set; }
        public string Format { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Language { get; set; }
        public string Size { get; set; }
        public int? PageNumber { get; set; }

        public virtual Author Author { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Nph Nph { get; set; }
        public virtual Nxb Nxb { get; set; }
        public virtual ICollection<Banner> Banner { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        public virtual ICollection<HotSale> HotSale { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Slide> Slide { get; set; }
    }
}
