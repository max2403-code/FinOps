using Inventory.Database.DataModels.Base;
using System.Collections.ObjectModel;

namespace Inventory.Database.DataModels;

public class InventoryItemDataModel : GuidBaseDataModel
{
    public string Name { get; set; } = string.Empty;

    public int InventoryCategoryId { get; set; }

    public InventoryCategoryDataModel InventoryCategory { get; set; }

    public Collection<InventoryDeliveryDataModel>? InventoryDeliveries { get; set; }
}
