using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryModels
{
    public class ItemGenre : FullAuditModel
    {
        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
