using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Collectly.API.Test
{

   [Route("[controller]")]
   [Authorize]
   public class TestController : ControllerBase
   {

      [HttpGet]
      public IActionResult Get()
      {
         return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
      }

   }

}