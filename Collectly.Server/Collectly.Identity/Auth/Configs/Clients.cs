using IdentityServer4.Models;
using System.Collections.Generic;

namespace Collectly.Auth
{
   partial class Configs
   {

      internal const string ApiClientID = "apiClientID";
      internal const string ApiClientSecret = "apiClientSecret";

      public static IEnumerable<Client> GetClients()
      {

         return new List<Client>
         {
            new Client
            {
               ClientId = ApiClientID,
               AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

               ClientSecrets =
               {
                  new Secret(ApiClientSecret.Sha256())
               },
               AllowedScopes = { ApiName }

            }
         };
      }

   }
}