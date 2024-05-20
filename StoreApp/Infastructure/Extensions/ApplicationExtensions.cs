using DataAccess.Database;
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
        }
    }

    public static void ConfigureLocalization(this WebApplication app)
    {
        app.UseRequestLocalization(options =>
        {
            options.AddSupportedCultures("tr-TR")
            .AddSupportedCultures("tr-TR")
            .SetDefaultCulture("tr-TR");
        });
    }

    
}
