using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Collectly.Auth
{

   partial class Configs
   {
      internal static SigningConfig GetSigningConfig()
      {
         using (var provider = new RSACryptoServiceProvider(2048))
         {
            var signingConfig = new SigningConfig();
            signingConfig.Key = new RsaSecurityKey(provider.ExportParameters(true));
            signingConfig.Credentials = new SigningCredentials(signingConfig.Key, SecurityAlgorithms.RsaSha256Signature);
            return signingConfig;
         }
      }
   }
   public class SigningConfig
   {
      public SecurityKey Key { get; set; }
      public SigningCredentials Credentials { get; set; }
   }

   partial class Configs
   {
      internal static TokenConfig GetTokenConfig(IConfiguration configSection)
      {
         var tokenConfig = new TokenConfig();
         var tokenSection = new Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<TokenConfig>(configSection);
         tokenSection.Configure(tokenConfig);
         return tokenConfig;
      }
   }
   public class TokenConfig
   {
      public string Audience { get; set; }
      public string Issuer { get; set; }
      public int Seconds { get; set; }
   }

}