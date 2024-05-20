

using BLL.Abstract;
using BLL.Concrete;
using Entities.Entities;
using Services.Abstract;
using Services.Concrete;
using StoreApp.Models;
using StoreApp.Infastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

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

    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");

    endpoints.MapRazorPages();  
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.Run();
