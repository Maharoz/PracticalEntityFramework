using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryModels
{
    public interface IActivatableModel
    {
        public bool IsActive { get; set; }
    }
}
