using System;
using Hotstar_API.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project_Hotstar.Models.Authentication;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class HOTSTARDATAContext : IdentityDbContext<ApplicationUser>
    {
        public HOTSTARDATAContext()
        {
        }

        public HOTSTARDATAContext(DbContextOptions<HOTSTARDATAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<SubcriptionPriceList> SubcriptionPriceLists { get; set; }
        public virtual DbSet<SubscriptionDetail> SubscriptionDetails { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<VFreeMovie> VFreeMovies { get; set; }
        public virtual DbSet<VMovie> VMovies { get; set; }
        public virtual DbSet<VPremiumMovie> VPremiumMovies { get; set; }
        public virtual DbSet<VSport> VSports { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=VIRALGUJARATI\\SQLEXPRESS01;Database=HOTSTARDATA;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.Property(e => e.ContentLanguage)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink).IsRequired();

                entity.Property(e => e.ContentPosterLink).IsRequired();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Content__Categor__32E0915F");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Content__PlanId__33D4B598");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK__Content__SubCate__31EC6D26");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Plan");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.PlanCategory)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.ShowId).HasColumnName("ShowID");

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK__Shows__ContentId__3B75D760");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK__SubCatego__Paren__2A4B4B5E");
            });

            modelBuilder.Entity<SubcriptionPriceList>(entity =>
            {
                entity.ToTable("SubcriptionPriceList");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Validity)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.SubcriptionPriceLists)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Subcripti__PlanI__2F10007B");
            });

            modelBuilder.Entity<SubscriptionDetail>(entity =>
            {
                entity.ToTable("SubscriptionDetail");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfSubscription).HasColumnType("datetime");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.ValidThrough).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SubscriptionDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__Custo__36B12243");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.SubscriptionDetails)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__PlanI__37A5467C");

                entity.HasOne(d => d.SubcriptionPriceList)
                    .WithMany(p => p.SubscriptionDetails)
                    .HasForeignKey(d => d.SubcriptionPriceListId)
                    .HasConstraintName("FK__Subscript__Subcr__38996AB5");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__UserAcco__A4AE64B80FA68D9F");

                entity.ToTable("UserAccount");

                entity.HasIndex(e => e.Email, "UQ__UserAcco__A9D10534AF370B1F")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<VFreeMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vFreeMovie");

                entity.Property(e => e.ContentId).ValueGeneratedOnAdd();

                entity.Property(e => e.ContentLanguage)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink).IsRequired();

                entity.Property(e => e.ContentPosterLink).IsRequired();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMovies");

                entity.Property(e => e.ContentId).ValueGeneratedOnAdd();

                entity.Property(e => e.ContentLanguage)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink).IsRequired();

                entity.Property(e => e.ContentPosterLink).IsRequired();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VPremiumMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vPremiumMovie");

                entity.Property(e => e.ContentId).ValueGeneratedOnAdd();

                entity.Property(e => e.ContentLanguage)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink).IsRequired();

                entity.Property(e => e.ContentPosterLink).IsRequired();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VSport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSport");

                entity.Property(e => e.ContentId).ValueGeneratedOnAdd();

                entity.Property(e => e.ContentLanguage)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink).IsRequired();

                entity.Property(e => e.ContentPosterLink).IsRequired();

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

    }
}
