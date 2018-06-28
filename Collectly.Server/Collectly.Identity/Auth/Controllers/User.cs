using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Collectly.Auth.Controllers
{
   partial class AuthController 
   {

      #region GetUsers
      [Authorize(Roles ="Admin")]
      [HttpGet("users")]
      public async Task<IActionResult> GetUsers()
      { return new OkObjectResult((await this.dbContext.Users.ToListAsync()).Select(x => Models.User.ToModel(x))); }
      #endregion    

      [Authorize]
      [HttpGet("claims")]
      public IActionResult GetClaims()
      {
         var t = User.IsInRole("Admin");
         return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
      }

   }
}