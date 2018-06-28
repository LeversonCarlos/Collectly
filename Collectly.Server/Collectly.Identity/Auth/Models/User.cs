using System;
using System.ComponentModel.DataAnnotations;

namespace Collectly.Auth.Models
{
   public class User
   {

      [Display(Description = "LABEL_USERS_ID")]
      public string UserID { get; set; }

      [Display(Description = "LABEL_USERS_USERNAME")]
      public string UserName { get; set; }

      [Display(Description = "LABEL_USERS_FULLNAME")]
      public string FullName { get; set; }

      [Display(Description = "LABEL_USERS_EMAIL")]
      public string Email { get; set; }

      [Display(Description = "LABEL_USERS_JOINDATE")]
      public DateTime JoinDate { get; set; }

      //public viewUserRoles UserRoles { get; set; }
      //public IList<string> Roles { get; set; }
      //public IList<System.Security.Claims.Claim> Claims { get; set; }

      public static User ToModel(Data.User data)
      {
         var model = new User
         {
            UserID = data.Id,
            UserName = data.UserName,
            FullName = data.FullName,
            Email = data.Email,
            JoinDate = data.JoinDate
         };
         return model;
      }

   }
}
