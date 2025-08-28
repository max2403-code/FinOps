namespace FinOps.Modules.Inventory.Database.DataModels;

public class SupplierDataModel
{
    public int Id { get; set; }

    public SupplierInfoDataModel? SupplierInfo { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
