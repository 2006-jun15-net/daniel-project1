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

        public OrderHistory(int orderID, int locationID, int customerID, string date, string time)
        {
            OrderId = orderID;
            LocationId = locationID;
            CustomerId = customerID;
            Date = date;
            Time = time;
        }

        public OrderHistory() { }
    }
}
