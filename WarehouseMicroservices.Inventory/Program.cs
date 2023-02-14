using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Inventory.Data;
using WarehouseMicroservices.Inventory.Services.Implementations;
using WarehouseMicroservices.Inventory.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

services.AddDbContext<AppDbContext>(
    opt => opt.UseSqlite(configuration.GetConnectionString("InventoryDb")));

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddSingleton(
    s => new ServiceBusClient(configuration.GetConnectionString("ServiceBus")));

services.AddSingleton<IMessagePublisher, MessagePublisher>();

services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
