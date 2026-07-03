using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CustomerManagement.Infrastructure.Data;
using CustomerManagement.Infrastructure.Repositories;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services;
using CustomerManagement.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext - using InMemory for sample. Swap to SQL Server in real deployments.
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseInMemoryDatabase("CustomerDb"));

// AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));

// DI registrations
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<CustomerManagement.Domain.Repositories.ICustomerRepository, CustomerRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
