using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int productID, string name, decimal price)
        {
            ProductId = productID;
            Name = name;
            Price = price;
        }
    }
}
