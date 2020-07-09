using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Inventory
    {
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
    }
}
