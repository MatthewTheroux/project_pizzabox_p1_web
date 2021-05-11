// [I]. HEAD
//  A] Libraries
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Npgsql.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

using PizzaBox.Storage;

/// controlls the User eXperience
namespace PizzaBox.Client.Web
{
  /// where the web app starts
  public class Startup
  {
    //public IConfiguration Configuration { get; set; }
    private IConfiguration _configuration;

    private PizzaBoxContext _context;

    public Startup(IConfiguration configuration) { _configuration = configuration; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //  a) head
      /// Add controllers that navigate to pages.
      services.AddControllersWithViews();

      /// Add 'UnitOfWork' to access repositories.
      services.AddScoped<UnitOfWork>();


      /// Add the database connector.
      services.AddDbContext<PizzaBoxContext>(options =>
      {
        options.UseNpgsql(_configuration["pgsql"]);
        options.UseNpgsql("server=localhost; database=PizzaBoxDB; user id=postgres; password-postgres;“");

        /// Add user-secrets.
        options.UseNpgsql(_configuration.GetConnectionString("pgsql"), opts =>
          { opts.EnableRetryOnFailure(3); });
      });

    }// /md 'ConfigureServices'

    // [II]. BODY
    /// This method gets called by the runtime.  Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      // else
      // {
      //   app.UseExceptionHandler("/Home/Error");
      //   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      //   app.UseHsts();
      // }

      // <?>
      // app.UseHttpsRedirection();
      // app.UseStaticFiles();

      // Routes the app navigation.
      app.UseRouting();

      // app.UseAuthorization(); //<?>

      // An endpoint tells the navigation to stop.  It has reached its destination.
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

        // Use ___.
        endpoints.MapControllers();

        // endpoints.MapGet("/", async context =>
        // {
        //   await context.Response.WriteAsync("Hello World!");
        // });
      });// /'UseEndpoints'
    }// /md 'Configure'
  }// /cla Startup'
}// /ns '..Web'
 // EoF