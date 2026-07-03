using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Repositories;
using CustomerManagement.Infrastructure.Data;

namespace CustomerManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _db;

        public CustomerRepository(CustomerDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _db.Customers.FindAsync(id);
            if (existing is null) return;
            _db.Customers.Remove(existing);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }
    }
}