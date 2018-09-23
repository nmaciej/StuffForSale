using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Models;

namespace StuffForSale.Context
{
  public class Context : DbContext
  {
    public DbSet<Product> Products { get; set; }

    public Context(DbContextOptions<Context> options)
      : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      var cs = "Data Source=DESKTOP-S3EJN7J\\SQLEXPRESS01;Initial Catalog=StuffForSale;Integrated Security=True";
      optionsBuilder.UseSqlServer(cs);
    }
  }
}
