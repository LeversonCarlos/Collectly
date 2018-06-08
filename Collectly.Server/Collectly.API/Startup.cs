﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly
{
   public class Startup
   {

      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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
               options.ApiName = "collectlyApi";
            });

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseAuthentication();
         app.UseMvc();
         /*
         app.Run(async (context) =>
         {
            await context.Response.WriteAsync("Hello World!");
         });
         */
      }
   }
}