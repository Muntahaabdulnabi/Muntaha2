using MunApi.Contexts;
using MunApi.Models.Entities;
using MunApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MunApi.Services
{
    public class CustomerServices
    {
        private readonly DataContext _context;

        public CustomerServices(DataContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerCreateModel model)
        {
            var customerEntity = new CustomerEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
            };
            _context.Add(customerEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Phone = customer.Phone, Address = customer.Address });
            return customers;
        }

        public async Task<CustomerModel> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerModel { Id = customerEntity.Id, FirstName = customerEntity.FirstName, LastName = customerEntity.LastName, Email = customerEntity.Email, Phone = customerEntity.Phone, Address = customerEntity.Address };

            return null!;
        }
    }
}

