using Microsoft.AspNetCore.Mvc;

namespace Collectly.Auth.Controllers
{
   [Route("auth")]
   public partial class AuthController : ControllerBase
   {

      Data.dbContext dbContext { get; set; }
      public AuthController([FromServices]Data.dbContext _dbContext)
      {
         this.dbContext = _dbContext;
      }

   }
}