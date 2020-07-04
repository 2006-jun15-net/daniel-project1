using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class OrderHistory
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public OrderHistory(int orderID, int customerID, int locationID)
        {
            OrderId = orderID;
            CustomerId = customerID;
            LocationId = locationID;
            Date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            Time = DateTime.Now.ToString("HH:mm");
        }
    }
}
