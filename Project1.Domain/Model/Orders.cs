using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Orders
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Amount { get; set; }

        public Orders(int orderID, int productID, int amount)
        {
            OrderID = orderID;
            ProductID = productID;
            Amount = amount;
        }



    }
}
