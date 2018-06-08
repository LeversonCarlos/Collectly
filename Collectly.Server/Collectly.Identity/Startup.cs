using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly.Identity
{
   public class Startup
   {

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddInMemoryApiResources(Auth.Configs.GetResources())
             .AddInMemoryClients(Auth.Configs.GetClients())
             .AddTestUsers(Auth.Configs.GetTestUsers());
      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         app.UseIdentityServer();
      }
   }
}