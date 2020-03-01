using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collectly.API.Items
{

   [Authorize]
   [Route("api/items")]
   public partial class ItemsController : Base.BaseController
   {
      public ItemsController(IServiceProvider _serviceProvider) : base(_serviceProvider) { }
   }

   internal partial class ItemsService : Base.BaseService
   {
      public ItemsService(IServiceProvider serviceProvider) : base(serviceProvider) { }
   }

}
