using Inventory.Domain.Base;

namespace Inventory.Domain;

public class InventoryCategory : GuidBaseDomainModel
{
    public required string CategoryName { get; set; }

    public int? HeadInventoryCategoryId { get; set; }

    public InventoryCategory? HeadInventoryCategory { get; set; }

    public IReadOnlyCollection<InventoryCategory>? SubInventoryCategories { get; set; }

    public IReadOnlyCollection<InventoryItem>? InventoryItems { get; set; }
}
