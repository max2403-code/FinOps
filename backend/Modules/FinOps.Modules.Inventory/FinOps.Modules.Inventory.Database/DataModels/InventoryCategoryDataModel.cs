namespace FinOps.Modules.Inventory.Database.DataModels;

public class InventoryCategoryDataModel
{
    public int Id { get; set; }
    
    public string CategoryName { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public int HeadInventoryCategoryId { get; set; }

    public InventoryCategoryDataModel HeadInventoryCategory { get; set; }

    public ICollection<InventoryCategoryDataModel> SubInventoryCategories { get; set; }
}
