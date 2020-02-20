using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Collectly.API.Base
{
   internal partial class BaseController : ControllerBase
   {

      protected readonly IServiceProvider serviceProvider;
      public BaseController(IServiceProvider _serviceProvider)
      { this.serviceProvider = _serviceProvider; }

      [DebuggerStepThrough]
      protected T GetService<T>() where T : class
      { return (T)this.serviceProvider.GetService(typeof(T)); }

   }
}