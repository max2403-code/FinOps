using Inventory.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FinOps.Modules.Inventory.Api.Extensions;

public static class MigrateExtensions
{
    public static void DbMigrate(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<InventoryDbContext>>();
            using (var dbContext = factory.CreateDbContext())
                dbContext.Database.Migrate();
        }
    }
}