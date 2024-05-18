

using BLL.Abstract;
using BLL.Concrete;
using DataAccess.Database;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Concrete;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<StoreAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{Id?}"  
     );

    endpoints.MapControllerRoute("default", "{controller=Product}/{action=Index}/{Id?}");

    endpoints.MapRazorPages();  
});



app.Run();
