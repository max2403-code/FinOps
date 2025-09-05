using Common.Database.DataModels;

namespace Inventory.Database.DataModels;

public class SupplierDataModel : GuidBaseDataModel
{
    public SupplierInfoDataModel? SupplierInfo { get; set; }
}
