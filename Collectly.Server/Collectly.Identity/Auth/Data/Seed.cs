using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Collectly.Auth.Data;

namespace Collectly.Identity
{
   public static class Seed
    {
      static string[] roleList = new string[] { "Owner", "Admin", "User", "Viewer" };

      public static void SeedData(this IApplicationBuilder app)
      {
         try
         {
            using (var appServices = app.ApplicationServices.CreateScope())
            {
               var dbContext = appServices.ServiceProvider.GetService<dbContext>();
               ApplyRoles(dbContext);
               ApplyUsers(dbContext);
            }
         }
         catch (Exception ex) { throw ex; }
      }

      private async static void ApplyRoles(dbContext dbContext)
      {
         if (dbContext.Roles.Count() != 0) { return; }

         var roleStore = new RoleStore<Role>(dbContext);
         foreach (string roleName in roleList)
         {
            var role = new Role { Name = roleName, NormalizedName = roleName.ToUpper() };
            await roleStore.CreateAsync(role);
         }

      }

      private async static void ApplyUsers(dbContext dbContext)
      {
         if (dbContext.Users.Count() != 0) { return; }

         var user = new User
         {
            UserName = "leverson",
            FullName = "Leverson Carlos",
            Email = "leverson@friendship.com.br",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
         };
         user.NormalizedUserName = user.UserName.ToUpper();
         user.NormalizedEmail = user.Email.ToUpper();

         var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
         var userPassword = passwordHasher.HashPassword(user, "abc1234");
         user.PasswordHash = userPassword;

         var userStore = new UserStore<User>(dbContext);
         await userStore.CreateAsync(user);

         foreach (string roleName in roleList)
         { await userStore.AddToRoleAsync(user, roleName); }

      }

   }
}
