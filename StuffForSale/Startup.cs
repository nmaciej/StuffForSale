using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
      
      services.AddDbContext<Contexts.ProgramDbContext>(builder => builder.UseSqlServer(connectionString),ServiceLifetime.Transient);

      services.AddDbContext<Contexts.ProgramIdentityDbContext>(builder => builder.UseSqlServer(connectionString));
      services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Contexts.ProgramIdentityDbContext>();
      
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseIdentity();

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvcWithDefaultRoute();
    }
  }
}
