using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collectly.Auth.Store
{
   internal class dbContext : IdentityDbContext<UserData, RoleData, string>
   {

      public dbContext(DbContextOptions options) : base(options)
      {
         this.Database.EnsureCreated();         
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);
         /*
         builder.Entity<UserData>(e => { e.ToTable("auth_identityUsers"); e.Property(p => p.Id).HasColumnName("UserID"); });
         builder.Entity<IdentityUser<string>>(e => { e.ToTable("auth_identityUsers"); e.Property(p => p.Id).HasColumnName("UserID"); });
         builder.Entity<RoleData>(e => { e.ToTable("auth_identityRoles"); e.Property(p => p.Id).HasColumnName("RoleID"); });
         builder.Entity<IdentityRole<string>>(e => { e.ToTable("auth_identityRoles"); e.Property(p => p.Id).HasColumnName("RoleID"); });
         builder.Entity<IdentityUserRole<string>>(e => { e.ToTable("auth_identityUserRoles"); e.Property(p => p.UserId).HasColumnName("UserID"); e.Property(p => p.RoleId).HasColumnName("RoleID"); });
         builder.Entity<IdentityUserClaim<string>>(e => { e.ToTable("auth_identityUserClaims"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         builder.Entity<IdentityUserToken<string>>(e => { e.ToTable("auth_identityUserTokens"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         builder.Entity<IdentityUserLogin<string>>(e => { e.ToTable("auth_identityUserLogins"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         builder.Entity<IdentityRoleClaim<string>>(e => { e.ToTable("auth_identityRoleClaims"); e.Property(p => p.RoleId).HasColumnName("RoleID"); });
         */
      }

   }
}