using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(int customerID, string firstname, string lastname)
        {
            CustomerId = customerID;
            FirstName = firstname;
            LastName = lastname;
        }

    }
}
