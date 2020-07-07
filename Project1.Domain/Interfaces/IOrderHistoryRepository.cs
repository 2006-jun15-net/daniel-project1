using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface IOrderHistoryRepository
    {
        IEnumerable<OrderHistory> GetAll();

        void Create(OrderHistory orderHistory);
    }
}
