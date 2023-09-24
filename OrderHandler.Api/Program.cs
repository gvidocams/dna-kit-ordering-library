using OrderHandler.Application;
using OrderHandler.Application.AddOrder.CalculateOrderPrice;
using OrderHandler.Application.AddOrder.GetKitVariantPrice;
using OrderHandler.Application.AddOrder.GetOrderDiscount;
using OrderHandler.Application.AddOrder.ValidateOrder;
using OrderHandler.Core.Models;
using OrderHandler.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderHandlerService, OrderHandlerService>();
builder.Services.AddSingleton<IOrderDbContext, OrderDbContext>();
builder.Services.AddSingleton<IOrderPriceService, OrderPriceService>();
builder.Services.AddSingleton<IOrderRequestValidationService, OrderRequestValidationService>();
builder.Services.AddSingleton<IKitVariantPriceService, KitVariantPriceService>();
builder.Services.AddSingleton<IDiscountService, DiscountService>();
builder.Services.AddSingleton<List<Order>>();

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