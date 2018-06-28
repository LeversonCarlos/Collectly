using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collectly.Auth.Data
{
   public class dbContext : IdentityDbContext<User>
   {

      public DbSet<Client> Clients { get; set; }
      public DbSet<Token> Tokens { get; set; }

      public dbContext(DbContextOptions<dbContext> options) : base(options)
      {
         // Configuration.ProxyCreationEnabled = false;
         // Configuration.LazyLoadingEnabled = false;
         // this.Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbContext, dbContext_Migration>());
         this.Database.EnsureCreated();
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<User>(e => { e.ToTable("auth_identityUsers"); e.Property(p => p.Id).HasColumnName("UserID"); });
         modelBuilder.Entity<IdentityUser>().ToTable("auth_identityUsers");
         modelBuilder.Entity<Role>(e => { e.ToTable("auth_identityRoles"); e.Property(p => p.Id).HasColumnName("RoleID"); });
         modelBuilder.Entity<IdentityRole>().ToTable("auth_identityRoles");
         modelBuilder.Entity<IdentityUserRole<string>>(e => { e.ToTable("auth_identityUserRoles"); e.Property(p => p.UserId).HasColumnName("UserID"); e.Property(p => p.RoleId).HasColumnName("RoleID"); });
         modelBuilder.Entity<IdentityUserClaim<string>>(e => { e.ToTable("auth_identityUserClaims"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         modelBuilder.Entity<IdentityUserToken<string>>(e => { e.ToTable("auth_identityUserTokens"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         modelBuilder.Entity<IdentityUserLogin<string>>(e => { e.ToTable("auth_identityUserLogins"); e.Property(p => p.UserId).HasColumnName("UserID"); });
         modelBuilder.Entity<IdentityRoleClaim<string>>(e => { e.ToTable("auth_identityRoleClaims"); e.Property(p => p.RoleId).HasColumnName("RoleID"); });
         modelBuilder.Entity<Client>().ToTable("auth_identityClients");
         modelBuilder.Entity<Token>().ToTable("auth_identityTokens");
      }

   }
}