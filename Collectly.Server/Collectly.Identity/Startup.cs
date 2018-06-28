using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/*
   https://github.com/renatogroffe/ASPNETCore2_CRUD-API-JWT-EFInMemory/blob/master/APIProdutos/Startup.cs
   https://medium.com/@renato.groffe/asp-net-core-jwt-guia-de-refer%C3%AAncia-3c071bf2a927
 */

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
         //services.AddScoped<UserManager<Auth.Data.User>>();

         services
            .AddIdentity<Auth.Data.User, Auth.Data.Role>(options =>
            {
               options.User.RequireUniqueEmail = true;
               options.Password.RequiredLength = 4;
               options.SignIn.RequireConfirmedEmail = false;
               options.ClaimsIdentity.RoleClaimType = "role";
            })
            .AddEntityFrameworkStores<Auth.Data.dbContext>()
            .AddUserManager<UserManager<Auth.Data.User>>()
            //.AddDefaultTokenProviders()
            ;

         /*
         services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddInMemoryClients(Auth.Configs.GetClients())
             .AddInMemoryApiResources(Auth.Configs.GetApiResources())
             .AddInMemoryIdentityResources(Auth.Configs.GetIdentityResources())
             .AddAspNetIdentity<Auth.Data.User>();
         */

         var signingConfig = Auth.Configs.GetSigningConfig();
         services.AddSingleton(signingConfig);
         var tokenConfig = Auth.Configs.GetTokenConfig(Configuration.GetSection("Token"));
         services.AddSingleton(tokenConfig);

         services
            .AddAuthentication(options=> {
               options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;// IdentityConstants.ApplicationScheme;
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
               // options.Authority = "http://localhost:6553";
               // options.RequireHttpsMetadata = false;
               // options.Audience = "apiName";

               var paramsValidation = options.TokenValidationParameters;
               paramsValidation.IssuerSigningKey = signingConfig.Key;
               paramsValidation.ValidAudience = tokenConfig.Audience;
               paramsValidation.ValidIssuer = tokenConfig.Issuer;

               //paramsValidation.ValidateIssuerSigningKey = true;
               //paramsValidation.ValidateLifetime = true;
               paramsValidation.ClockSkew = System.TimeSpan.Zero;

            });

         services.AddAuthorization(auth =>
         {
            auth.AddPolicy("Admin", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser()
                .RequireClaim("role", "admin")
                .Build());
         });

         services
            .AddMvc();

      }

      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         // app.UseDefaultFiles();
         // app.UseStaticFiles();
         // app.UseIdentityServer();
         app.SeedData();

         app.UseAuthentication();
         app.UseMvcWithDefaultRoute();
         /*
         app.UseMvc(options =>
         {
            options.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
         });
         */
      }
   }
}