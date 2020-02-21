namespace Collectly.API.Collections
{
   public class CollectionVM
   {
      public long CollectionID { get; set; }
      public string Text { get; set; }

      internal static CollectionVM Convert(CollectionData value)
      {
         return new CollectionVM
         {
            CollectionID = value.CollectionID,
            Text = value.Text
         };
      }

   }
}
