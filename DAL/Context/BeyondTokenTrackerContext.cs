using System;
using DAL.Context.Interfaces;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public partial class BeyondTokenTrackerContext : DbContext, IBeyondTokenTrackerContext
    {
        private readonly string _connectionString;

        public BeyondTokenTrackerContext()
        {
        }

        public BeyondTokenTrackerContext(DbContextOptions<BeyondTokenTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupDetail> GroupDetail { get; set; }
        public virtual DbSet<PointTransaction> PointTransaction { get; set; }
        public virtual DbSet<PointTransactionType> PointTransactionType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure our sql connection
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(_connectionString);
            else if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=BYNDR90PY20W\SQLEXPRESS; Database=BeyondTokenTracker;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupDetail>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupDetails)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupDetail_Group");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Badge_Group");
            });
            
            modelBuilder.Entity<PointTransaction>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.TransactionDate);

                entity.Property(e => e.AwardMessage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PointTransactionType)
                    .WithMany(p => p.PointTransactions)
                    .HasForeignKey(d => d.PointTransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointTransaction_PointTransactionType");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PointTransactions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointTransaction_Product");

                entity.HasOne(d => d.AwardFrom)
                    .WithMany(p => p.PointTransactionAwardFroms)
                    .HasForeignKey(d => d.AwardFromId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointTransaction_AwardFromId");

                entity.HasOne(d => d.AwardTo)
                    .WithMany(p => p.PointTransactionAwardTos)
                    .HasForeignKey(d => d.AwardToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointTransaction_AwardToId");
            });

            modelBuilder.Entity<PointTransactionType>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.RoleId })
                    .IsUnique();

                entity.Property(e => e.AffectOnAwardFrom).HasDefaultValueSql("((1))");

                entity.Property(e => e.AffectOnAwardTo).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PointTransactionTypes)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointTransactionType_Role");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasIndex(e => e.ProductGroupId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Points).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductGroup");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();
                
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Role")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.GroupId);

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Group");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");


            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
