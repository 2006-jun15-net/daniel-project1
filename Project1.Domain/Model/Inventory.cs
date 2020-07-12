using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Inventory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public Inventory(int locationID, int productID, int amount)
        {
            LocationId = locationID;
            ProductId = productID;
            Amount = amount;
        }

        public Inventory() { }

        public Inventory(int locationId, int productId, string name, decimal price, int amount)
        {
            LocationId = locationId;
            ProductId = productId;
            this.Name = name;
            this.Price = price;
            Amount = amount;
        }
    }
}
