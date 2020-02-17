using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Collectly
{
   partial class Startup
   {

      private void AddControllers(IServiceCollection services)
      {
         services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
               options.JsonSerializerOptions.IgnoreNullValues = true;
               options.JsonSerializerOptions.PropertyNamingPolicy = null; // use PascalCase
               options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
         services.AddSpaStaticFiles(configuration =>
         {
            configuration.RootPath = "ClientApp/dist";
         });
      }

      private void UseControllers(IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseRouting();

         // app.UseAuthentication();
         // app.UseAuthorization();

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