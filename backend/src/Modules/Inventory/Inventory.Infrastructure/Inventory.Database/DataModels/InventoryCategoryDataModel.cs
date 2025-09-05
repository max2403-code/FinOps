using Common.Database.DataModels;

namespace Inventory.Database.DataModels;

public class InventoryCategoryDataModel : GuidBaseDataModel
{
    public string CategoryName { get; set; } = string.Empty;

    public int? HeadInventoryCategoryId { get; set; }

    public InventoryCategoryDataModel? HeadInventoryCategory { get; set; }

    public ICollection<InventoryCategoryDataModel>? SubInventoryCategories { get; set; }

    public ICollection<InventoryItemDataModel>? InventoryItems { get; set; }

}
