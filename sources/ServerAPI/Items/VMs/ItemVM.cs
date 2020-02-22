using System.Collections.Generic;
using System.Linq;

namespace Collectly.API.Items
{
   public class ItemVM
   {
      public long ItemID { get; set; }
      public string Text { get; set; }
      public Collections.CollectionVM CollectionDetails { get; set; }
      public List<PropertyVM> PropertyList { get; set; }

      internal static ItemVM Convert(ItemData value)
      {
         if (value == null) { return null; }
         return new ItemVM
         {
            ItemID = value.ItemID,
            Text = value.Text,
            CollectionDetails = Collections.CollectionVM.Convert(value.CollectionDetails),
            PropertyList = value.PropertyList.Select(x => PropertyVM.Convert(x)).ToList()
         };
      }

   }
}
