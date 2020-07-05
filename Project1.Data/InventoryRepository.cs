using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly Project01Context _context;

        public InventoryRepository(Project01Context context)
        {
            _context = context;
        }

        public void Create(Inventory inventory)
        {
            var Entity = new InventoryEntity { LocationId = inventory.LocationId, ProductId = inventory.ProductId, Amount = inventory.Amount };

            _context.InventoryEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Inventory> GetAll()
        {
            var entities = _context.InventoryEntity.ToList();

            return entities.Select(e => new Inventory(e.LocationId, e.ProductId, e.Amount));
        }

        public void Update(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
