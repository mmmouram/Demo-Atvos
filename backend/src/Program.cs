using BackEnd.Config;
using BackEnd.Middlewares;
using BackEnd.Repositories;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to DI container
builder.Services.AddControllers();

// Configure SQL Server connection (ensure that a connection string "DefaultConnection" exists in appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Dependency Injection for repositories and services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Use custom error handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
