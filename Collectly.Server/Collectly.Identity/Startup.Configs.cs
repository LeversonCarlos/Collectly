using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Collectly.Identity
{
   public class Config
   {

      // scopes define the API resources in your system
      public static IEnumerable<ApiResource> GetApiResources()
      {
         return new List<ApiResource>
            {
                new ApiResource("collectlyApi", "Collectly API")
            };
      }

      // clients want to access resources (aka scopes)
      public static IEnumerable<Client> GetClients()
      {
         // client credentials client
         return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "collectlyApi" }
                }
            };
      }

      public static List<TestUser> GetUsers()
      {
         return new List<TestUser>
         {
            new TestUser
               {
                  SubjectId = "1",
                  Username = "lcjohnny",
                  Password = "abc1234"
               },
               new TestUser
               {
                  SubjectId = "2",
                  Username = "test",
                  Password = "test"
               }
         };
      }

   }
}