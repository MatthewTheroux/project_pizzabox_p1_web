using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PizzaBox.Storage;

namespace PizzaBox.Client
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddAntiforgery();
      services.AddScoped<UnitOfWork>(); // only one per session
      services.AddDbContext<PizzaBoxContext>(options =>
      {
        if (!string.IsNullOrWhiteSpace(Configuration.GetConnectionString("mssql")))
        {
          options.UseSqlServer(Configuration.GetConnectionString("mssql"), opts =>
          {
            opts.EnableRetryOnFailure(3);
          });
        }
        else
        {
          options.UseNpgsql(Configuration.GetConnectionString("pgsql"), opts =>
          {
            opts.EnableRetryOnFailure(3);
          });
        }
      });// /'AddDbCtx'
    }// /md 'ConfigureServices'

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PizzaBoxContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }// /ax 'Configure'

  }// /cla 'Startup'
}// /ns
 // EoF