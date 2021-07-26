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
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<HotSale> HotSale { get; set; }
        public virtual DbSet<Nph> Nph { get; set; }
        public virtual DbSet<Nxb> Nxb { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.BannerId)
                    .HasColumnName("bannerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Banner)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Banner_Products");
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

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId)
                    .HasColumnName("DiscountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Detail).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
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

                entity.Property(e => e.Decreption).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.ToTable("NXB");

                entity.Property(e => e.Nxbid)
                    .HasColumnName("NXBID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Decreption).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

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

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderDetail_Discount");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Products");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.Property(e => e.PerId)
                    .HasColumnName("PerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LevelUser).HasMaxLength(50);

                entity.Property(e => e.PmsCreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PmsDeletedAt).HasColumnType("date");

                entity.Property(e => e.PmsUser).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Permission_User");
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

                entity.Property(e => e.Nxbid).HasColumnName("NXBID");

                entity.Property(e => e.PageNumber).HasColumnName("pageNumber");

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

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.InCity).HasColumnName("inCity");

                entity.Property(e => e.OurCity).HasColumnName("ourCity");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.SlideId)
                    .HasColumnName("SlideID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Slide)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Slide_Products");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.IdStaff);

                entity.Property(e => e.IdStaff)
                    .HasColumnName("idStaff")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd).HasColumnName("CMND");

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Edu).HasMaxLength(50);

                entity.Property(e => e.FuncStaff)
                    .HasColumnName("funcStaff")
                    .HasMaxLength(50);

                entity.Property(e => e.LevelSlary).HasColumnName("levelSlary");

                entity.Property(e => e.LevelStaff)
                    .HasColumnName("levelStaff")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("date");
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

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });
        }
    }
}
