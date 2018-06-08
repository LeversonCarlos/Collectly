using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Collectly.Test
{
   class Program
   {

      public static void Main(string[] args) {
         MainAsync().GetAwaiter().GetResult();
         Console.ReadKey();
      }

      private static async Task MainAsync()
      {

         // discover endpoints from metadata
         var disco = await DiscoveryClient.GetAsync("http://localhost:6553");
         if (disco.IsError)
         { Console.WriteLine(disco.Error); return; }

         // request token
         var tokenClient = new TokenClient(disco.TokenEndpoint, "apiClientID", "apiClientSecret");
         var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("leverson", "abc1234", "apiName");
         if (tokenResponse.IsError)
         { Console.WriteLine(tokenResponse.Error); return; }

         Console.WriteLine(tokenResponse.Json);
         Console.WriteLine("\n\n");

         // call api
         var client = new HttpClient();
         client.SetBearerToken(tokenResponse.AccessToken);

         var response = await client.GetAsync("http://localhost:6593/api/test");
         if (!response.IsSuccessStatusCode)
         { Console.WriteLine(response.StatusCode); }
         else {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JArray.Parse(content));
         }

      }
   }
}