using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;

namespace CustomerManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> CreateAsync(CreateCustomerRequest request);
        Task UpdateAsync(Guid id, UpdateCustomerRequest request);
        Task DeleteAsync(Guid id);
    }

    public record CreateCustomerRequest(string FirstName, string LastName, string Email);
    public record UpdateCustomerRequest(string FirstName, string LastName, string Email);
}