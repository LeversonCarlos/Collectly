using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collectly.API.Collections
{

   [Table("collectly_v5_dataCollections")]
   internal class CollectionData
   {

      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public long CollectionID { get; set; }

      [Column(TypeName = "varchar(128)")]
      [StringLength(128), Required]
      public string ResourceID { get; set; }

      [Column(TypeName = "varchar(500)")]
      [Required, StringLength(500)]
      public string Text { get; set; }

   }
}