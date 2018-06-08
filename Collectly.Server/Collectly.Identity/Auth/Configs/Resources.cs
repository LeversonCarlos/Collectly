using IdentityServer4.Models;
using System.Collections.Generic;

namespace Collectly.Auth
{
   partial class Configs
   {
      internal const string ApiName = "apiName";

      public static IEnumerable<ApiResource> GetApiResources()
      {
         return new List<ApiResource>
         {
            new ApiResource(ApiName, "Collectly API")
         };
      }

      public static IEnumerable<IdentityResource> GetIdentityResources()
      {
         return new List<IdentityResource>
         {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
         };
      }

   }
}