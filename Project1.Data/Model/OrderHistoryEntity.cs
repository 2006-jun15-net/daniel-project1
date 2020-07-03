using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class OrderHistoryEntity
    {
        public OrderHistoryEntity()
        {
            OrdersEntity = new HashSet<OrdersEntity>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public virtual CustomerEntity Customer { get; set; }
        public virtual LocationEntity Location { get; set; }
        public virtual ICollection<OrdersEntity> OrdersEntity { get; set; }
    }
}
