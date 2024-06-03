using DataAccess.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Infastructure.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreAppContext>();
        if(context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }  //projede hali hazırda bir migration varsa projeyi build ettiğimde bunu update etmesini sağlıyor.
    }

    public static void ConfigureLocalization(this WebApplication app)
    {
        app.UseRequestLocalization(options =>  //projedeki dil ayarlarını yapan bir extension
        {
            options.AddSupportedCultures("tr-TR")
            .AddSupportedCultures("tr-TR")
            .SetDefaultCulture("tr-TR");
        });
    }

    public async static void ConfigureDefaultAdminUser(this IApplicationBuilder app)
    {
        const string adminUser = "Admin";
        const string adminPassword = "admin+123456";

        UserManager<IdentityUser> userManager = app  //userManager kullanıcı oluşturma, silme, doğrulama gibi işlemleri yönetmek için kullanılır.
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

        RoleManager<IdentityRole> roleManager = app  // RoleManager ise rol bazlı yetkilendirme işlemlerini yönetir.
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        IdentityUser user = await userManager.FindByNameAsync(adminUser); //kullanıcı adına bakarak böyle bir kullanıcı var mı yok mu onu bulmaya çalışıyor.
        if(user == null) // böyle bir kullanıcı yok ise
        {
            user = new IdentityUser()
            {
                Email = "evrim98@outlook.com",
                PhoneNumber = "5304162641",
                UserName = adminUser
            };

            var result = await userManager.CreateAsync(user, adminPassword); //yeni bir user oluştur.
            if (!result.Succeeded)
                throw new Exception("Admin kulanıcısı oluşturulamadı");

            var roleResult = await userManager.AddToRolesAsync(user,
                roleManager
                .Roles
                .Select(s => s.Name).ToList()
                );
            if (!roleResult.Succeeded)
                throw new Exception("Yeni bir rol oluşturulamadı"); 
        }
    }
    
}
