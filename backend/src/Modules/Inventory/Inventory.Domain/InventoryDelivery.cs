using Inventory.Domain.Base;

namespace Inventory.Domain;

public class InventoryDelivery : GuidBaseDomainModel
{
    public required string Number { get; set; }

    public int InventoryItemId { get; set; }

    public int SupplierId { get; set; }

    public int MeasurementUnitId { get; set; }

    public decimal Quantity { get; set; }

    public decimal TotalCost { get; set; }

    public DateTimeOffset DeliveryDate { get; set; }

    public string? Comment { get; set; }

    public required InventoryItem InventoryItem { get; set; }

    public required Supplier Supplier { get; set; }

    public required MeasurementUnit MeasurementUnit { get; set; }
}
