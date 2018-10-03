using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StuffForSale.Database;
using StuffForSale.Models;

namespace StuffForSale
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = @"Data Source=DESKTOP-S3EJN7J\\SQLEXPRESS01;Initial Catalog=StuffForSale;Integrated Security=True";

      services.AddDbContext<Database.EfcContext>(builder => builder.UseSqlServer(connectionString), ServiceLifetime.Transient);
      services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Database.EfcContext>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddMemoryCache();
      services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSession();
      app.UseCookiePolicy();
      app.UseAuthentication();

      app.UseMvcWithDefaultRoute();
    }
  }
}
