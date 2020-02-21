using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Collectly
{
   partial class Startup
   {

      private void AddServices(IServiceCollection services)
      {

         // DATA CONTEXT
         services.AddDbContext<API.Base.BaseContext>(x =>
            x.UseSqlServer(this.AppSettings.ConnStr, opt =>
            {
               opt.MigrationsHistoryTable("collectly_v5_MigrationsHistory");
            }));

         // CONFIGURE INJECTION FOR HELPERS
         services.AddScoped<Helpers.User>();

         // CONFIGURE INJECTION FOR DATA SERVICES
         services.AddScoped<API.Collections.CollectionsService>();

      }

   }
}