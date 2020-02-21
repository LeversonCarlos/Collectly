using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collectly.API.Collections
{

   partial class CollectionsService
   {

      public async Task<ActionResult<List<CollectionVM>>> SearchDataAsync(string searchText)
      { return await this.SearchDataAsync(collectionID: 0, searchText: searchText); }

      public async Task<ActionResult<CollectionVM>> SearchDataAsync(long collectionID)
      {
         var dataMessage = await this.SearchDataAsync(collectionID: collectionID, searchText: "");
         var dataValue = this.GetValue(dataMessage);
         if (dataValue == null) { return dataMessage.Result; }
         if (dataValue.Count == 0) { return this.NotFoundResponse(); }
         return this.OkResponse(dataValue[0]);
      }

      private async Task<ActionResult<List<CollectionVM>>> SearchDataAsync(long collectionID = 0, string searchText = "")
      {
         try
         {

            var query = this.GetDataQuery();
            if (collectionID != 0) { query = query.Where(x => x.CollectionID == collectionID); }
            if (!string.IsNullOrEmpty(searchText))
            { query = query.Where(x => x.CollectionID != 0 && x.Text.Contains(searchText)); }

            var data = await query.OrderBy(x => x.Text).ToListAsync();
            var result = data.Select(x => CollectionVM.Convert(x)).ToList();
            return this.OkResponse(result);

         }
         catch (Exception ex) { return this.ExceptionResponse(ex); }
      }

      internal IQueryable<CollectionData> GetDataQuery()
      {
         // var resourceID = this.GetService<Helpers.User>().ResourceID;
         var resourceID = "8a91eba3-00a1-4dab-893a-0fb9865f71ee";
         return this.dbContext.Collections
            .Where(x => x.ResourceID == resourceID)
            .AsQueryable();
      }

   }

   partial class CollectionsController
   {

      [HttpGet("search/{searchText}")]
      [HttpGet("search")]
      public async Task<ActionResult<List<CollectionVM>>> SearchDataAsync(string searchText = "")
      {
         return await this.GetService<CollectionsService>().SearchDataAsync(searchText);
      }

      [HttpGet("{id:long}")]
      public async Task<ActionResult<CollectionVM>> SearchDataAsync(long collectionID)
      {
         return await this.GetService<CollectionsService>().SearchDataAsync(collectionID);
      }

   }

}
