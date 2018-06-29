using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace Collectly.Auth.Store
{
   public static class SeedManager
   {
      static string[] roleList = new string[] { "Owner", "Admin", "User", "Viewer" };

      internal static async void SeedData(this IApplicationBuilder app)
      {
         try
         { 
            using (var appServices = app.ApplicationServices.CreateScope())
            {
               await SeedRoles(appServices);
               // await SeedUsers(appServices);
               // await SeedClients(dbContext);
            }            
         }
         catch { }
      }

      private static async Task SeedRoles(IServiceScope appServices)
      {
         var roleManager = appServices.ServiceProvider.GetService<RoleManager<RoleData>>();
         if (roleManager == null) { return; }
         if (roleManager.Roles.Count() != 0) { return; }
         foreach (var roleName in roleList)
         {
            var role = new RoleData { Name = roleName, NormalizedName = roleName.ToUpper() };
            await roleManager.CreateAsync(role);
         }
      }

   }
}