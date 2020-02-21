using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Collectly.API.Collections
{

   partial class CollectionsService
   {

      public async Task<ActionResult<bool>> RemoveAsync(long collectionID)
      {
         try
         {

            // LOCATE DATA
            var data = await this.GetDataQuery().Where(x => x.CollectionID == collectionID).FirstOrDefaultAsync();
            if (data == null) { return this.NotFoundResponse(); }

            // APPLY
            this.dbContext.Collections.Remove(data);
            await this.dbContext.SaveChangesAsync();

            // RESULT
            return this.OkResponse(true);

         }
         catch (Exception ex) { return this.ExceptionResponse(ex); }
      }

   }

   partial class CollectionsController
   {

      [HttpDelete("{id:long}")]
      [Authorize(Roles = "Editor")]
      public async Task<ActionResult<bool>> RemoveAsync(long id)
      {
         return await this.GetService<CollectionsService>().RemoveAsync(id);
      }

   }

}
