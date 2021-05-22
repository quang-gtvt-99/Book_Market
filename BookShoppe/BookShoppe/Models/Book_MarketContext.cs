using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMarket.Models
{
    public partial class Book_MarketContext : DbContext
    {
        public Book_MarketContext()
        {
        }

        public Book_MarketContext(DbContextOptions<Book_MarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<HotSale> HotSale { get; set; }
        public virtual DbSet<Nph> Nph { get; set; }
        public virtual DbSet<Nxb> Nxb { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=THINKPAD-E580\\MSSQLSERVERTP; Database=Book_Market; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId)
                    .HasColumnName("AuthorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.Decription).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(50);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.HasKey(e => new { e.FbId, e.ProductId });

                entity.Property(e => e.FbId).HasColumnName("FbID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Contents).HasMaxLength(500);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_FeedBack_Products");
            });

            modelBuilder.Entity<HotSale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductId });

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.HotSale)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_HotSale_Products");
            });

            modelBuilder.Entity<Nph>(entity =>
            {
                entity.ToTable("NPH");

                entity.Property(e => e.Nphid)
                    .HasColumnName("NPHID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Detail).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.ToTable("NXB");

                entity.Property(e => e.Nxbid)
                    .HasColumnName("NXBID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasMaxLength(50);

                entity.Property(e => e.ShipCity).HasMaxLength(50);

                entity.Property(e => e.ShiperId).HasColumnName("ShiperID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Order_User");

                entity.HasOne(d => d.Shiper)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShiperId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Order_Shipper");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Discount).HasMaxLength(20);

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).HasColumnName("authorID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Format).HasMaxLength(10);

                entity.Property(e => e.Language).HasMaxLength(20);

                entity.Property(e => e.Nphid).HasColumnName("NPHID");

                entity.Property(e => e.NumPage).HasColumnName("numPage");

                entity.Property(e => e.Nxbid).HasColumnName("NXBID");

                entity.Property(e => e.ProductImg)
                    .HasColumnName("productIMG")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(50);

                entity.Property(e => e.Quanity)
                    .HasColumnName("quanity")
                    .HasMaxLength(10);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("releaseDate")
                    .HasColumnType("date");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Products_Author");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Nph)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Nphid)
                    .HasConstraintName("FK_Products_NPH");

                entity.HasOne(d => d.Nxb)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Nxbid)
                    .HasConstraintName("FK_Products_NXB");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(e => e.ShiperId);

                entity.Property(e => e.ShiperId)
                    .HasColumnName("ShiperID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Hnhcm).HasColumnName("HNHCM");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.SlideId)
                    .HasColumnName("SlideID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });
        }
    }
}
