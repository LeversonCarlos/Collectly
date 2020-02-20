using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   partial class BaseContext
   {

      internal DbSet<Items.ItemData> Items { get; set; }
      internal DbSet<Items.ItemPropertyData> ItemProperties { get; set; }

      private void OnModelCreating_Items(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Items.ItemData>()
            .HasIndex(x => new { x.ResourceID, x.LayoutID, x.CollectionID })
            .IncludeProperties(x => new { x.ItemID })
            .HasName("collectly_v5_dataItems_index");
         modelBuilder.Entity<Items.ItemPropertyData>()
            .HasIndex(x => new { x.ItemID })
            .IncludeProperties(x => new { x.ItemPropertyID })
            .HasName("collectly_v5_dataItemProperties_index");
      }

   }
}