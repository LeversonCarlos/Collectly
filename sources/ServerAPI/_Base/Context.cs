using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   internal partial class dbContext : DbContext, IDisposable
   {

      public IServiceProvider serviceProvider { get; set; }
      public dbContext(DbContextOptions<dbContext> options, IServiceProvider _serviceProvider) : base(options)
      { this.serviceProvider = _serviceProvider; }

      /*
         dotnet ef migrations add CTL_200219
         dotnet ef database update
       */

   }
}