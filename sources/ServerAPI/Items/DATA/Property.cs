using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Items
{

   [Table("collectly_v5_dataProperties")]
   internal class PropertyData
   {

      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public long PropertyID { get; set; }

      public long ItemID { get; set; }
      [ForeignKey("ItemID")]
      public virtual Items.ItemData ItemDetails { get; set; }

      [Required]
      public string TagID { get; set; }
      [ForeignKey("TagID")]
      public virtual Layouts.TagData TagDetails { get; set; }

      [StringLength(500)]
      public string ValueText { get; set; }

      [Column(TypeName = "decimal(15,4)")]
      public decimal? ValueNumeric { get; set; }

      public bool? ValueBoolean { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime? ValueDate { get; set; }

      [StringLength(4000)]
      public string ValueUrl { get; set; }

   }
}