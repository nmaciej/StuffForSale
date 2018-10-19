using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Models;

namespace StuffForSale.Database
{
  public class EfcContext : IdentityDbContext<User>
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    public EfcContext(DbContextOptions<EfcContext> options)
      : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      var cs = "Data Source=DESKTOP-S3EJN7J\\SQLEXPRESS01;Initial Catalog=StuffForSale;Integrated Security=True";
      optionsBuilder.UseSqlServer(cs);
    }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
      {
        relationship.DeleteBehavior = DeleteBehavior.Restrict;
      }

      base.OnModelCreating(modelbuilder);

      modelbuilder.Entity<User>().HasData(
  new User { Id = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c", UserName = "Maciek", NormalizedUserName = "MACIEK", Email = "nmaciej@protonmail.com", NormalizedEmail = "NMACIEJ@PROTONMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAELAzZ3tmJKhfsN/fhGiVPdOBk/eXlUAIHHcL7PCLAI1vnOMpxlEmSB35k55kZcGUeA==", SecurityStamp = "XMYKPC2LMH5E6DBEY6DGSAWZZJ6NL6M2", ConcurrencyStamp = "ae5ebbc6-ba14-4132-8714-a9f6aca723be", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0 },
  new User { Id = "a0340822-14f8-4566-b6ee-4e3ef5c78703", UserName = "Tomek", NormalizedUserName = "TOMEK", Email = "tomek@gmail.com", NormalizedEmail = "TOMEK@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEBV+zKkaD9R58syCgGx3mvRUzxt+hPywa9nTLpNNddanIa63J/QcH4K6UMOt/5txMQ==", SecurityStamp = "OWUMF4V3ZJ2NYNXS4M5FNJNPPK6NOZ6U", ConcurrencyStamp = "2b12c3c3-495c-41d1-b440-7d6128b8b8b8", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0 },
  new User { Id = "b3d46ee7-2dac-48ea-9e05-98d76b506c91", UserName = "Magda", NormalizedUserName = "MAGDA", Email = "magda@gmail.com", NormalizedEmail = "MAGDA@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAENyD3d41SivJb80HeW+AVkDZcY/d3WdNwJFCaj3c1BB4U+acGCjSd6aNN3sRJBUWFA==", SecurityStamp = "KLPSNGMDE435QGKUUF7SSTPRG6OOYDXF", ConcurrencyStamp = "3769e618-c6c9-49e0-81b8-6ec173dd44fa", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0 },
  new User { Id = "e973450a-ae95-427a-8bf9-6eaa367bac15", UserName = "Admin", NormalizedUserName = "ADMIN", Email = "fleamarketstuffforsale@gmail.com", NormalizedEmail = "FLEAMARKETSTUFFFORSALE@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEEKkaUCUXCB4DCuQJ3kw0fK/7wwZNYH0ZSo9fpoAO6B3r1R26XdrOfGh3Ons+oOrTQ==", SecurityStamp = "OYG5PPEIRBJDZISCE62VMDZXOBYXM5YL", ConcurrencyStamp = "6f5d76d0-33a6-4a30-a58d-5381e5e4003b", PhoneNumber = null, PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0 }
);

      modelbuilder.Entity<Tag>().HasData(
        new Tag { TagId = 103, Name = "Books" },
        new Tag { TagId = 104, Name = "Cars" },
        new Tag { TagId = 105, Name = "Others" },
        new Tag { TagId = 106, Name = "Clothes" },
        new Tag { TagId = 107, Name = "Furniture" }
        );

      modelbuilder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "ASP.NET Core MVC 2", Description = "Advanced programming", Price = 119.99m, Quantity = 5, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 2, Name = "Solaris", Description = "Stanisław Lem", Price = 43.99m, Quantity = 2, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 3, Name = "Toyota", Description = "Corolla", Price = 1999.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 104, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 4, Name = "Honda", Description = "Civic", Price = 2500.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 104, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 5, Name = "Sofa", Description = "Green", Price = 99.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 107, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 6, Name = "Learn Python", Description = "Python basics", Price = 35.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 7, Name = "Sklearn & Tensorflow", Description = "Python ML", Price = 44.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 103, UserId = "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
        new Product { ProductId = 8, Name = "Chair", Description = "Oak", Price = 1599.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 107, UserId = "b3d46ee7-2dac-48ea-9e05-98d76b506c91" },
        new Product { ProductId = 9, Name = "Drill", Description = "BOSH", Price = 345.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 105, UserId = "a0340822-14f8-4566-b6ee-4e3ef5c78703" },
        new Product { ProductId = 10, Name = "Screwdriver", Description = "Flat", Price = 15.00m, Quantity = 1, DateAdded = new DateTime(2018, 10, 19, 22, 01, 44), TagId = 105, UserId = "a0340822-14f8-4566-b6ee-4e3ef5c78703" }
        );

    }
  }
}
