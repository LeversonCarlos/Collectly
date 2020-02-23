using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collectly.API.Layouts
{
   public enum LayoutTagEnum : short { Text = 0, Numeric = 1, Date = 2, Boolean = 3, ImageUrl = 4, LinkUrl = 5 };

   [Table("collectly_v5_dataTags")]
   internal class TagData
   {

      [Key]
      public string TagID { get; set; }

      [Required]
      public string LayoutID { get; set; }
      [ForeignKey("LayoutID")]
      public virtual Layouts.LayoutData LayoutDetails { get; set; }

      [Column(TypeName = "varchar(500)")]
      [Required, StringLength(500)]
      public string Text { get; set; }

      [Required]
      public short Type { get; set; }

      [Required]
      public bool Multiple { get; set; }

   }
}