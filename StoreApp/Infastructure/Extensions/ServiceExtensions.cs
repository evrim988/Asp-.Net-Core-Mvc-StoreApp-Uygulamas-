using BLL.Abstract;
using BLL.Concrete;
using DataAccess.Database;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Concrete;
using StoreApp.Models;

namespace StoreApp.Infastructure.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreAppContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        });
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = "StoreApp.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(10);
        });
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<Cart>(c => SessionCart.GetCart(c));
    }

    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>(); 
    }

    public static void ConfigureRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
    }
}
