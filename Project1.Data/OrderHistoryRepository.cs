using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {

        private readonly Project01Context _context;

        public OrderHistoryRepository(Project01Context context)
        {
            _context = context;
        }

        public void Create(OrderHistory orderHistory)
        {
            var Entity = new OrderHistoryEntity { OrderId = orderHistory.OrderId, CustomerId = orderHistory.CustomerId, LocationId = orderHistory.LocationId, Date = orderHistory.Date, Time = orderHistory.Time };

            _context.OrderHistoryEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<OrderHistory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
