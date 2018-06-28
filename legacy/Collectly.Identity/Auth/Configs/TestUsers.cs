using IdentityServer4.Test;
using System.Collections.Generic;

namespace Collectly.Auth
{
   partial class Configs
   {

      public static List<TestUser> GetTestUsers()
      {
         return new List<TestUser>
         {
            new TestUser
            {
               SubjectId = System.Guid.NewGuid().ToString(),
               Username = "lcjohnny@hotmail.com",
               Password = "abc1234",
               IsActive = true
            },
            new TestUser
            {
               SubjectId = System.Guid.NewGuid().ToString(),
               Username = "test",
               Password = "test",
               IsActive = false
            }
         };
      }

   }
}