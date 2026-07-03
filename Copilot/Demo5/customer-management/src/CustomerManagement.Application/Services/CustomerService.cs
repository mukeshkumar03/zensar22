using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Repositories;

namespace CustomerManagement.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<CustomerDto>(entity);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(e => _mapper.Map<CustomerDto>(e));
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerRequest request)
        {
            var entity = new Customer(request.FirstName, request.LastName, request.Email);
            await _repo.AddAsync(entity);
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task UpdateAsync(Guid id, UpdateCustomerRequest request)
        {
            var existing = await _repo.GetByIdAsync(id) ?? throw new InvalidOperationException("Customer not found");
            existing.UpdateName(request.FirstName, request.LastName);
            existing.UpdateEmail(request.Email);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}