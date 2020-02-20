using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Collectly.API.Items
{

   [Table("collectly_v5_dataItemProperties")]
   internal class ItemPropertyData
   {

      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public long ItemPropertyID { get; set; }

      public long ItemID { get; set; }
      [ForeignKey("ItemID")]
      public virtual Items.ItemData ItemDetails { get; set; }

      [Required]
      public long LayoutTagID { get; set; }
      [ForeignKey("LayoutTagID")]
      public virtual Layouts.LayoutTagData LayoutTagDetails { get; set; }

      [StringLength(500)]
      public string ValueText { get; set; }

      public decimal? ValueNumeric { get; set; }

      public bool? ValueBoolean { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime? ValueDate { get; set; }

      [StringLength(4000)]
      public string ValueUrl { get; set; }

   }
}