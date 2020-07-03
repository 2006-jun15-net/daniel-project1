using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class OrdersEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual OrderHistoryEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
