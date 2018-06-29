using Collectly.Auth.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly.API
{
   public class Startup
   {

      public IConfiguration Configuration { get; }
      public Startup(IConfiguration configuration)
      {
         this.Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {

         services
            .AddDbContext<dbContext>(options =>
            {
               options.UseSqlite(this.Configuration.GetConnectionString("AuthConnection"));
            });

         services
            .AddIdentity<UserData, RoleData>()
            .AddEntityFrameworkStores<dbContext>()
            .AddRoleManager<RoleManager<RoleData>>()
            .AddUserManager<UserManager<UserData>>()
            .AddDefaultTokenProviders();

      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.SeedData();

         app.Run(async (context) =>
         {
            await context.Response.WriteAsync("Hello World!");
         });
      }

   }
}