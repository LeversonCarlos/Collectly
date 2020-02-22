using System;

namespace Collectly.API.Items
{
   public class PropertyVM
   {
      public long PropertyID { get; set; }
      public Layouts.TagVM TagDetails { get; set; }
      public string ValueText { get; set; }
      public decimal? ValueNumeric { get; set; }
      public bool? ValueBoolean { get; set; }
      public DateTime? ValueDate { get; set; }
      public string ValueUrl { get; set; }

      internal static PropertyVM Convert(PropertyData value)
      {
         if (value == null) { return null; }
         return new PropertyVM
         {
            PropertyID = value.PropertyID,
            TagDetails = Layouts.TagVM.Convert(value.TagDetails),
            ValueText = value.ValueText,
            ValueNumeric = value.ValueNumeric,
            ValueBoolean = value.ValueBoolean,
            ValueDate = value.ValueDate,
            ValueUrl = value.ValueUrl
         };
      }

   }
}
