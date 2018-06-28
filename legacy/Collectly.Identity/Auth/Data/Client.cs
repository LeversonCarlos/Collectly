using System.ComponentModel.DataAnnotations;

namespace Collectly.Auth.Data
{
   public class Client 
   {

      [Key]
      public string ClientID { get; set; }

      [Required]
      public string Secret { get; set; }

      public int RefreshTokenLifetime { get; set; }
      public string AllowedOrigin { get; set; }
      public bool Active { get; set; }

   }
}