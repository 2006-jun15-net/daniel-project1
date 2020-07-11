using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(string search = null);

        Customer GetCustomerById(int id);

        Customer GetCustomerByFullName(string firstname, string lastname);
        void Create(Customer customer);

        void Update(Customer customer);
    }
}
