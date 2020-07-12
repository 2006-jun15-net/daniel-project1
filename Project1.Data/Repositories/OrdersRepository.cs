using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project1.Data.Model;
using Project1.Domain;

namespace Project1.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly Project01Context _context;

        public OrdersRepository(Project01Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Orders orders)
        {
            var entity = new OrdersEntity { OrderId = orders.OrderID, ProductId = orders.ProductID, Amount = orders.Amount };

            _context.OrdersEntity.Add(entity);

            _context.SaveChanges();
        }

        public IEnumerable<Orders> GetAll()
        {
            var entities = _context.OrdersEntity.ToList();

            return entities.Select(e => new Orders(e.OrderId, e.ProductId, e.Amount));
        }

        public IEnumerable<Orders> GetOrdersByOrderId(int id)
        {
            var entities = _context.OrdersEntity
                .Include(e => e.Product)
                .Where(r => r.OrderId == id)
                .ToList();

            return entities.Select(k => new Orders(k.OrderId, k.ProductId, k.Product.Name, k.Amount));
        }
    }
}
