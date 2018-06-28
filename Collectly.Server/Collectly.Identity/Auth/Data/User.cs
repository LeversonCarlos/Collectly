using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Collectly.Auth.Data
{
   public class User : IdentityUser
   {

      [MaxLength(255)]
      public string FullName { get; set; }

      [Required]
      public DateTime JoinDate { get; set; }

   }
}