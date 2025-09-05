using Inventory.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Inventory.Database.DataModels;

namespace Inventory.Database.Context;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InventoryCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryDeliveryConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryItemConfiguration());
        modelBuilder.ApplyConfiguration(new MeasurementUnitConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
    }

    public DbSet<InventoryCategoryDataModel> InventoryCategories { get; set; }

    public DbSet<InventoryDeliveryDataModel> InventoryDeliveries { get; set; }

    public DbSet<InventoryItemDataModel> InventoryItems { get; set; }

    public DbSet<MeasurementUnitDataModel> MeasurementUnits { get; set; }

    public DbSet<SupplierDataModel> Suppliers { get; set; }
}
