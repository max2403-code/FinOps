namespace FinOps.Modules.Inventory.Database.DataModels;

public class MeasurementUnitDataModel
{
    public int Id { get; set; }

    public string ShortName { get; set; }
    
    public string FullName { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
