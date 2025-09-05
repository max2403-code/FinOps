using Inventory.Domain.Base;
using System.Collections.ObjectModel;

namespace Inventory.Domain;

public class InventoryItem : GuidBaseDomainModel
{
    public string Name { get; set; } = string.Empty;

    public int InventoryCategoryId { get; set; }

    public required InventoryCategory InventoryCategory { get; set; }

    public IReadOnlyCollection<InventoryDelivery>? Deliveries { get; set; }
}
