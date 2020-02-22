using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collectly.API.Layouts
{

   [Table("collectly_v5_dataLayouts")]
   internal class LayoutData
   {

      [Key]
      public string LayoutID { get; set; }

      [Column(TypeName = "varchar(500)")]
      [Required, StringLength(500)]
      public string Text { get; set; }

   }
}