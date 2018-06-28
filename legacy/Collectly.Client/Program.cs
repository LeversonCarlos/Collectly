using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Collectly.Test
{
   class Program
   {
      const string baseUrl = "http://localhost:6553";

      public static void Main(string[] args) {
         MainAsync().GetAwaiter().GetResult();
         Console.ReadKey();
      }

      private static async Task MainAsync()
      {

         // LOGIN
         var loginResponse = await Login();

         Console.WriteLine($"loginResponse: {loginResponse.StatusCode}");
         if (!loginResponse.IsSuccessStatusCode) { return; }

         var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
         Console.WriteLine($"loginResponseContent: {JContainer.Parse(loginResponseContent)}");

         var loginResult = JsonConvert.DeserializeObject<LoginResult>(loginResponseContent);

         Console.WriteLine($"Users");
         await Users(loginResult);

         Console.WriteLine($"Claims");
         await Claims(loginResult);

         /*
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
         var response = await client.GetAsync("http://localhost:6593/api/test");
         if (!response.IsSuccessStatusCode)
         { Console.WriteLine(response.StatusCode); }
         else {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JArray.Parse(content));
         }
         */

      }

      private static async Task<HttpResponseMessage> Login()
      {
         using (var httpClient = new HttpClient())
         {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var loginData = new
            {
               UserName = "leverson",
               Password = "abc1234"
            };
            var loginDataJson = JsonConvert.SerializeObject(loginData);
            var loginContent = new StringContent(loginDataJson, System.Text.Encoding.UTF8, "application/json");

            var loginUrl = $"{baseUrl}/auth/login";
            var loginResponse = await httpClient.PostAsync(loginUrl, loginContent);

            return loginResponse;
         }
      }

      private static async Task Users(LoginResult loginResult)
      {
         using (var httpClient = new HttpClient())
         {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.SetBearerToken(loginResult.AccessToken);

            var url = $"{baseUrl}/auth/users";
            var response = await httpClient.GetAsync(url);

            Console.WriteLine($"response: {response.StatusCode}");
            if (!response.IsSuccessStatusCode) { return; }

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"content: {JArray.Parse(content)}");
         }
      }

      private static async Task Claims(LoginResult loginResult)
      {
         using (var httpClient = new HttpClient())
         {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.SetBearerToken(loginResult.AccessToken);

            var url = $"{baseUrl}/auth/claims";
            var response = await httpClient.GetAsync(url);

            Console.WriteLine($"response: {response.StatusCode}");
            if (!response.IsSuccessStatusCode) { return; }

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"content: {JArray.Parse(content)}");
         }
      }

      private class LoginResult
      {
         public string AccessToken { get; set; }
         public DateTime CreatedTime { get; set; }
         public DateTime ExpirationTime { get; set; }
      }

   }
}