using IdentityServer4;
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

               RequireConsent = false,
               // AllowAccessTokensViaBrowser = true,
               // AllowOfflineAccess = true, 
               // AllowedCorsOrigins = { "http://localhost:5000" }
               AllowedScopes = {
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile,
                  IdentityServerConstants.StandardScopes.Email,
                  ApiName
               }
            }
         };
      }

   }
}