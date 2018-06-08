using IdentityServer4.Models;
using System.Collections.Generic;

namespace Collectly.Auth
{
   partial class Configs
   {
      internal const string ApiName = "apiName";

      public static IEnumerable<ApiResource> GetResources()
      {
         return new List<ApiResource>
         {
            new ApiResource(ApiName, "Collectly API")
         };
      }

   }
}