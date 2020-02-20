using System;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Base
{
   partial class BaseContext
   {

      internal DbSet<Collections.CollectionData> Collections { get; set; }

      private void OnModelCreating_Collections(ModelBuilder modelBuilder)
      {
      }

   }
}