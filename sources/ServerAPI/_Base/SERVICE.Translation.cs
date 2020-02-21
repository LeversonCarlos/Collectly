using Microsoft.Extensions.Localization;

namespace Collectly.API.Base
{
   partial class BaseService
   {

      public string GetTranslation(string key)
      {
         try
         {
            var localizer = this.GetService<IStringLocalizer<Collectly.Localization.Strings>>();
            var result = localizer[key];
            return result;
         }
         catch { return $"{key.ToUpper().Replace(" ", "_")}"; }
      }

   }
}