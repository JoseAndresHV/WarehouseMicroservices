using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Sales.Data;
using WarehouseMicroservices.Sales.Services.Implementations;
using WarehouseMicroservices.Sales.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

services.AddDbContext<AppDbContext>(
    opt => opt.UseSqlite(configuration.GetConnectionString("SalesDb")));

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddSingleton(
    s => new ServiceBusClient(configuration.GetConnectionString("ServiceBus")));

services.AddSingleton<IMessageConsumer, MessageConsumer>();

services.AddScoped<ISaleService, SaleService>();

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

var bus = app.Services.GetService<IMessageConsumer>();
bus!.RegisterOnMessageHandlerAndReceiveMessages().GetAwaiter().GetResult();

app.Run();
