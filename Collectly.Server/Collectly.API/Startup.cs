using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly
{
   public class Startup
   {

      public void ConfigureServices(IServiceCollection services)
      {

         services
            .AddMvcCore()
            .AddAuthorization()
            .AddJsonFormatters();

         services
            .AddAuthentication("Bearer")            
            .AddIdentityServerAuthentication(options =>
            {
               options.Authority = "http://localhost:6553";
               options.RequireHttpsMetadata = false;
               options.ApiName = "apiName";
               options.ApiSecret = "apiClientSecret";
               options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
            });

      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseAuthentication();
         app.UseMvc();

      }
   }
}