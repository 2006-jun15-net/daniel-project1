using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> GetAll();

        IEnumerable<Inventory> GetInventoryById(int id);

        void Create(Inventory inventory);

        void Update(Inventory inventory);
    }
}
