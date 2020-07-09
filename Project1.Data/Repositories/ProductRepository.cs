using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Project01Context _context;

        public ProductRepository(Project01Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Product product)
        {
            var Entity = new ProductEntity { ProductId = product.ProductId, Name = product.Name, Price = product.Price };

            _context.ProductEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var entities = _context.ProductEntity.ToList();

            return entities.Select(e => new Product(e.ProductId, e.Name, e.Price));
        }

        public Product GetProductById(int id)
        {
            var product = _context.ProductEntity
                .FirstOrDefault(l => l.ProductId == id);

            return new Product(product.ProductId, product.Name, product.Price);
        }


        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
