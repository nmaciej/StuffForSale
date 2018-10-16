using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
  }
}
