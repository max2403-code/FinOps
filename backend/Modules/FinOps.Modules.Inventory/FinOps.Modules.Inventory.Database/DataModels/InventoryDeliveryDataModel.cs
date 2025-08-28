namespace FinOps.Modules.Inventory.Database.DataModels;

public class InventoryDeliveryDataModel
{
    public int Id { get; set; }

    public int InventoryItemId { get; set; }

    public int SupplierId { get; set; }

    public int MeasurementUnitId { get; set; }
    
    public decimal Quantity { get; set; }

    public decimal TotalCost { get; set; }

    public string? Comment { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public InventoryItemDataModel InventoryItem { get; set; }
    public SupplierDataModel Supplier { get; set; }
    public MeasurementUnitDataModel MeasurementUnit { get; set; }

}
