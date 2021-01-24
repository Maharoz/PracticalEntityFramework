using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryModels
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
