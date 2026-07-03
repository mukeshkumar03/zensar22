using AutoMapper;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}