using Inventory.Domain.Base;

namespace Inventory.Domain;

public class MeasurementUnit : GuidBaseDomainModel
{
    public required string ShortName { get; set; }

    public required string FullName { get; set; }
}
