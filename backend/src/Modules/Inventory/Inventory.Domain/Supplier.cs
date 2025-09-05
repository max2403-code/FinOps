using Inventory.Domain.Base;

namespace Inventory.Domain;

public class Supplier : GuidBaseDomainModel
{
    public SupplierInfo? SupplierInfo { get; set; }
}
