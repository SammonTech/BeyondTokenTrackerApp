﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(BeyondTokenTrackerContext))]
    [Migration("20190406143431_addAwardFKs")]
    partial class addAwardFKs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("GroupId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Domain.Entities.Models.GroupDetail", b =>
                {
                    b.Property<int>("GroupDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BadgeImgSrc");

                    b.Property<int>("BadgeLevel");

                    b.Property<int>("GroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("GroupDetailId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupDetail");
                });

            modelBuilder.Entity("Domain.Entities.Models.PointTransaction", b =>
                {
                    b.Property<int>("PointTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwardFromId");

                    b.Property<string>("AwardMessage")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("AwardToId");

                    b.Property<int>("Points");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("TransactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("PointTransactionId");

                    b.HasIndex("AwardFromId");

                    b.HasIndex("AwardToId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionDate");

                    b.ToTable("PointTransaction");
                });

            modelBuilder.Entity("Domain.Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AffectOnTransaction")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("ProductGroupId");

                    b.HasKey("ProductId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.Entities.Models.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ProductGroupId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductGroup");
                });

            modelBuilder.Entity("Domain.Entities.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("RoleId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Role");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Domain.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("GroupId");

                    b.Property<string>("ImgSrc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Models.GroupDetail", b =>
                {
                    b.HasOne("Domain.Entities.Models.Group", "Group")
                        .WithMany("GroupDetail")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GroupDetail_Group");
                });

            modelBuilder.Entity("Domain.Entities.Models.PointTransaction", b =>
                {
                    b.HasOne("Domain.Entities.Models.User", "AwardFrom")
                        .WithMany("PointTransactionAwardFrom")
                        .HasForeignKey("AwardFromId")
                        .HasConstraintName("FK_PointTransaction_AwardFromId");

                    b.HasOne("Domain.Entities.Models.User", "AwardTo")
                        .WithMany("PointTransactionAwardTo")
                        .HasForeignKey("AwardToId")
                        .HasConstraintName("FK_PointTransaction_AwardToId");

                    b.HasOne("Domain.Entities.Models.Product", "Product")
                        .WithMany("PointTransaction")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_PointTransaction_Product");
                });

            modelBuilder.Entity("Domain.Entities.Models.Product", b =>
                {
                    b.HasOne("Domain.Entities.Models.ProductGroup", "ProductGroup")
                        .WithMany("Product")
                        .HasForeignKey("ProductGroupId")
                        .HasConstraintName("FK_Product_ProductGroup");
                });

            modelBuilder.Entity("Domain.Entities.Models.User", b =>
                {
                    b.HasOne("Domain.Entities.Models.Group", "Group")
                        .WithMany("User")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_User_Group");

                    b.HasOne("Domain.Entities.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role");
                });
#pragma warning restore 612, 618
        }
    }
}
