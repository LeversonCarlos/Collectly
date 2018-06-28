using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Collectly.Auth.Controllers
{
   partial class AuthController 
   {

      #region Login
      [AllowAnonymous]
      [HttpPost("login")]
      public async Task<IActionResult> Login(
         [FromBody]Models.LoginData loginModel,
         [FromServices]UserManager<Data.User> userManager,
         [FromServices]SigningConfig signingConfig,
         [FromServices]TokenConfig tokenConfig)
      {
         if (loginModel == null) { return BadRequest(); }

         var user = await userManager.FindByNameAndPasswordAsync(loginModel.UserName, loginModel.Password);
         if (user == null) { return new UnauthorizedResult(); }

         var userRoles = await userManager.GetRolesAsync(user);
         var userClaims = userRoles
            .Select(x => new Claim("role", x.ToLower()))
            .ToList();
         userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString("N")));
         userClaims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Id));
         userClaims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.FullName));

         var genericIdentity = new System.Security.Principal.GenericIdentity(user.Id, Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
         var userIdentity = new ClaimsIdentity(genericIdentity, userClaims.ToArray());

         var createdTime = DateTime.Now;
         var expirationTime = createdTime.AddSeconds(tokenConfig.Seconds);

         var tokenHandler = new JwtSecurityTokenHandler();
         var securityToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
         {
            Issuer = tokenConfig.Issuer,
            Audience = tokenConfig.Audience,
            SigningCredentials = signingConfig.Credentials,
            Subject = userIdentity,
            NotBefore = createdTime,
            Expires = expirationTime
         });
         var token = tokenHandler.WriteToken(securityToken);

         var result = new Models.LoginResult
         {
            CreatedTime = createdTime, 
            ExpirationTime = expirationTime, 
            AccessToken = token 
         };
         return new OkObjectResult(result);

      }
      #endregion    

   }
}