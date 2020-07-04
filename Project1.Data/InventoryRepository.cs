using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Update(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
