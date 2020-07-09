using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface IOrdersRepository
    {
        IEnumerable<Orders> GetAll();

        void Create(Orders orders);

        IEnumerable<Orders> GetOrdersByOrderId(int id);


    }
}
