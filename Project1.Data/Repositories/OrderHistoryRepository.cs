﻿using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Data
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {

        private readonly Project01Context _context;

        public OrderHistoryRepository(Project01Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(OrderHistory orderHistory)
        {

            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            string time = DateTime.Now.ToString("HH:mm");

            var Entity = new OrderHistoryEntity {CustomerId = orderHistory.CustomerId, LocationId = orderHistory.LocationId, Date = date, Time = time };

            _context.OrderHistoryEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<OrderHistory> GetAll()
        {
            var entities = _context.OrderHistoryEntity.ToList();

            return entities.Select(e => new OrderHistory(e.OrderId, e.LocationId, e.CustomerId, e.Date, e.Time));
        }

        public IEnumerable<OrderHistory> GetOrderHistoryByCustomerId(int id)
        {
            var entities = _context.OrderHistoryEntity
                 .Where(r => r.CustomerId == id)
                 .ToList();

            return entities.Select(e => new OrderHistory(e.OrderId, e.LocationId, e.CustomerId, e.Date, e.Time));
        }

        public IEnumerable<OrderHistory> GetOrderHistoryByLocationId(int id)
        {
            var entities = _context.OrderHistoryEntity
                .Where(r => r.LocationId == id)
                .ToList();

            return entities.Select(e => new OrderHistory(e.OrderId, e.LocationId, e.CustomerId, e.Date, e.Time));
        }

        public OrderHistory GetOrderHistoryByOrderId(int id)
        {
            var orderHistory  = _context.OrderHistoryEntity
               .FirstOrDefault(l => l.OrderId == id);

            return new OrderHistory(orderHistory.OrderId, orderHistory.LocationId, orderHistory.CustomerId, orderHistory.Date, orderHistory.Time);
        }
    }
}
