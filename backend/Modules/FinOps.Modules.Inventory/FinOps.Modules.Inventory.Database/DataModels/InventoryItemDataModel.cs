namespace FinOps.Modules.Inventory.Database.DataModels;

public class InventoryItemDataModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int InventoryCategoryId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public InventoryCategoryDataModel InventoryCategory { get; set; }
}
