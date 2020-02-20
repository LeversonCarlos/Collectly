using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   partial class dbContext
   {

      internal DbSet<Layouts.LayoutData> Layouts { get; set; }
      internal DbSet<Layouts.LayoutTagData> LayoutTags { get; set; }

      private void OnModelCreating_Layouts(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Layouts.LayoutTagData>()
            .HasIndex(x => new { x.LayoutID })
            .IncludeProperties(x => new { x.LayoutTagID })
            .HasName("collectly_v5_dataLayoutTags_index_Layout");
      }

   }
}