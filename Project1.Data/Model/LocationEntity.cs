using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class LocationEntity
    {
        public LocationEntity()
        {
            InventoryEntity = new HashSet<InventoryEntity>();
            OrderHistoryEntity = new HashSet<OrderHistoryEntity>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<InventoryEntity> InventoryEntity { get; set; }
        public virtual ICollection<OrderHistoryEntity> OrderHistoryEntity { get; set; }
    }
}
