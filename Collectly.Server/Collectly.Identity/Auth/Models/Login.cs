using System;
using System.ComponentModel.DataAnnotations;

namespace Collectly.Auth.Models
{

   public class LoginData
   {

      [Display(Description = "LABEL_LOGIN_USERNAME")]
      public string UserName { get; set; }

      [Display(Description = "LABEL_LOGIN_PASSWORD")]
      public string Password { get; set; }

   }

   public class LoginResult
   {
      public string AccessToken { get; set; }
      public DateTime CreatedTime { get; set; }
      public DateTime ExpirationTime { get; set; }
   }

}