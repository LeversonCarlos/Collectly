using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   internal partial class BaseContext : DbContext, IDisposable
   {

      public IServiceProvider serviceProvider { get; set; }
      public BaseContext(DbContextOptions<BaseContext> options, IServiceProvider _serviceProvider) : base(options)
      { this.serviceProvider = _serviceProvider; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

         // modelBuilder.Ignore<Items.ItemData>();
         // modelBuilder.Ignore<Items.PropertyData>();

         this.OnModelCreating_Layouts(modelBuilder);
         this.OnModelCreating_Collections(modelBuilder);
         this.OnModelCreating_Items(modelBuilder);
         base.OnModelCreating(modelBuilder);
      }

      /*
         dotnet ef migrations add CTL_200301
         dotnet ef database update
       */

   }
}