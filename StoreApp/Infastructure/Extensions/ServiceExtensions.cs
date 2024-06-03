using BLL.Abstract;
using BLL.Concrete;
using DataAccess.Database;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
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
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")); //program.cs de kullanmamız yerine extensionların içine yazmak daha dğru bi kod yapısı olur. Bu method sqlserver configurasyonunu sağlar.

            opt.EnableSensitiveDataLogging(true); //hassas verileri loglama işlemini yapar.
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(opt =>     //ıdentity için servis kaydımızı yapmış olduk.
        {
            opt.SignIn.RequireConfirmedAccount = false; //kişi emailini onaylayıp onaylamadığını kontrol eder. True olduğunda.
            opt.User.RequireUniqueEmail = true; //kişinin email adresi gerekli olsun mu ? bunu kontrol eder. True olduğunda.
            opt.Password.RequireUppercase = false;   //kişinin parolası büyük harf içersin mi? bunu kontrol eder.
            opt.Password.RequireLowercase = false; //kişi parola luştururken küçük harf içersin mi? bunu kontrol eder.
            opt.Password.RequireDigit = false; //kişi parola oluştururken rakam içersin mi? bunu kontrol eder.
            opt.Password.RequiredLength = 6; //kişinin parolası 6 karakterden fazla olmasın.
        }).AddEntityFrameworkStores<StoreAppContext>();
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = "StoreApp.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(10);
        });                 //session configurasyonlarını yapmamızı sağlar.
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<Cart>(c => SessionCart.GetCart(c)); //sepetim kısmını session ile kullanılması için enjekte etmiş olduk.
    }

    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();   //repositoryleri servise enjekte etmiş olduk.
    }

    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();      //servisleri buraya enjekte etmiş olduk.
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderService, OrderService>(); 
        services.AddScoped<IAuthService, AuthService>();
    }

    public static void ConfigureAplicationCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(opt =>
        {
            opt.LoginPath = new PathString("/Account/Login");
            opt.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
        });
    }

    public static void ConfigureRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>      //url de bulunan string ifadelerin hepsini küçük yazar.
        {
            options.LowercaseUrls = true;
        });
    }
}
