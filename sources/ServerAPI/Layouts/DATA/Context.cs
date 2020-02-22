using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   partial class BaseContext
   {

      internal DbSet<Layouts.LayoutData> Layouts { get; set; }
      internal DbSet<Layouts.TagData> Tags { get; set; }

      private void OnModelCreating_Layouts(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Layouts.TagData>()
            .HasIndex(x => new { x.LayoutID })
            .IncludeProperties(x => new { x.TagID })
            .HasName("collectly_v5_dataTags_index");
      }

   }
}