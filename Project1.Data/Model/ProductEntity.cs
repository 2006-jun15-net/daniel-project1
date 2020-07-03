using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class ProductEntity
    {
        public ProductEntity()
        {
            InventoryEntity = new HashSet<InventoryEntity>();
            OrdersEntity = new HashSet<OrdersEntity>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<InventoryEntity> InventoryEntity { get; set; }
        public virtual ICollection<OrdersEntity> OrdersEntity { get; set; }
    }
}
