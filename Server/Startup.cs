using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POS_Papeleria_Terrones.Server.Data;
using System.Linq;

namespace POS_Papeleria_Terrones.Server
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddDbContext<PosDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         services.AddControllersWithViews();
         services.AddRazorPages();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseWebAssemblyDebugging();
         }
         else
         {
            app.UseExceptionHandler("/Error");
         }

         app.UseBlazorFrameworkFiles();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
         });
      }
   }
}
