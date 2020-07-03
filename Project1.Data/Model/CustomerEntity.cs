using System;
using System.Collections.Generic;

namespace Project1.Data.Model
{
    public partial class CustomerEntity
    {
        public CustomerEntity()
        {
            OrderHistoryEntity = new HashSet<OrderHistoryEntity>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderHistoryEntity> OrderHistoryEntity { get; set; }
    }
}
