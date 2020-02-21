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

      public async Task<ActionResult<CollectionVM>> UpdateAsync(long collectionID, CollectionVM value)
      {
         try
         {

            // VALIDATE DUPLICITY
            if (await this.GetDataQuery().CountAsync(x => x.CollectionID != value.CollectionID && x.Text == value.Text) != 0)
            { return this.WarningResponse(this.GetTranslation("COLLECTIONS_COLLECTION_TEXT_ALREADY_EXISTS_WARNING")); }

            // LOCATE DATA
            var data = await this.GetDataQuery().Where(x => x.CollectionID == collectionID).FirstOrDefaultAsync();
            if (data == null) { return this.NotFoundResponse(); }

            // APPLY
            data.Text = value.Text;
            await this.dbContext.SaveChangesAsync();

            // RESULT
            var result = CollectionVM.Convert(data);
            return this.OkResponse(result);

         }
         catch (Exception ex) { return this.ExceptionResponse(ex); }
      }

   }

   partial class CollectionsController
   {

      [HttpPut("{id:long}")]
      [Authorize(Roles = "Editor")]
      public async Task<ActionResult<CollectionVM>> UpdateAsync(long id, [FromBody]CollectionVM value)
      {
         if (value == null) { return this.BadRequest(this.ModelState); }
         return await this.GetService<CollectionsService>().UpdateAsync(id, value);
      }

   }

}
