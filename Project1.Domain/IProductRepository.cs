using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        void Create(Product product);

        void Update(Product product);

    }
}
