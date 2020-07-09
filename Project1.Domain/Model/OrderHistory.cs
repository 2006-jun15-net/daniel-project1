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

        public OrderHistory(int orderID, int customerID, int locationID, string date, string time)
        {
            OrderId = orderID;
            CustomerId = customerID;
            LocationId = locationID;
            Date = date;
            Time = time;
        }

        public OrderHistory() { }
    }
}
