using System;
using Microsoft.AspNetCore.Identity;

namespace Collectly.Auth.Store
{
   internal class UserData : IdentityUser<string>
   {

      public string FullName { get; set; }

      public DateTime JoinDate { get; set; }

   }
}