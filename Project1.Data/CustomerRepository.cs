﻿using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Project01Context _context;

        public CustomerRepository(Project01Context context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            var Entity = new CustomerEntity { CustomerId = customer.CustomerId, FirstName = customer.FirstName, LastName = customer.LastName };

            _context.CustomerEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
