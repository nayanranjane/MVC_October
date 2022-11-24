using Coditas.Ecomm.DataAccess;
using Coditas.Ecom.Repositories;
using Coditas.Ecomm.Entities;
using Coditas.Ecomm.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_App.CustomFilters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Global REgistration of Action Filter
    options.Filters.Add(typeof(CustomLogRequestAttribute));


    options.Filters.Add(typeof(AppExceptionAttribute));
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddDbContext<EShoppingCodiContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});



builder.Services.AddScoped<IDbRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IDbRepository<Product,int>, ProductRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


if (!app.Environment.IsDevelopment())
{
    // SHow Error during Development these are standard Error MEssages
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
