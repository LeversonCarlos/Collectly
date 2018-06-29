using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            .AddDbContext<Auth.Store.dbContext>(options =>
            {
               options.UseSqlite(this.Configuration.GetConnectionString("AuthConnection"));
            });

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.Run(async (context) =>
         {
            await context.Response.WriteAsync("Hello World!");
         });
      }
   }
}