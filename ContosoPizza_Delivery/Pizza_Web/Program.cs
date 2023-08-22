using Microsoft.EntityFrameworkCore;
using Pizza_Core;
using Pizza_Core.Repository;
using Pizza_Data.DatabaseEntities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConStr")));

builder.Services.AddTransient<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddTransient<IRepository<Order>, Repository<Order>>();
builder.Services.AddTransient<IRepository<OrderDetails>, Repository<OrderDetails>>();
builder.Services.AddTransient<IRepository<Product>, Repository<Product>>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
