using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Project01Context _context;

        public ProductRepository(Project01Context context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            var Entity = new ProductEntity { ProductId = product.ProductId, Name = product.Name, Price = product.Price };

            _context.ProductEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
