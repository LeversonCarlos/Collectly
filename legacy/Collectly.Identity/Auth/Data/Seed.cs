using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Collectly.Auth.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Collectly.Auth;

namespace Collectly.Identity
{
   public static class Seed
    {
      static string[] roleList = new string[] { "Owner", "Admin", "User", "Viewer" };

      public static async void SeedData(this IApplicationBuilder app)
      {
         try
         {
            using (var appServices = app.ApplicationServices.CreateScope())
            {
               var dbContext = appServices.ServiceProvider.GetService<dbContext>();
               await ApplyClients(dbContext);
               await ApplyRoles(appServices, dbContext);
               await ApplyUsers(appServices, dbContext);
            }
         }
         catch (Exception ex) { throw ex; }
      }

      private async static Task ApplyClients(dbContext dbContext)
      {
         if (dbContext.Clients.Count() != 0) { return; }

         var clientList = new Client[] {
            new Client { ClientID="apiClientID", Secret="apiClientSecret", RefreshTokenLifetime=60*1, Active=true }
         };
         await dbContext.Clients.AddRangeAsync(clientList);
         await dbContext.SaveChangesAsync();

      }

      private async static Task ApplyRoles(IServiceScope appServices, dbContext dbContext)
      {
         if (dbContext.Roles.Count() != 0) { return; }
         var roleStore = new RoleStore<Role>(dbContext);

         foreach (string roleName in roleList)
         {
            var role = new Role { Name = roleName, NormalizedName = roleName.ToUpper() };
            await roleStore.CreateAsync(role);
         }
      }

      private async static Task ApplyUsers(IServiceScope appServices, dbContext dbContext)
      {
         if (dbContext.Users.Count() != 0) { return; }
         var userManager = appServices.ServiceProvider.GetService<UserManager<Auth.Data.User>>();
         if (userManager == null) { return; }

         var user = new User
         {
            UserName = "leverson",
            FullName = "Leverson Carlos",
            Email = "leverson@friendship.com.br",
            EmailConfirmed = true,
            JoinDate = DateTime.Now, 
            SecurityStamp = Guid.NewGuid().ToString("D")
         };
         user.NormalizedUserName = user.UserName.ToUpper();
         user.NormalizedEmail = user.Email.ToUpper();
         user.PasswordHash = userManager.GetPasswordHash(user, "abc1234");

         await userManager.CreateAsync(user);

         // var claimList = roleList.Select(x => new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, x.ToLower()));
         // await userStore.AddClaimsAsync(user, claimList);

         foreach (string roleName in roleList)
         { await userManager.AddToRoleAsync(user, roleName.ToUpper()); }

      }

   }
}
