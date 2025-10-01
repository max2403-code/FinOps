using Inventory.Database.DataModels.Base;

namespace Inventory.Database.DataModels;

public class SupplierDataModel : GuidBaseDataModel
{
    public SupplierInfoDataModel? SupplierInfo { get; set; }
}
