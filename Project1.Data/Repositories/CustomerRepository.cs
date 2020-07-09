using Microsoft.EntityFrameworkCore;
using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Project01Context _context;

        public CustomerRepository(Project01Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Customer customer)
        {
            var Entity = new CustomerEntity {FirstName = customer.FirstName, LastName = customer.LastName };

            _context.CustomerEntity.Add(Entity);

            _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            CustomerEntity customer = _context.CustomerEntity
                .FirstOrDefault(r => r.CustomerId == id);

            return new Customer { CustomerId = customer.CustomerId, FirstName = customer.FirstName, LastName = customer.LastName };
        }

        public IEnumerable<Customer> GetCustomers(string search = null)
        {
            IQueryable<CustomerEntity> items = _context.CustomerEntity;
            if (search != null)
            {
                items = items.Where(r => r.FirstName.Contains(search));
            }
            return items.Select(e => new Customer(e.CustomerId, e.FirstName, e.LastName));
        }
        
        public void Update(Customer customer)
        {
            CustomerEntity currentEntity = _context.CustomerEntity.Find(customer.CustomerId);
            var newEntity = new CustomerEntity { FirstName = customer.FirstName, LastName = customer.LastName, CustomerId = currentEntity.CustomerId };

            _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
            _context.SaveChanges();
        }
    }
}
