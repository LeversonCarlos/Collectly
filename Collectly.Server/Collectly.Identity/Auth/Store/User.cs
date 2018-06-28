using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Collectly.Auth
{

   public static class UserManager
   {

      public static string GetPasswordHash(this UserManager<Auth.Data.User> userManager, Auth.Data.User user, string password)
      {
         var passwordHasher = new PasswordHasher<Auth.Data.User>();
         var userPassword = passwordHasher.HashPassword(user, password);
         return userPassword;
      }

      public static bool VerifyPasswordHash(this UserManager<Auth.Data.User> userManager, Auth.Data.User user, string password)
      {
         var passwordHasher = new PasswordHasher<Auth.Data.User>();
         var userPassword = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
         return userPassword != PasswordVerificationResult.Failed;
      }

      public static async Task<Auth.Data.User> FindByNameAndPasswordAsync(this UserManager<Auth.Data.User> userManager, string userName, string password)
      {
         var user = await userManager.FindByNameAsync(userName);
         if (user == null) { return null; }
         if (!userManager.VerifyPasswordHash(user, password)) { return null; }

         return user;
      }

   }

   /*    
   public class UserStore : UserStore<Data.User>
   {
      Data.dbContext dbContext { get; }

      public UserStore(Data.dbContext _dbContext) :base(_dbContext)
      { this.dbContext = _dbContext; }
  
   }
   */

   /*
   public class UserManager : UserManager<Data.User>
   {
      public async Task AddToRolesAndClaimsAsync(Data.User user, string[] valueList)
      {
         var claimList = valueList.Select(x => new Claim(ClaimTypes.Role, x.ToLower()));
         await AddClaimsAsync(user, claimList);

         foreach (string roleName in valueList)
         { await AddToRoleAsync(user, roleName.ToUpper()); }

      }
   }
   */

}