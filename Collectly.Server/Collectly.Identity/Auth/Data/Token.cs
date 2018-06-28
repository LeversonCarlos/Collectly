using System;
using System.ComponentModel.DataAnnotations;

namespace Collectly.Auth.Data
{
   public class Token 
   {


      [Key]
      public string TokenID { get; set; }

      [Required]
      public string UserID { get; set; }

      [Required]
      public string ClientID { get; set; }

      public DateTime IssuedTime { get; set; }
      public DateTime ExpiryTime { get; set; }

      [Required]
      public string Ticket { get; set; }

   }
}