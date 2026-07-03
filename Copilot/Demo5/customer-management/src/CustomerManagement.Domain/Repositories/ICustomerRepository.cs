using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}