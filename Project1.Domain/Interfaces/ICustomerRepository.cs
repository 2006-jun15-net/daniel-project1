using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(string search = null);


        //IEnumerable<Customer> GetAll();

        void Create(Customer customer);

        void Update(Customer customer);
    }
}
