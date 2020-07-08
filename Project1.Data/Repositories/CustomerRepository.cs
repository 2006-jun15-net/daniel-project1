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

        public IEnumerable<Customer> GetCustomers(string search = null)
        {
            IQueryable<CustomerEntity> items = _context.CustomerEntity;
            if (search != null)
            {
                items = items.Where(r => r.FirstName.Contains(search));
            }
            return items.Select(e => new Customer(e.CustomerId, e.FirstName, e.LastName));
        }
        
        /*
        public IEnumerable<Customer> GetAll()
        {
            var entities = _context.CustomerEntity.ToList();

            return entities.Select(e => new Customer(e.CustomerId, e.FirstName, e.LastName));
        }
        */
        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
