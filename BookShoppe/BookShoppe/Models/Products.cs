using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
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
        
        public Author Author { get; set; }
        public Categories Category { get; set; }
        public Nph Nph { get; set; }
        public Nxb Nxb { get; set; }
        public ICollection<Banner> Banner { get; set; }
        public ICollection<FeedBack> FeedBack { get; set; }
        public ICollection<HotSale> HotSale { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public ICollection<Slide> Slide { get; set; }
        public spbanchay spbanchay { get; set; }
        

    }
}
