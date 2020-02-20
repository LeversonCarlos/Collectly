using System;
using System.Diagnostics;

namespace Collectly.API.Base
{
   internal partial class BaseService : IDisposable
   {

      protected readonly Base.BaseContext dbContext;
      public IServiceProvider serviceProvider { get; set; }
      protected BaseService(IServiceProvider _serviceProvider)
      {
         this.serviceProvider = _serviceProvider;
         this.dbContext = this.GetService<Base.BaseContext>();
      }

      [DebuggerStepThrough]
      protected T GetService<T>() where T : class
      { return (T)this.serviceProvider.GetService(typeof(T)); }

      public void Dispose()
      { /* throw new NotImplementedException(); */ }

   }
}