using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface IOrderHistoryRepository
    {
        IEnumerable<OrderHistory> GetAll();

        OrderHistory GetOrderHistoryByOrderId(int id);

        IEnumerable<OrderHistory> GetOrderHistoryByLocationId(int id);

        IEnumerable<OrderHistory> GetOrderHistoryByCustomerId(int id);

        void Create(OrderHistory orderHistory);
    }
}
