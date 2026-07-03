using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (SQL Server) - connection string from appsettings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=localhost,1433;Database=OrderManagementDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;";
builder.Services.AddDbContext<OrderManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();