using Inventory.Database.Context;
using Inventory.Database.Mappers.Profiles;
using Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Database;

public static class DependencyInjection
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<InventoryDbContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("InventoryDbConnectionString");
            opt.UseNpgsql(connectionString);
        });
    }

    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<InventoryItemProfile>();
            cfg.AddProfile<InventoryCategoryProfile>();
        });
    }
}
