using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class InventoryEntity
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual LocationEntity Location { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
