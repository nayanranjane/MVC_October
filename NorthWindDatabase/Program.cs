using Microsoft.EntityFrameworkCore;
using NorthWindDatabase.Controllers;
using NorthWindDatabase.Models;
using NorthWindDatabase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});

builder.Services.AddScoped<IDbAccessService<Product, int>, ProductsDataAccessService>();
builder.Services.AddScoped<IDbAccessService<Customer, int>, CustomerDataAccessService>();
builder.Services.AddScoped<IDbAccessService<Order, int>, OrderDataAccessService>();
builder.Services.AddScoped<IDbAccessService<OrderDetail, int>, OrderDetailsDataAccessService>();

builder.Services.AddControllers().AddJsonOptions(options => {
    // ReSet the JSON Serialization to the format for
    // Property Naming as per provided in ENtity class
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
