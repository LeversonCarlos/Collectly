namespace Collectly.API.Layouts
{
   public class TagVM
   {
      public string TagID { get; set; }
      public string Text { get; set; }
      public short Type { get; set; }
      public bool Multiple { get; set; }

      internal static TagVM Convert(TagData value)
      {
         if (value == null) { return null; }
         return new TagVM
         {
            TagID = value.TagID,
            Text = value.Text,
            Type = value.Type,
            Multiple = value.Multiple
         };
      }

   }
}
