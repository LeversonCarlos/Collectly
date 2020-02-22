using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Items
{

   [Table("collectly_v5_dataItems")]
   internal class ItemData
   {

      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public long ItemID { get; set; }

      [Column(TypeName = "varchar(128)")]
      [StringLength(128), Required]
      public string ResourceID { get; set; }

      [Required]
      public string LayoutID { get; set; }
      [ForeignKey("LayoutID")]
      public virtual Layouts.LayoutData LayoutDetails { get; set; }

      [Column(TypeName = "varchar(500)")]
      [Required, StringLength(500)]
      public string Text { get; set; }

      public long? CollectionID { get; set; }
      [ForeignKey("CollectionID")]
      public virtual Collections.CollectionData CollectionDetails { get; set; }

      public short? CollectionSequence { get; set; }

      public virtual List<PropertyData> PropertyList { get; set; }

   }
}