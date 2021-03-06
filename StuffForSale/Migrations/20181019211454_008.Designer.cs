﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StuffForSale.Database;

namespace StuffForSale.Migrations
{
    [DbContext(typeof(EfcContext))]
    [Migration("20181019211454_008")]
    partial class _008
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StuffForSale.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("BuyerId")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PostCode")
                        .IsRequired();

                    b.Property<string>("SellerId")
                        .IsRequired();

                    b.Property<int>("State");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("OrderId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StuffForSale.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("StuffForSale.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("TagId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new { ProductId = 1, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Advanced programming", Name = "ASP.NET Core MVC 2", Price = 119.99m, Quantity = 5, TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 2, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Stanisław Lem", Name = "Solaris", Price = 43.99m, Quantity = 2, TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 3, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Corolla", Name = "Toyota", Price = 1999.00m, Quantity = 1, TagId = 104, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 4, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Civic", Name = "Honda", Price = 2500.00m, Quantity = 1, TagId = 104, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 5, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Green", Name = "Sofa", Price = 99.00m, Quantity = 1, TagId = 107, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 6, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Python basics", Name = "Learn Python", Price = 35.00m, Quantity = 1, TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 7, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Python ML", Name = "Sklearn & Tensorflow", Price = 44.00m, Quantity = 1, TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                        new { ProductId = 8, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Oak", Name = "Chair", Price = 1599.00m, Quantity = 1, TagId = 107, UserId = "b3d46ee7-2dac-48ea-9e05-98d76b506c91" },
                        new { ProductId = 9, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "BOSH", Name = "Drill", Price = 345.00m, Quantity = 1, TagId = 105, UserId = "a0340822-14f8-4566-b6ee-4e3ef5c78703" },
                        new { ProductId = 10, DateAdded = new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), Description = "Flat", Name = "Screwdriver", Price = 15.00m, Quantity = 1, TagId = 105, UserId = "a0340822-14f8-4566-b6ee-4e3ef5c78703" }
                    );
                });

            modelBuilder.Entity("StuffForSale.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new { TagId = 103, Name = "Books" },
                        new { TagId = 104, Name = "Cars" },
                        new { TagId = 105, Name = "Others" },
                        new { TagId = 106, Name = "Clothes" },
                        new { TagId = 107, Name = "Furniture" }
                    );
                });

            modelBuilder.Entity("StuffForSale.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c", AccessFailedCount = 0, ConcurrencyStamp = "ae5ebbc6-ba14-4132-8714-a9f6aca723be", Email = "nmaciej@protonmail.com", EmailConfirmed = true, LockoutEnabled = true, NormalizedEmail = "NMACIEJ@PROTONMAIL.COM", NormalizedUserName = "MACIEK", PasswordHash = "AQAAAAEAACcQAAAAELAzZ3tmJKhfsN/fhGiVPdOBk/eXlUAIHHcL7PCLAI1vnOMpxlEmSB35k55kZcGUeA==", PhoneNumberConfirmed = false, SecurityStamp = "XMYKPC2LMH5E6DBEY6DGSAWZZJ6NL6M2", TwoFactorEnabled = false, UserName = "Maciek" },
                        new { Id = "a0340822-14f8-4566-b6ee-4e3ef5c78703", AccessFailedCount = 0, ConcurrencyStamp = "2b12c3c3-495c-41d1-b440-7d6128b8b8b8", Email = "tomek@gmail.com", EmailConfirmed = true, LockoutEnabled = true, NormalizedEmail = "TOMEK@GMAIL.COM", NormalizedUserName = "TOMEK", PasswordHash = "AQAAAAEAACcQAAAAEBV+zKkaD9R58syCgGx3mvRUzxt+hPywa9nTLpNNddanIa63J/QcH4K6UMOt/5txMQ==", PhoneNumberConfirmed = false, SecurityStamp = "OWUMF4V3ZJ2NYNXS4M5FNJNPPK6NOZ6U", TwoFactorEnabled = false, UserName = "Tomek" },
                        new { Id = "b3d46ee7-2dac-48ea-9e05-98d76b506c91", AccessFailedCount = 0, ConcurrencyStamp = "3769e618-c6c9-49e0-81b8-6ec173dd44fa", Email = "magda@gmail.com", EmailConfirmed = true, LockoutEnabled = true, NormalizedEmail = "MAGDA@GMAIL.COM", NormalizedUserName = "MAGDA", PasswordHash = "AQAAAAEAACcQAAAAENyD3d41SivJb80HeW+AVkDZcY/d3WdNwJFCaj3c1BB4U+acGCjSd6aNN3sRJBUWFA==", PhoneNumberConfirmed = false, SecurityStamp = "KLPSNGMDE435QGKUUF7SSTPRG6OOYDXF", TwoFactorEnabled = false, UserName = "Magda" },
                        new { Id = "e973450a-ae95-427a-8bf9-6eaa367bac15", AccessFailedCount = 0, ConcurrencyStamp = "6f5d76d0-33a6-4a30-a58d-5381e5e4003b", Email = "fleamarketstuffforsale@gmail.com", EmailConfirmed = true, LockoutEnabled = true, NormalizedEmail = "FLEAMARKETSTUFFFORSALE@GMAIL.COM", NormalizedUserName = "ADMIN", PasswordHash = "AQAAAAEAACcQAAAAEEKkaUCUXCB4DCuQJ3kw0fK/7wwZNYH0ZSo9fpoAO6B3r1R26XdrOfGh3Ons+oOrTQ==", PhoneNumberConfirmed = false, SecurityStamp = "OYG5PPEIRBJDZISCE62VMDZXOBYXM5YL", TwoFactorEnabled = false, UserName = "Admin" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StuffForSale.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StuffForSale.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StuffForSale.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StuffForSale.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StuffForSale.Models.Order", b =>
                {
                    b.HasOne("StuffForSale.Models.User", "UserBuyer")
                        .WithMany("BuyerOrders")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StuffForSale.Models.User", "UserSeller")
                        .WithMany("SellerOrders")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StuffForSale.Models.OrderDetail", b =>
                {
                    b.HasOne("StuffForSale.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StuffForSale.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StuffForSale.Models.Product", b =>
                {
                    b.HasOne("StuffForSale.Models.Tag", "Tag")
                        .WithMany("Products")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StuffForSale.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
