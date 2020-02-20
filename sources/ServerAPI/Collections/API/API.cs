using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collectly.API.Collections
{

   [Authorize]
   [Route("api/collections")]
   public partial class CollectionsController : Base.BaseController
   {
      public CollectionsController(IServiceProvider _serviceProvider) : base(_serviceProvider) { }
   }

   internal partial class CollectionsService : Base.BaseService
   {
      public CollectionsService(IServiceProvider serviceProvider) : base(serviceProvider) { }
   }

}
