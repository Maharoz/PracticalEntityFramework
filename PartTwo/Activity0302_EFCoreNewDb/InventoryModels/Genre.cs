using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryModels
{
    public class Genre : FullAuditModel
    {
        [Required]
        [StringLength(InventoryModelConstants.MAX_NAME_LENGTH)]
         public string Name { get; set; }
         public virtual List<ItemGenre> ItemGenres{ get; set; } = new List<ItemGenre>();
    }
}
