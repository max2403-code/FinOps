using Inventory.Database.DataModels.Base;

namespace Inventory.Database.DataModels;

public class InventoryDeliveryDataModel : GuidBaseDataModel
{
    public string Number { get; set; } = string.Empty;

    public int InventoryItemId { get; set; }

    public int SupplierId { get; set; }

    public int MeasurementUnitId { get; set; }
    
    public decimal Quantity { get; set; }

    public decimal TotalCost { get; set; }

    public DateTimeOffset DeliveryDate { get; set; }

    public string? Comment { get; set; }

    public InventoryItemDataModel InventoryItem { get; set; }

    public SupplierDataModel Supplier { get; set; }

    public MeasurementUnitDataModel MeasurementUnit { get; set; }
}
