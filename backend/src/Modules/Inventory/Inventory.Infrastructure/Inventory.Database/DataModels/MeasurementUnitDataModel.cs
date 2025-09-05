using Common.Database.DataModels;

namespace Inventory.Database.DataModels;

public class MeasurementUnitDataModel : GuidBaseDataModel
{
    public string ShortName { get; set; }
    
    public string FullName { get; set; }
}
