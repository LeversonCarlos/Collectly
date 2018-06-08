using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly.Identity
{
   public class Startup
   {

      public Startup(IConfiguration configuration, IHostingEnvironment environment)
      {
         Configuration = configuration;
         Environment = environment;
      }
      public IConfiguration Configuration { get; }
      public IHostingEnvironment Environment { get; }

      public void ConfigureServices(IServiceCollection services)
      {

         services
            .AddDbContext<Auth.Data.dbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("AuthConnection")));

         services
            .AddIdentity<Auth.Data.User, Auth.Data.Role>()
            .AddEntityFrameworkStores<Auth.Data.dbContext>()
            .AddDefaultTokenProviders();

         // services.AddMvc();

         services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddInMemoryIdentityResources(Auth.Configs.GetIdentityResources())
             .AddInMemoryApiResources(Auth.Configs.GetApiResources())
             .AddInMemoryClients(Auth.Configs.GetClients())
             .AddAspNetIdentity<Auth.Data.User>();
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         // app.UseStaticFiles();
         app.UseIdentityServer();
         app.SeedData();
      }
   }
}