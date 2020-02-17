using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Collectly
{

   partial class Startup
   {

      private AppSettings AppSettings { get; set; }
      private void AddSettings(IServiceCollection services)
      {
         var appSettingsSection = this.Configuration.GetSection("AppSettings");
         services.Configure<AppSettings>(appSettingsSection);
         this.AppSettings = appSettingsSection.Get<AppSettings>();
      }

      private void UseSettings(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         { app.UseDeveloperExceptionPage(); }
         else
         {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days.
            // You may want to change this for production scenarios,
            // see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         app.UseHttpsRedirection();

         app.UseStaticFiles();
         if (!env.IsDevelopment())
         { app.UseSpaStaticFiles(); }
      }

   }

   public class AppSettings
   {
      public string ConnStr { get; set; }
   }

}