using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityMVC.Controllers;
using NuGet.Protocol.Plugins;
using IdentityMVC.Data;
using System.Security;
using IdentityMVC.Controllers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityMVC_SecurityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityMVC_SecurityContextConnection' not found.");

builder.Services.AddDbContext<IdentityMVC_SecurityContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityMVC_SecurityContext>()
    .AddDefaultUI();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



app.Run();
