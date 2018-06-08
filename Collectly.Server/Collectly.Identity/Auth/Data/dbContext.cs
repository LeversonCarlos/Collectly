using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collectly.Auth.Data
{
   public class dbContext : IdentityDbContext<User>
   {

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
         modelBuilder.Entity<User>().ToTable("auth_identityUsers");
         modelBuilder.Entity<Role>().ToTable("auth_identityRoles");
         modelBuilder.Entity<IdentityUser>().ToTable("auth_identityUsers");
         modelBuilder.Entity<IdentityRole>().ToTable("auth_identityRoles");
         modelBuilder.Entity<IdentityUserRole<string>>().ToTable("auth_identityUserRoles");
         modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("auth_identityUserLogins");
         modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("auth_identityUserClaims");
         modelBuilder.Entity<IdentityUserToken<string>>().ToTable("auth_identityUserTokens");
         modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("auth_identityRoleClaims");
         // modelBuilder.Entity<bindClient>().ToTable("auth_identityClients");
         // modelBuilder.Entity<bindToken>().ToTable("auth_identityTokens");
         // modelBuilder.Entity<bindSignature>().ToTable("auth_identitySignatures");
         // modelBuilder.Entity<bindCustomer>().ToTable("auth_identityCustomers");
         // modelBuilder.Entity<bindCustomerUser>().ToTable("auth_identityCustomersUsers");
      }

   }
}