using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryModels
{
    public abstract class FullAuditModel:IdentityModel,IAuditedModel,IActivatableModel,ISoftDeletable
    {
        [Key]
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
}
}
