using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Collectly
{
   public partial class Startup
   {

      public IConfiguration Configuration { get; }
      public Startup(IConfiguration configuration)
      {
         this.Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {
         this.AddSettings(services);
         this.AddLocalization(services);

         services.AddControllersWithViews();
         // In production, the Angular files will be served from this directory
         services.AddSpaStaticFiles(configuration =>
         {
            configuration.RootPath = "ClientApp/dist";
         });
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         this.UseSettings(app, env);
         this.UseLocalization(app, env);

         app.UseRouting();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action=Index}/{id?}");
         });

         app.UseSpa(spa =>
         {
            // To learn more about options for serving an Angular SPA from ASP.NET Core,
            // see https://go.microsoft.com/fwlink/?linkid=864501

            spa.Options.SourcePath = "ClientApp";

            if (env.IsDevelopment())
            {
               spa.UseAngularCliServer(npmScript: "start");
            }
         });
      }
   }
}
