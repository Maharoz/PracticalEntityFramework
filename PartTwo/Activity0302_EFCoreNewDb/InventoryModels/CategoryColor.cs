using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryModels
{
    public class CategoryColor : IdentityModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(InventoryModelConstants.MAX_COLORVALUE_LENGTH)]
        public string ColorValue { get; set; }

        public virtual Category Category { get; set; }
        public int? CategoryColorId { get; set; }
    }
}
