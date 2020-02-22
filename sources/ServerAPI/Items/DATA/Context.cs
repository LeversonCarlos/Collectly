using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   partial class BaseContext
   {

      internal DbSet<Items.ItemData> Items { get; set; }
      internal DbSet<Items.PropertyData> PropertyList { get; set; }

      private void OnModelCreating_Items(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Items.ItemData>()
            .HasIndex(x => new { x.ResourceID, x.LayoutID, x.CollectionID })
            .IncludeProperties(x => new { x.ItemID })
            .HasName("collectly_v5_dataItems_index");
         modelBuilder.Entity<Items.PropertyData>()
            .HasIndex(x => new { x.ItemID })
            .IncludeProperties(x => new { x.PropertyID })
            .HasName("collectly_v5_dataProperties_index");
      }

   }
}