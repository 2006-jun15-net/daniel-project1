﻿using Microsoft.EntityFrameworkCore;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
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

        public IEnumerable<Inventory> GetInventoryById(int id)
        {
            var inventory = _context.InventoryEntity
                .Include(e => e.Product)
                .Where(l => l.LocationId == id)
                .ToList();

            return inventory.Select(k => new Inventory(k.LocationId, k.ProductId, k.Product.Name, k.Product.Price, k.Amount));
        }

        public void Update(Inventory inventory)
        {
            InventoryEntity currentEntity = _context.InventoryEntity.Find(inventory.LocationId, inventory.ProductId);
            int newAmount = currentEntity.Amount - inventory.Amount;
            var newEntity = new InventoryEntity { Amount = newAmount, LocationId = currentEntity.LocationId, ProductId = currentEntity.ProductId };

            _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
            _context.SaveChanges();
        }






    }
}
