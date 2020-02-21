using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Collectly.API.Collections
{

   partial class CollectionsService
   {

      public async Task<ActionResult<CollectionVM>> CreateAsync(CollectionVM value)
      {
         try
         {
            var resourceID = this.GetService<Helpers.User>().ResourceID;

            // VALIDATE DUPLICITY
            if (await this.GetDataQuery().CountAsync(x => x.CollectionID != value.CollectionID && x.Text == value.Text) != 0)
            { return this.WarningResponse(this.GetTranslation("COLLECTIONS_COLLECTION_TEXT_ALREADY_EXISTS_WARNING")); }

            // NEW MODEL
            var data = new CollectionData()
            {
               ResourceID = resourceID,
               Text = value.Text
            };

            // APPLY
            await this.dbContext.AddAsync(data);
            await this.dbContext.SaveChangesAsync();

            // RESULT
            var result = CollectionVM.Convert(data);
            return this.CreatedResponse("collections", result.CollectionID, result);
         }
         catch (Exception ex) { return this.ExceptionResponse(ex); }
      }

   }

   partial class CollectionsController
   {

      [HttpPost("")]
      [Authorize(Roles = "Editor")]
      public async Task<ActionResult<CollectionVM>> CreateAsync([FromBody]CollectionVM value)
      {
         if (value == null) { return this.BadRequest(this.ModelState); }
         return await this.GetService<CollectionsService>().CreateAsync(value);
      }

   }

}
